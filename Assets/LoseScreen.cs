using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseScreen : MonoBehaviour
{
    [SerializeField] MeshRenderer mesh;
    [SerializeField] AudioClip clip;
    [SerializeField] AudioSource AudioSource;
    // Start is called before the first frame update
    

    public void LoseScreenActive()
    {
        AudioSource.PlayOneShot(clip);
        mesh.enabled = true;
    }

    public void Reset()
    {
        mesh.enabled = false;
    }
}
