using UnityEngine;

[CreateAssetMenu]
public class ScoreKeeper : ScriptableObject
{
    /*
     * Scores.
     */
    [Header("Scores")]
    //The highest recorded score.
    [SerializeField]
    int highScore = 0;
    public int HighScore => highScore;

    //The score off the last game.
    [SerializeField]
    int lastScore = 0;
    public int LastScore => lastScore;

    //The current score.
    int currentScore = 0;
    public int CurrentScore => currentScore;

    /*
     * PlayerPrefs keys.
     */
    //Key that we use to save the highscore with.
    const string highScoreKey = "HIGHSCORE";

    //Key that we use to save the lastscore with.
    const string lastScoreKey = "LASTSCORE";

    public void OnEnable()
    {
        LoadScores();
    }

    public void ResetCurrentScore()
    {
        currentScore = 0;
    }

    public void AddScore(int amount)
    {
        if (amount >= 0)
        {
            currentScore += amount;
        }
        else
        {
            Debug.LogWarning("Tried to add negative score of " + amount);
        }
    }
    public void LoadScores()
    {
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        lastScore = PlayerPrefs.GetInt(lastScoreKey, 0);

        Debug.Log("Loaded scores!");
    }

    public void SaveScores()
    {
        if (currentScore > highScore)
        {
            highScore = currentScore;
        }

        lastScore = currentScore;

        PlayerPrefs.SetInt(highScoreKey, highScore);
        PlayerPrefs.SetInt(lastScoreKey, lastScore);

        Debug.Log("Saved scores!");
    }
}
