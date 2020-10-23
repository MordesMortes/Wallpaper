using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField] GameObject WinScreen;
    [SerializeField] GameObject[] Zombies;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip;
    [SerializeField] float TimeToDisplay = 10f;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            WinScreen.GetComponent<LoseScreen>().LoseScreenActive();
            Destroy(WinScreen, TimeToDisplay);
            audioSource.Stop();
            audioSource.PlayOneShot(clip);
            FindObjectOfType<GameManager>().GameHasEnded = true;
            foreach (GameObject zombie in Zombies)
            {
                Destroy(zombie);
            }
            if (!audioSource.isPlaying)
            {
                Application.Quit();
            }
        }
    }
}
