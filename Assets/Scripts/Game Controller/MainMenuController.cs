using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private Button musicBtn;

    [SerializeField]
    private Sprite[] musicIcons;

    // Start is called before the first frame update
    void Awake()
    {
        CheckToPlayTheMusic();
    }

    private void CheckToPlayTheMusic() {
        if(PlayerPreferences.GetMusicState() == 1) {
            MusicManager.instance.PlayMusic(true);
            musicBtn.image.sprite = musicIcons[1];
        } else {
            MusicManager.instance.PlayMusic(false);
            musicBtn.image.sprite = musicIcons[0];
        }
    }

    public void StartGame() {
        GameManager.instance.GameStartedFromMainMenu(true);
        //SceneManager.LoadScene("4_GameScene");
        SceneFader.instance.LoadLevel("4_GameScene");
    }

    public void GoToHighScoreMenu() {
        //SceneManager.LoadScene("2_HighScore");
        SceneFader.instance.LoadLevel("2_HighScore");
    }

    public void GoToOptionsMenu() {
        //SceneManager.LoadScene("3_Options");
        SceneFader.instance.LoadLevel("3_Options");
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void MusicButton() {
        if(PlayerPreferences.GetMusicState() == 1) {
            PlayerPreferences.SetMusicState(0);
            musicBtn.image.sprite = musicIcons[0];
            MusicManager.instance.PlayMusic(false);
        } else {
            PlayerPreferences.SetMusicState(1);
            musicBtn.image.sprite = musicIcons[1];
            MusicManager.instance.PlayMusic(true);
            
        }
    }
}
