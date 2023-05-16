using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //public AudioSource A;
    // Start is called before the first frame update
    void Start()
    {
        //A.Play();//door dit begint het muziek met spelen
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        //A.Stop();// stopt het muziek
    }

    public void EndGame()
    {
        Application.Quit();
    }
}