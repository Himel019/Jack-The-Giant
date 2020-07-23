using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoreController : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text coinText;

    // Start is called before the first frame update
    void Start()
    {
        SetScoreBasedOnDifficulty();
    }

    private void SetScore(int score, int coinScore) {
        scoreText.text = score.ToString();
        coinText.text = coinScore.ToString();
    }

    private void SetScoreBasedOnDifficulty() {

        if(PlayerPreferences.GetEasyDifficultyState() == 1) {
            SetScore(PlayerPreferences.GetEasyDifficultyHighScore(), PlayerPreferences.GetEasyDifficultyCoinScore());
        }

        if(PlayerPreferences.GetMediumDifficultyState() == 1) {
            SetScore(PlayerPreferences.GetMediumDifficultyHighScore(), PlayerPreferences.GetMediumDifficultyCoinScore());
        }

        if(PlayerPreferences.GetHardDifficultyState() == 1) {
            SetScore(PlayerPreferences.GetHardDifficultyHighScore(), PlayerPreferences.GetHardDifficultyCoinScore());
        }
    }

    public void GoToMainMenu() {
        SceneManager.LoadScene("1_MainMenu");
    }
}
