using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update

    public void Setup()
    {

        //ScoreManager.instance.UpdatePoint(); //is voor de punten toevoeging aan het Game Over scherm
    }
    //deze laden de specifieke scenes
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // laat de scene opnieuw beginnen
    }

    public void ExitButton()
    {
        SceneManager.LoadScene(0); //brengt je naar het start scherm
    }

    public void gameOver()
    {

    }
}
