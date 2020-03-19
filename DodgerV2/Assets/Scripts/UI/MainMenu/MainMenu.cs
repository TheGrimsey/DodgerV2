using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public ScoreKeeper scoreKeeper;

    public Text highScoreText;
    public Text lastScoreText;

    public GameObject shareButton;

    [MultilineAttribute]
    public string ShareText = "My highscore on #DodgerV2 is {0} can you beat it? \n\n" +
                              "Download #DodgerV2 on the google play store!"; 

    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = scoreKeeper.HighScore.ToString();

        lastScoreText.text = scoreKeeper.LastScore.ToString();

        if(!Application.isMobilePlatform)
        {
            if(shareButton != null)
            {
                shareButton.SetActive(false);
            }
        }
    }

    public void OnClickedShare()
    {
        StartCoroutine(Share());
    }
    IEnumerator Share()
    {
        yield return new WaitForEndOfFrame();

        NativeShare nativeShare = new NativeShare();
        nativeShare.SetTitle("Share Highscore.");
        nativeShare.SetText(string.Format(ShareText, scoreKeeper.HighScore));
        nativeShare.Share();
    }
}
