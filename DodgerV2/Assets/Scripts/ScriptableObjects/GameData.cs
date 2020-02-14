using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class GameData : ScriptableObject
{
    public string GameMapName = "";

    public string MainMenuMapName = "";

    public void GoToGameScene()
    {
        SceneManager.LoadScene(GameMapName);
    }

    public void GoToMainMenuScene()
    {
        SceneManager.LoadScene(MainMenuMapName);
    }
}
