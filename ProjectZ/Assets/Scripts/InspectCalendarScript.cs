using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectCalendarScript : MonoBehaviour
{
    [SerializeField] private GameObject inspectCalendarSign;
    private SpriteRenderer inspectCalendarSprite;

    private float startTime = 0f;
    [SerializeField] private float holdTime = 2.0f;
    private float timer = 0f;

    private bool held = false;

    private int interacted;

    private void Start()
    {
        inspectCalendarSprite = inspectCalendarSign.GetComponent<SpriteRenderer>();
        inspectCalendarSprite.enabled = false;
    }

    private void Update()
    {

        interacted = PlayerPrefs.GetInt("IsCalendarSearched");

        if (Input.GetKeyDown(KeyCode.E))
        {
            held = true;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            held = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") == true)
        {
            inspectCalendarSprite.enabled = true;

            if (held == true && interacted > 0)
            {
                inspectCalendarSprite.enabled = false;
                GameObserver.CalendarInteraction(1);
                GameObserver.CluesCollected(PlayerPrefs.GetInt("CluesCollected") + 1);
                UI_CluesScript.ShowCalendar();
            } else if (held == true && interacted == 0)
            {
                inspectCalendarSprite.enabled = false;
                UI_CluesScript.ShowCalendar();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inspectCalendarSprite.enabled = false;
        UI_CluesScript.HideCalendar();
    }
}
