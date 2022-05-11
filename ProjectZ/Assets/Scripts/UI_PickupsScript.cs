using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PickupsScript : MonoBehaviour
{
    private int crowbarTaken;
    private int keyTaken;

    [SerializeField] private GameObject crowbar;
    private static Image crowbarImage;

    [SerializeField] private GameObject key;
    private static Image keyImage;

    void Start()
    {
        crowbarTaken = PlayerPrefs.GetInt("IsCrowbarTaken");
        keyTaken = PlayerPrefs.GetInt("IsKeyTaken");

        crowbarImage = crowbar.GetComponent<Image>();
        keyImage = key.GetComponent<Image>();

        if (crowbarTaken > 0)
        {
            crowbarImage.enabled = true;
        } else
        {
            crowbarImage.enabled = false;
        }

        if (keyTaken > 0)
        {
            keyImage.enabled = true;
        }
        else
        {
            keyImage.enabled = false;
        }
    }

    public static void EnableCrowbar()
    {
        crowbarImage.enabled = true;
    }

    public static void EnableKey()
    {
        keyImage.enabled = true;
    }
}
