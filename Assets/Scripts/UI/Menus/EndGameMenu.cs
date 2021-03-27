using UnityEngine;
using UnityEngine.SceneManagement;
public class EndGameMenu : MonoBehaviour
{
    public string nextSceneToLoad = "MainMenu";
    
    public GameObject gameOverMenu;
    public GameObject gameOverSettings;
    public GameObject winMenu;
    public GameObject winMenuSettings;

    public void Retry()
    {
        Scene scene = SceneManager.GetActiveScene();

        Time.timeScale = 1f;
        SceneManager.LoadScene(scene.name);
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nextSceneToLoad);
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        FindObjectOfType<PauseMenu>().settingsPanel = gameOverSettings;
    }

    public void GameWon()
    {
        winMenu.SetActive(true);
        FindObjectOfType<PauseMenu>().settingsPanel = winMenuSettings;
    }
}