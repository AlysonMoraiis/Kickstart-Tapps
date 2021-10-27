using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 

public class LoadRandomScenes : MonoBehaviour
{
    private int currentLvl;
    [SerializeField]
    List<string> randomLvl;
    private int randomLvlIndex;

    public void LoadRandomScene()
    {
        /*
        randomLvlIndex = Random.Range(0, randomLvl.Count);
        currentLvl = randomLvlIndex;
        SceneManager.LoadScene(randomLvl[randomLvlIndex]);
        Debug.Log("Scene Loaded = " + randomLvlIndex);
        randomLvl.Clear();
        */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            LoadRandomScene();
        }
    }
}
