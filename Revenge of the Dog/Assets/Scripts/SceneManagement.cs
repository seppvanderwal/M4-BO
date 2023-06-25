using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 

public class SceneManagement : MonoBehaviour
{
    public GameObject completionUI;
    public GameObject boneUI;
    public int levelToUnlock;
    int numberOfUnlockedLevels;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
                {
            completionUI.SetActive(true);
            boneUI.SetActive(false);

            numberOfUnlockedLevels = PlayerPrefs.GetInt("levelsUnlocked");

            if (numberOfUnlockedLevels <= levelToUnlock)
            {
                PlayerPrefs.SetInt("levelsUnlocked", numberOfUnlockedLevels + 1);
            }
        }  
    }
}
