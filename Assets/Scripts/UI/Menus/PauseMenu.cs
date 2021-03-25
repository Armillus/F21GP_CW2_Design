using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject settingsPanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (gameIsPaused)
                Resume();
            else 
                Pause();
        }
    }

    public void Pause()
    {
        StopGame();
        ShowUI();
        gameIsPaused = true;
    }

    public void StopGame()
    {
        FindObjectOfType<Player>().enabled = false;
        FindObjectOfType<Wheel>().enabled = false;
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        ResumeGame();
        HideUI();
        gameIsPaused = false;
    }

    private void ResumeGame()
    {
        FindObjectOfType<Player>().enabled = true;
        FindObjectOfType<Wheel>().enabled = true;
        Time.timeScale = 1f;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    private void ShowUI()
    {
        pauseMenuUI.SetActive(true);
    }

    private void HideUI()
    {
        CloseSettings();
        pauseMenuUI.SetActive(false);
    }
}
