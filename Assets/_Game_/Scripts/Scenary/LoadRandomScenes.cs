using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 

public class LoadRandomScenes : MonoBehaviour
{
    private int currentLvl = 1;
    private int randomLvl;
    public void LoadRandomScene()
    {
        randomLvl = Random.Range(1,4);
        if(randomLvl == currentLvl)
        {
            Debug.Log("Level repetido" + randomLvl);
            LoadRandomScene();
        }
        else
        {
        SceneManager.LoadScene(randomLvl);
        Debug.Log("Scene Loaded = " + randomLvl);
        currentLvl = randomLvl;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            LoadRandomScene();
        }
    }
}
