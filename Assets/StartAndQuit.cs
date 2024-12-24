using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartAndQuit : MonoBehaviour
{
    public bool Startgame;
    public bool Quitgame;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
