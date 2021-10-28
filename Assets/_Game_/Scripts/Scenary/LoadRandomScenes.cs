using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 

public class LoadRandomScenes : MonoBehaviour
{
    [SerializeField]
    List<string> randomLvl;
    private int randomLvlIndex;

    public void LoadRandomScene()
    {
        randomLvlIndex = Random.Range(0, randomLvl.Count);
        SceneManager.LoadScene(randomLvl[randomLvlIndex]);
        randomLvl.RemoveAt(randomLvlIndex);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            LoadRandomScene();
        }
    }
}
