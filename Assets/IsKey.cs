using UnityEngine;

public class IsKey : MonoBehaviour
{    
    public bool Key = false;
    [SerializeField] float DestroyTime = 2f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && Key == true)
        {
            FindObjectOfType<GameManager>().CheckKeys();
            Destroy(gameObject, DestroyTime);            
        }
    }
}
