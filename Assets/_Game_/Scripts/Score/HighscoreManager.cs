using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreManager : MonoBehaviour
{

    [SerializeField]
    private ScoreData scoreData;
    [SerializeField]
    private Text highscoreText;

    void Start()
    {
        TextUpdate();
    }

    private void TextUpdate()
    {
        scoreData.highscore = PlayerPrefs.GetInt("highscore", 0);
        highscoreText.text = "HIGHSCORE: " + scoreData.highscore.ToString();
    }


}
