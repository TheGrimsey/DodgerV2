using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    //Cached ScoreKeeper
    ScoreKeeper scoreKeeper;

    [Header("UI Components")]
    //Text widget that should hold score text.
    public Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreKeeper = ScoreKeeper.GetScoreKeeper();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = scoreKeeper.CurrentScore.ToString();
    }
}
