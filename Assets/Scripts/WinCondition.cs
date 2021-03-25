using UnityEngine.SceneManagement;
using UnityEngine;

public class WinCondition : MonoBehaviour
{

    public string nextLevelName;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(nextLevelName, LoadSceneMode.Single);
    }
}
