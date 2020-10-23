using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class GameManager : MonoBehaviour
{
    public bool GameHasEnded = false;
    [SerializeField] float DeathDelay = 1f;
    [SerializeField] GameObject[] PossibleKeys;
    public int KeysFound = 0;

    [SerializeField] GameObject Door1;
    [SerializeField] GameObject Door2;
    [SerializeField] GameObject Door3;
    [SerializeField] GameObject Door4;
    [SerializeField] TeleportArea TeleportFloor1;
    [SerializeField] TeleportArea TeleportFloor2;
    [SerializeField] TeleportArea TeleportFloor3;
    [SerializeField] LoseScreen lose;
    [SerializeField] LoseScreen win;
    [SerializeField] AudioClip clip;

    bool FirstDoorsOpened;
    bool SecondDoorsOpened;

    // Start is called before the first frame update
    private void Start()
    {
        for (int i = 0; i < PossibleKeys.Length; i++)
        {
            PossibleKeys[i].AddComponent<IsKey>();
             
        }
        int FirstKey = Random.Range(0, PossibleKeys.Length);
        int SecondKey = Random.Range(0, PossibleKeys.Length);
        if (FirstKey == SecondKey)
        {
            if (FirstKey == PossibleKeys.Length)
            {
                FirstKey--;
            }
            else
            {
                FirstKey++;
            }
        }
        PossibleKeys[FirstKey].GetComponent<IsKey>().Key = true;
        PossibleKeys[SecondKey].GetComponent<IsKey>().Key = true;
    }
    public void GameOver()
    {
        if (GameHasEnded == false)
        {
            GameHasEnded = true;
            lose.Invoke("LoseScreenActive", DeathDelay);
            
        }
    }

    void Restart()
    {
        lose.Reset();
        win.Reset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // Update is called once per frame
    void Update()
    {
        if (SteamVR_Actions.default_default_abutton.GetStateDown(SteamVR_Input_Sources.Any))
        {
            Application.Quit();
            
        }
        if (SteamVR_Actions.default_GrabPinch.GetLastStateDown(SteamVR_Input_Sources.Any) && GameHasEnded == true)
        {
            Restart();
        }
    }
    public void CheckKeys()
    {
        
        KeysFound++;
        if (KeysFound >= 1 && FirstDoorsOpened == false)
        {
            Door1.transform.Rotate(0, 90, 0);
            Door2.transform.Rotate(0, -90, 0);
            TeleportFloor1.SetLocked(false);
            Door1.GetComponent<AudioSource>().Play();
            Door1.GetComponent<AudioSource>().PlayOneShot(clip);
            FirstDoorsOpened = true;

        }
        if (KeysFound >= 2 && SecondDoorsOpened == false)
        {
            Door3.transform.Rotate(0, 90, 0);
            Door4.transform.Rotate(0, -90, 0);
            TeleportFloor2.SetLocked(false);
            TeleportFloor3.SetLocked(false);
            Door3.GetComponent<AudioSource>().Play();
            Door3.GetComponent<AudioSource>().PlayOneShot(clip);
            SecondDoorsOpened = true;
        }
    }
}
