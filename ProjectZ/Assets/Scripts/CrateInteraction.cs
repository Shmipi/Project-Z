using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateInteraction : MonoBehaviour
{
    [SerializeField] private GameObject searchCrateSign;
    private SpriteRenderer searchCrateSprite;

    private float startTime = 0f;
    [SerializeField] private float holdTime = 2.0f;
    private float timer = 0f;

    private bool held = false;

    private int isOpened;

    private void Start()
    {
        searchCrateSprite = searchCrateSign.GetComponent<SpriteRenderer>();
        searchCrateSprite.enabled = false;
    }

    private void Update()
    {

        isOpened = PlayerPrefs.GetInt("IsCrateSearched");

        if (Input.GetKeyDown(KeyCode.E))
        {
            startTime = Time.time;
            timer = startTime;
        }

        if (Input.GetKey(KeyCode.E) && held == false)
        {
            timer += Time.deltaTime;

            if (timer > (startTime + holdTime))
            {
                held = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            held = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") == true && isOpened < 1)
        {
            searchCrateSprite.enabled = true;

            if (held == true)
            {
                searchCrateSprite.enabled = false;
                GameObserver.SearchCrate(1);
                GameObserver.CluesCollected(PlayerPrefs.GetInt("CluesCollected") + 1);
                UI_CluesScript.ShowZSide();
            }
        }
        else if (collision.CompareTag("Player") == true && isOpened == 1)
        {
            UI_CluesScript.ShowZSide();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        searchCrateSprite.enabled = false;
        UI_CluesScript.HideZSide();
    }
}
