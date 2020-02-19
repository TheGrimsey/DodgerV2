using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public ScoreKeeper scoreKeeper;

    public Text highScoreText;
    public Text lastScoreText;

    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = scoreKeeper.HighScore.ToString();

        lastScoreText.text = scoreKeeper.LastScore.ToString();
    }
}
