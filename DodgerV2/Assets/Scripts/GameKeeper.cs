using UnityEngine;
using Unity.Entities;
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

    [SerializeField]
    float gameTime = 0f;
    public float GameTime => gameTime;

    void Start()
    {
        StartRound();
    }

    void Update()
    {
        gameTime += Time.deltaTime;
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
    public void SpawnPopupText(Vector2 worldPosition, string text, Color color)
    {
        hud.SpawnPopupText(worldPosition, text, color);
    }

    //Starts a new round.
    public void StartRound()
    {
        scoreKeeper.ResetCurrentScore();

        currentPlayerHealth = MaxPlayerHealth;

        gameTime = 0f;
    }

    //Ends the current round.
    public void EndRound()
    {
        scoreKeeper.SaveScores();

        //Destroy all entities.
        EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        entityManager.DestroyEntity(entityManager.UniversalQuery);

        gameTime = 0f;
        gameData.GoToMainMenuScene();
    }

    //Returns GameKeeper object.
    public static GameKeeper GetGameKeeper()
    {
        return GameObject.FindGameObjectWithTag("GameKeeper").GetComponent<GameKeeper>();
    }
}
