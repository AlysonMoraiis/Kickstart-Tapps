using UnityEngine;

[CreateAssetMenu(menuName = "ScoreData")]
public class ScoreData : ScriptableObject
{
    public int score;
    public int highscore;

    public void ResetScore()
    {
        score = 0;
    }
}
