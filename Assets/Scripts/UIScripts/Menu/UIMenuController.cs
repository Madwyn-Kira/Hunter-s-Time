using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
