using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameObserver : MonoBehaviour
{
    public static void SaveCoinsToMemory(int amount)
    {
        PlayerPrefs.SetInt("CoinAmount", PlayerPrefs.GetInt("CoinAmount") + amount);
    }

    public static void SaveLevelToMemory(int levelIndex)
    {
        PlayerPrefs.SetInt("LevelInt", levelIndex);
    }

    public static void SaveKeyToMemory(int isKeyTaken)
    {
        PlayerPrefs.SetInt("IsKeyTaken", isKeyTaken);
    }

    public static void SaveCrowbarToMemory(int isCrowbarTaken)
    {
        PlayerPrefs.SetInt("IsCrowbarTaken", isCrowbarTaken);
    }

    public static void CluesCollected(int cluesCollected)
    {
        PlayerPrefs.SetInt("CluesCollected", cluesCollected);
    }

    public static void SearchedCabinet(int isCabinetSearched)
    {
        PlayerPrefs.SetInt("IsCabinetSearched", isCabinetSearched);
    }

    public static void SearchBoxesOne (int areBoxesOneSearched)
    {
        PlayerPrefs.SetInt("AreBoxesOneSearched", areBoxesOneSearched);
    }

    public static void SearchBoxesTwo (int areBoxesTwoSearched)
    {
        PlayerPrefs.SetInt("AreBoxesTwoSearched", areBoxesTwoSearched);
    }

    public static void SearchCrate (int isCrateSearched)
    {
        PlayerPrefs.SetInt("IsCrateSearched", isCrateSearched);
    }

    public static void CalendarInteraction (int isCalendarSearched)
    {
        PlayerPrefs.SetInt("isCalendarSearched", isCalendarSearched);
    }
}
