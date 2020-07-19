using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerPreferences
{
    public static string EasyDifficulty = "EasyDifficulty";
    public static string MediumDifficulty = "MediumDifficulty";
    public static string HardDifficulty = "HardDifficulty";

    public static string EasyDifficultyHighScore = "EasyDifficultyHighScore";
    public static string MediumDifficultyHighScore = "MediumDifficultyHighScore";
    public static string HardDifficultyHighScore = "HardDifficultyHighScore";

    public static string EasyDifficultyCoinScore = "EasyDifficultyCoinScore";
    public static string MediumDifficultyCoinScore = "MediumDifficultyCoinScore";
    public static string HardDifficultyCoinScore = "HardDifficultyCoinScore";

    public static string IsMusicOn = "IsMusicOn";


    // NOTE we are going to use integers to represent boolean variables
    // 0 - false, 1 - true

    public static int GetMusicState() {
        return PlayerPrefs.GetInt(PlayerPreferences.IsMusicOn);
    }

    // 0 is off and 1 is on
    public static void SetMusicState(int state) {
        PlayerPrefs.SetInt(PlayerPreferences.IsMusicOn, state);
    }

    // States
    // Method for getting easy difficulty state
    public static int GetEasyDifficultyState() {
        return PlayerPrefs.GetInt(PlayerPreferences.EasyDifficulty);
    }

    // Method for setting easy difficulty state
    public static void SetEasyDifficulty(int state) {
        PlayerPrefs.SetInt(PlayerPreferences.EasyDifficulty, state);
    }

    // Method for getting medium difficulty state
    public static int GetMediumDifficultyState() {
        return PlayerPrefs.GetInt(PlayerPreferences.MediumDifficulty);
    }

    // Method for setting medium difficulty state
    public static void SetMediumDifficulty(int state) {
        PlayerPrefs.SetInt(PlayerPreferences.MediumDifficulty, state);
    }

    // Method for getting hard difficulty state
    public static int GetHardDifficultyState() {
        return PlayerPrefs.GetInt(PlayerPreferences.HardDifficulty);
    }

    // Method for setting hard difficulty state
    public static void SetHardDifficulty(int state) {
        PlayerPrefs.SetInt(PlayerPreferences.HardDifficulty, state);
    }

    // High score
    // Method for getting easy difficulty high score
    public static int GetEasyDifficultyHighScore() {
        return PlayerPrefs.GetInt(PlayerPreferences.EasyDifficultyHighScore);
    }

    // Method for setting easy difficulty high score
    public static void SetEasyDifficultyHighScore(int state) {
        PlayerPrefs.SetInt(PlayerPreferences.EasyDifficultyHighScore, state);
    }

    // Method for getting medium difficulty high score
    public static int GetMediumDifficultyHighScore() {
        return PlayerPrefs.GetInt(PlayerPreferences.MediumDifficultyHighScore);
    }

    // Method for setting medium difficulty high score
    public static void SetMediumDifficultyHighScore(int state) {
        PlayerPrefs.SetInt(PlayerPreferences.MediumDifficultyHighScore, state);
    }

    // Method for getting hard difficulty high score
    public static int GetHardDifficultyHighScore() {
        return PlayerPrefs.GetInt(PlayerPreferences.HardDifficultyHighScore);
    }

    // Method for setting hard difficulty high score
    public static void SetHardDifficultyHighScore(int state) {
        PlayerPrefs.SetInt(PlayerPreferences.HardDifficultyHighScore, state);
    }

    // Coin score
    // Method for getting easy difficulty coin score
    public static int GetEasyDifficultyCoinScore() {
        return PlayerPrefs.GetInt(PlayerPreferences.EasyDifficultyCoinScore);
    }

    // Method for setting easy difficulty coin score
    public static void SetEasyDifficultyCoinScore(int state) {
        PlayerPrefs.SetInt(PlayerPreferences.EasyDifficultyCoinScore, state);
    }

    // Method for getting medium difficulty coin score
    public static int GetMediumDifficultyCoinScore() {
        return PlayerPrefs.GetInt(PlayerPreferences.MediumDifficultyCoinScore);
    }

    // Method for setting medium difficulty coin score
    public static void SetMediumDifficultyCoinScore(int state) {
        PlayerPrefs.SetInt(PlayerPreferences.MediumDifficultyCoinScore, state);
    }

    // Method for getting hard difficulty coin score
    public static int GetHardDifficultyCoinScore() {
        return PlayerPrefs.GetInt(PlayerPreferences.HardDifficultyCoinScore);
    }

    // Method for setting hard difficulty coin score
    public static void SetHardDifficultyCoinScore(int state) {
        PlayerPrefs.SetInt(PlayerPreferences.HardDifficultyCoinScore, state);
    }
}
