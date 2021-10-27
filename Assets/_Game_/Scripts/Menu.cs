using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [Header("Menu")]
    public GameObject panelMenu;
    public GameObject panelCredits;
    public GameObject panelSettings;


    public void Play()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void Credits()
    {
        panelCredits.SetActive(true);
        panelSettings.SetActive(false);
        panelMenu.SetActive(false);
    }

    public void Settings()
    {
        panelSettings.SetActive(true);
        panelCredits.SetActive(false);
        panelMenu.SetActive(false);
    }

    public void BackMenu()
    {
        panelCredits.SetActive(false);
        panelMenu.SetActive(true);
        panelSettings.SetActive(false);
    }

    public void Quit()
    {
        Debug.Log("SAIU");
        Application.Quit();
    }
}