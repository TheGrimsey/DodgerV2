using UnityEngine;

public class GameKeeper : MonoBehaviour
{
    public GameData gameData;

    public ScoreRewards scoreRewards;

    public ScoreKeeper scoreKeeper;

    public HUD hud;

    //The current health of the player.
    [SerializeField]
    int playerHealth = 3;
    public int PlayerHealth => playerHealth;

    void Awake()
    {
        StartRound();
    }

    public void OnPlayerHit()
    {
        playerHealth--;

        if(playerHealth == 0)
        {
            EndRound();
        }
    }

    public void SpawnPopupText(Vector2 worldPosition, string text)
    {
        hud.SpawnPopupText(worldPosition, text);
    }

    public void StartRound()
    {
        scoreKeeper.ResetCurrentScore();
    }

    public void EndRound()
    {
        scoreKeeper.SaveScores();

        gameData.GoToMainMenuScene();
    }

    public static GameKeeper GetGameKeeper()
    {
        return GameObject.FindGameObjectWithTag("GameKeeper").GetComponent<GameKeeper>();
    }
}
