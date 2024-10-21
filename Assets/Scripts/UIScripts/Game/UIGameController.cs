using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGameController : MonoBehaviour
{
    public void GoMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
