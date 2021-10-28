using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System;

public class LoadRandomScenes : MonoBehaviour
{
    [SerializeField]
    List<string> randomLvl;
    [SerializeField]
    private ScoreManager scoreManager;

    private int randomLvlIndex;


    public void LoadRandomScene()
    {
        randomLvlIndex = UnityEngine.Random.Range(0, randomLvl.Count);
        SceneManager.LoadScene(randomLvl[randomLvlIndex]);
        randomLvl.RemoveAt(randomLvlIndex);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
           // scoreManager.DungeonPass();
            Destroy(this.gameObject);
            LoadRandomScene();
        }
    }
}
