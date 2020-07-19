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

    public void CheckGameStatus(int score, int coinScore, int lifeScore) {
        if(lifeScore < 0) {
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
