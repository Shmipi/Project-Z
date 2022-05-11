using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_CluesScript : MonoBehaviour
{

    [SerializeField] private GameObject mobile;
    private static Image mobileImage;

    [SerializeField] private GameObject zSerumNote;
    private static Image zSerumNoteImage;

    [SerializeField] private GameObject dDayNote;
    private static Image dDayNoteImage;

    [SerializeField] private GameObject zSerumSideNote;
    private static Image zSerumSideNoteImage;

    [SerializeField] private GameObject calendarClose;
    private static Image calendarCloseImage;

    void Start()
    {
        mobileImage = mobile.GetComponent<Image>();
        mobileImage.enabled = false;

        zSerumNoteImage = zSerumNote.GetComponent<Image>();
        zSerumNoteImage.enabled = false;

        dDayNoteImage = dDayNote.GetComponent<Image>();
        dDayNoteImage.enabled = false;

        zSerumSideNoteImage = zSerumSideNote.GetComponent<Image>();
        zSerumSideNoteImage.enabled = false;

        calendarCloseImage = calendarClose.GetComponent<Image>();
        calendarCloseImage.enabled = false;
    }

    public static void ShowMobile()
    {
        mobileImage.enabled = true;
    }

    public static void HideMobile()
    {
        mobileImage.enabled = false;
    }

    public static void ShowZNote()
    {
        zSerumNoteImage.enabled = true;
    }

    public static void HideZNote()
    {
        zSerumNoteImage.enabled = false;
    }

    public static void ShowDNote()
    {
        dDayNoteImage.enabled = true;
    }

    public static void HideDNote()
    {
        dDayNoteImage.enabled = false;
    }

    public static void ShowZSide()
    {
        zSerumSideNoteImage.enabled = true;
    }

    public static void HideZSide()
    {
        zSerumSideNoteImage.enabled = false;
    }

    public static void ShowCalendar()
    {
        calendarCloseImage.enabled = true;
    }

    public static void HideCalendar()
    {
        calendarCloseImage.enabled = false;
    }
}
