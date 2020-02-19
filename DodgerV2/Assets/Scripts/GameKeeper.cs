using UnityEngine;

public class GameKeeper : MonoBehaviour
{
    //GameData. Holds MainMenu and Game map names.
    public GameData gameData;

    //ScoreRewards. Holds score awarded for each action.
    public ScoreRewards scoreRewards;

    //ScoreKeeper. Holds current, highest & last score.
    public ScoreKeeper scoreKeeper;

    //HUD.
    public HUD hud;

    //The max health of the player.
    [SerializeField]
    int maxPlayerHealth = 3;
    public int MaxPlayerHealth => maxPlayerHealth;

    //The current health of the player.
    [SerializeField]
    int currentPlayerHealth = 3;
    public int PlayerHealth => currentPlayerHealth;

    void Awake()
    {
        StartRound();
    }

    //Called when a player is hit by an enemy.
    public void OnPlayerHit()
    {
        currentPlayerHealth--;

        if(currentPlayerHealth == 0)
        {
            EndRound();
        }
    }

    //Spawns a popuptext at worldPosition with text.
    public void SpawnPopupText(Vector2 worldPosition, string text)
    {
        hud.SpawnPopupText(worldPosition, text);
    }

    //Starts a new round.
    public void StartRound()
    {
        scoreKeeper.ResetCurrentScore();

        currentPlayerHealth = MaxPlayerHealth;
    }

    //Ends the current round.
    public void EndRound()
    {
        scoreKeeper.SaveScores();

        gameData.GoToMainMenuScene();
    }

    //Returns GameKeeper object.
    public static GameKeeper GetGameKeeper()
    {
        return GameObject.FindGameObjectWithTag("GameKeeper").GetComponent<GameKeeper>();
    }
}
