using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    /*
     * Score rewarded for each thing.
     */
    [Header("Score Rewards")]
    [SerializeField]
    int scoreDestroyedAsteroid = 10;
    public int ScoreDestroyAsteroid => scoreDestroyedAsteroid;


    /*
     * Scores.
     */
    [Header("Scores")]
    //The highest recorded score.
    [SerializeField]
    int highScore = 0;
    public int HighScore => highScore;

    //Key that we use to save the highscore with.
    const string highScoreKey = "HIGHSCORE";

    //The score off the last game.
    [SerializeField]
    int lastScore = 0;
    public int LastScore => lastScore;
    
    //Key that we use to save the lastscore with.
    const string lastScoreKey = "LASTSCORE";

    //The current score.
    [SerializeField]
    int currentScore = 0;
    public int CurrentScore => currentScore;

    void Start()
    {
        StartRound();
    }

    public void AddScore(int amount)
    {
        if(amount >= 0)
        {
            currentScore += amount;
        }
        else
        {
            Debug.LogWarning("Tried to add negative score of " + amount);
        }
    }

    public void StartRound()
    {
        LoadScores();

        currentScore = 0;
    }

    public void EndRound()
    {
        if(currentScore > highScore)
        {
            highScore = currentScore;
        }

        lastScore = currentScore;

        SaveScores();
    }
    void LoadScores()
    {
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        lastScore = PlayerPrefs.GetInt(lastScoreKey, 0);
    }

    void SaveScores()
    {
        PlayerPrefs.SetInt(highScoreKey, highScore);
        PlayerPrefs.SetInt(lastScoreKey, lastScore);
    }
    public static ScoreKeeper GetScoreKeeper()
    {
        return GameObject.FindGameObjectWithTag("ScoreKeeper").GetComponent<ScoreKeeper>();
    }
}
