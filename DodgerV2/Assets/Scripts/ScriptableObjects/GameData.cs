using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class GameData : ScriptableObject
{
    public string GameMapName = "";

    public string MainMenuMapName = "";

    public void GoToGameScene()
    {
        SceneManager.LoadScene(GameMapName, LoadSceneMode.Single);
    }

    public void GoToMainMenuScene()
    {
        SceneManager.LoadScene(MainMenuMapName, LoadSceneMode.Single);
    }
}
