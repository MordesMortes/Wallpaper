using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTo : MonoBehaviour
{
    public GameObject Player;

    [SerializeField] AudioClip clip;
    [SerializeField] AudioSource AudioSource;
    [SerializeField] GameObject OtherZombie;
    bool attacked = false;
    GameObject lookat;
    // Start is called before the first frame update
    private void Start()
    {
        lookat = Player;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(lookat.transform);

    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                if (attacked == false)
                {
                    attacked = true;
                    AudioSource.PlayOneShot(clip);
                    FindObjectOfType<GameManager>().GameOver();
                }
                break;

            case "Brains":
                AudioSource.PlayOneShot(clip);
                lookat = Player;
                OtherZombie.GetComponent<LookTo>().lookat = Player;
                Destroy(collision.gameObject);
                break;
                 
            default:
                break;
        }
        
    }
    public void BRAINS(GameObject Brains)
    {
        lookat = Brains;
    }
}
