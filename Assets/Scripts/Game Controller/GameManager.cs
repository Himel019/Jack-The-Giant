using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private bool gameStartedFromMainMenu;
    private bool gameRestartedAfterPlayerDied;

    private int score;
    private int coinScore;
    private int lifeScore;

    private void Awake() {
        MakeInstance();
    }

    private void Start()
    {
        InitializeVariables();
    }

    private void OnEnable() {
        SceneManager.sceneLoaded += LevelWasLoaded;
    }

    private void OnDisable() {
        SceneManager.sceneLoaded -= LevelWasLoaded;
    }

    private void LevelWasLoaded(Scene scene, LoadSceneMode mode) {
        if(scene.name == "4_GameScene") {
            if(gameRestartedAfterPlayerDied) {
                GameplayController.instance.SetScore(score);
                GameplayController.instance.SetCoinScore(coinScore);
                GameplayController.instance.SetLifeScore(lifeScore);

                PlayerScore.scoreCount = score;
                PlayerScore.coinCount = coinScore;
                PlayerScore.lifeCount = lifeScore;
            } else if(gameStartedFromMainMenu) {
                GameplayController.instance.SetScore(0);
                GameplayController.instance.SetCoinScore(0);
                GameplayController.instance.SetLifeScore(2);

                PlayerScore.scoreCount = 0;
                PlayerScore.coinCount = 0;
                PlayerScore.lifeCount = 2;
            }
        }
    }

    private void MakeInstance() {
        if(instance != null) {
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void InitializeVariables() {

        if(!PlayerPrefs.HasKey("Game_Initialized")) {
            PlayerPreferences.SetEasyDifficultyState(0);
            PlayerPreferences.SetEasyDifficultyHighScore(0);
            PlayerPreferences.SetEasyDifficultyCoinScore(0);

            PlayerPreferences.SetMediumDifficultyState(1);
            PlayerPreferences.SetMediumDifficultyHighScore(0);
            PlayerPreferences.SetHardDifficultyCoinScore(0);

            PlayerPreferences.SetHardDifficultyState(0);
            PlayerPreferences.SetHardDifficultyHighScore(0);
            PlayerPreferences.SetHardDifficultyCoinScore(0);

            PlayerPreferences.SetMusicState(1);

            PlayerPrefs.SetInt("Game_Initialized", 123);
        }
    }

    public void CheckGameStatus(int score, int coinScore, int lifeScore) {
        if(lifeScore < 0) {

            if(PlayerPreferences.GetEasyDifficultyState() == 1) {
                int highScore = PlayerPreferences.GetEasyDifficultyHighScore();
                int coinHighScore = PlayerPreferences.GetEasyDifficultyCoinScore();

                if(highScore < score) {
                    PlayerPreferences.SetEasyDifficultyHighScore(score);
                }

                if(coinHighScore < coinScore) {
                    PlayerPreferences.SetEasyDifficultyCoinScore(coinScore);
                }
            }

            if(PlayerPreferences.GetMediumDifficultyState() == 1) {
                int highScore = PlayerPreferences.GetMediumDifficultyHighScore();
                int coinHighScore = PlayerPreferences.GetMediumDifficultyCoinScore();

                if(highScore < score) {
                    PlayerPreferences.SetMediumDifficultyHighScore(score);
                }

                if(coinHighScore < coinScore) {
                    PlayerPreferences.SetMediumDifficultyCoinScore(coinScore);
                }
            }

            if(PlayerPreferences.GetHardDifficultyState() == 1) {
                int highScore = PlayerPreferences.GetHardDifficultyHighScore();
                int coinHighScore = PlayerPreferences.GetHardDifficultyCoinScore();

                if(highScore < score) {
                    PlayerPreferences.SetHardDifficultyHighScore(score);
                }

                if(coinHighScore < coinScore) {
                    PlayerPreferences.SetHardDifficultyCoinScore(coinScore);
                }
            }

            gameStartedFromMainMenu = false;
            gameRestartedAfterPlayerDied = false;

            GameplayController.instance.GameOverShowPanel(score, coinScore);
        } else {
            this.score = score;
            this.coinScore = coinScore;
            this.lifeScore = lifeScore;

            gameStartedFromMainMenu = false;
            gameRestartedAfterPlayerDied = true;

            GameplayController.instance.PlayerDiedRestartTheGame();
        }
    }

    public void GameStartedFromMainMenu(bool value) {
        gameStartedFromMainMenu = value;
    }

    public void GameRestartedAfterPlayerDied(bool value) {
        gameRestartedAfterPlayerDied = value;
    }
}
