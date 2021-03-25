using UnityEngine.SceneManagement;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<PauseMenu>().StopGame();
        FindObjectOfType<EndGameMenu>().GameWon();
    }
}
