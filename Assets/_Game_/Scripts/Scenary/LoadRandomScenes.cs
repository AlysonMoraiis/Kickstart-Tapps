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

    public event Action onDungeonPass;

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
            onDungeonPass?.Invoke();
            Destroy(this.gameObject);
            LoadRandomScene();
        }
    }
}
