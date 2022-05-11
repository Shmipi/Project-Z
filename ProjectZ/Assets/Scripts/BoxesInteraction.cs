using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxesInteraction : MonoBehaviour
{
    [SerializeField] private GameObject searchBoxesSign;
    private SpriteRenderer searchBoxesSprite;

    private float startTime = 0f;
    [SerializeField] private float holdTime = 2.0f;
    private float timer = 0f;

    private bool held = false;

    private int isOpened;

    private void Start()
    {
        searchBoxesSprite = searchBoxesSign.GetComponent<SpriteRenderer>();
        searchBoxesSprite.enabled = false;
    }

    private void Update()
    {

        isOpened = PlayerPrefs.GetInt("AreBoxesOneSearched");

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
            searchBoxesSprite.enabled = true;

            if (held == true)
            {
                searchBoxesSprite.enabled = false;
                GameObserver.SearchBoxesOne(1);
                GameObserver.CluesCollected(PlayerPrefs.GetInt("CluesCollected") + 1);
                UI_CluesScript.ShowZNote();
            }
        }
        else if (collision.CompareTag("Player") == true && isOpened == 1)
        {
            UI_CluesScript.ShowZNote();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        searchBoxesSprite.enabled = false;
        UI_CluesScript.HideZNote();
    }
}
