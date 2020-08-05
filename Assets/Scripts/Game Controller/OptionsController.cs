using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour
{
    [SerializeField]
    private GameObject easySign;
    [SerializeField]
    private GameObject mediumSign;
    [SerializeField]
    private GameObject hardSign;

    // Start is called before the first frame update
    void Start()
    {
        SetTheDifficulty();
    }

    private void SetInitialDifficulty(string difficulty) {
        switch(difficulty) {
            case "easy":
                mediumSign.SetActive(false);
                hardSign.SetActive(false);
                break;

            case "medium":
                easySign.SetActive(false);
                hardSign.SetActive(false);
                break;

            case "hard":
                easySign.SetActive(false);
                mediumSign.SetActive(false);
                break;
        }
    }

    private void SetTheDifficulty() {
        if(PlayerPreferences.GetEasyDifficultyState() == 1) {
            SetInitialDifficulty("easy");
        }

        if(PlayerPreferences.GetMediumDifficultyState() == 1) {
            SetInitialDifficulty("medium");
        }

        if(PlayerPreferences.GetHardDifficultyState() == 1) {
            SetInitialDifficulty("hard");
        }
    }

    public void EasyDifficulty() {
        PlayerPreferences.SetEasyDifficultyState(1);
        PlayerPreferences.SetMediumDifficultyState(0);
        PlayerPreferences.SetHardDifficultyState(0);

        easySign.SetActive(true);
        mediumSign.SetActive(false);
        hardSign.SetActive(false);
    }

    public void MediumDifficulty() {
        PlayerPreferences.SetEasyDifficultyState(0);
        PlayerPreferences.SetMediumDifficultyState(1);
        PlayerPreferences.SetHardDifficultyState(0);

        easySign.SetActive(false);
        mediumSign.SetActive(true);
        hardSign.SetActive(false);
    }

    public void HardDifficulty() {
        PlayerPreferences.SetEasyDifficultyState(0);
        PlayerPreferences.SetMediumDifficultyState(0);
        PlayerPreferences.SetHardDifficultyState(1);

        easySign.SetActive(false);
        mediumSign.SetActive(false);
        hardSign.SetActive(true);
    }

    public void GoToMainMenu() {
        //SceneManager.LoadScene("1_MainMenu");
        SceneFader.instance.LoadLevel("1_MainMenu");
    }
}
