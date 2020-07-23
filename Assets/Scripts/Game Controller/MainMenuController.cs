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
    void Start()
    {
        CheckToPlayTheMusic();
    }

    private void CheckToPlayTheMusic() {
        if(PlayerPreferences.GetMusicState() == 1) {
            MusicManager.instance.PlayMusic(true);
            musicBtn.image.sprite = musicIcons[0];
        } else {
            MusicManager.instance.PlayMusic(false);
            musicBtn.image.sprite = musicIcons[1];
        }
    }

    public void StartGame() {
        GameManager.instance.GameStartedFromMainMenu(true);
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
        if(PlayerPreferences.GetMusicState() == 1) {
            PlayerPreferences.SetMusicState(0);
            MusicManager.instance.PlayMusic(false);
            musicBtn.image.sprite = musicIcons[0];
        } else if(PlayerPreferences.GetMusicState() == 0) {
            PlayerPreferences.SetMusicState(1);
            MusicManager.instance.PlayMusic(true);
            musicBtn.image.sprite = musicIcons[1];
        }
    }
}
