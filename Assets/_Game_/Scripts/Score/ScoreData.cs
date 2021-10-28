using UnityEngine;

[CreateAssetMenu(menuName = "ScoreData")]
public class ScoreData : ScriptableObject
{
    public int score;
    public int highscore;


    public int dungeonsAmount = 1;
    public void ResetScore()
    {
        score = 0;
        dungeonsAmount = 1;
    }
}
