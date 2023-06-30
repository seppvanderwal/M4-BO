using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level 1");
        //A.Stop();// stopt het muziek
    }
    public void Level2()
    {
        SceneManager.LoadScene("Level 2");
        //A.Stop();// stopt het muziek
    }
    public void Level3()
    {
        SceneManager.LoadScene("Level 3");
        //A.Stop();// stopt het muziek
    }
    public void Level4()
    {
        SceneManager.LoadScene("Level 4");
        //A.Stop();// stopt het muziek
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Start screen");
        //A.Stop();// stopt het muziek
    }
}
