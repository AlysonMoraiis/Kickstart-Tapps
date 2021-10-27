using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 

public class LoadRandomScenes : MonoBehaviour
{
    private int currentLvl;
    [SerializeField]
    List<int> randomLvl;
    [SerializeField]
    private int randomLvlIndex;

    public void LoadRandomScene()
    {
        currentLvl = randomLvlIndex;
        randomLvlIndex = Random.Range(0, randomLvl.Count);
        while(randomLvl == currentLvl)
        {
            Debug.Log("Level repetido" + randomLvl);
            randomLvl = Random.Range(2, 5);
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
