using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text highscoreText;
    [SerializeField]
    private Text dungeonsAmountText;
    [SerializeField]
    private ScoreData scoreData;
    [SerializeField]
    private BattleSystem battle;

    private void OnEnable()
    {
        battle.OnWinning += AddPoints;
    }
    private void OnDisable()
    {
        battle.OnWinning -= AddPoints;
    }

    private void Start()
    {
        TextUpdate();
    }

    public void DungeonPass()
    {
        scoreData.dungeonsAmount += 1;
        AddPoints(2);
    }

    private void TextUpdate()
    {
        scoreText.text = "SCORE: " + scoreData.score.ToString();
        dungeonsAmountText.text = "DUNGEONS: " + scoreData.dungeonsAmount.ToString();
    }

    private void AddPoints(int points)
    {
        scoreData.score += points;
        if(scoreData.score > scoreData.highscore)
        {
            PlayerPrefs.SetInt("highscore", scoreData.score);
        }
        TextUpdate();
    }
}
