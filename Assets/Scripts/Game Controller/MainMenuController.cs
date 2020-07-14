using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame() {
        SceneManager.LoadScene("4_GameScene");
    }

    public void GoToHighScoreMenu() {
        SceneManager.LoadScene("2_HighScore");
    }

    public void GoToOptionsMenu() {
        SceneManager.LoadScene("3_Options");
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void MusicButton() {
        
    }
}
