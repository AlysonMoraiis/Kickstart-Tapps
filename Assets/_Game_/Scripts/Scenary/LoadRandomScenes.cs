using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 

public class LoadRandomScenes : MonoBehaviour
{
    private int currentLvl;
    private int randomLvl;
    public void LoadRandomScene()
    {
        randomLvl = Random.Range(2,5);
        while(randomLvl == currentLvl)
        {
            Debug.Log("Level repetido" + randomLvl);
            randomLvl = Random.Range(2, 5);
           // LoadRandomScene();
        }
        SceneManager.LoadScene(randomLvl);
        Debug.Log("Scene Loaded = " + randomLvl);
        currentLvl = randomLvl;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            LoadRandomScene();
        }
    }
}
