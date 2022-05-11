using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    [SerializeField] private GameObject openDrawer;
    [SerializeField] private GameObject closeDrawer;
    private SpriteRenderer openDrawerRenderer;
    private SpriteRenderer closeDrawerRenderer;

    [SerializeField] private GameObject searchDrawerSign;
    private SpriteRenderer searchDrawerSprite;

    private float startTime = 0f;
    [SerializeField] private float holdTime = 2.0f;
    private float timer = 0f;

    private bool held = false;

    private int isOpened;

    private void Start()
    {
        openDrawerRenderer = openDrawer.GetComponent<SpriteRenderer>();
        openDrawerRenderer.enabled = false;

        closeDrawerRenderer = closeDrawer.GetComponent<SpriteRenderer>();
        closeDrawerRenderer.enabled = true;

        searchDrawerSprite = searchDrawerSign.GetComponent<SpriteRenderer>();
        searchDrawerSprite.enabled = false;

        if (isOpened == 1)
        {
            openDrawerRenderer.enabled = true;
            closeDrawerRenderer.enabled = false;
        }

    }

    private void Update()
    {

        isOpened = PlayerPrefs.GetInt("IsCabinetSearched");

        if (Input.GetKeyDown(KeyCode.E))
        {
            startTime = Time.time;
            timer = startTime;
        }

        if (Input.GetKey(KeyCode.E) && held == false)
        {
            timer += Time.deltaTime;

            if (timer > (startTime + holdTime)) {
                held = true;
            }
        } 

        if(Input.GetKeyUp(KeyCode.E))
        {
            held = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") == true && isOpened < 1)
        {
            searchDrawerSprite.enabled = true;

            if (held == true)
            {
                openDrawerRenderer.enabled = true;
                closeDrawerRenderer.enabled = false;
                searchDrawerSprite.enabled = false;
                GameObserver.SearchedCabinet(1);
                GameObserver.CluesCollected(PlayerPrefs.GetInt("CluesCollected") + 1);
                UI_CluesScript.ShowMobile();
            }
        } else if (collision.CompareTag("Player") == true && isOpened == 1)
        {
            UI_CluesScript.ShowMobile();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        searchDrawerSprite.enabled = false;
        UI_CluesScript.HideMobile();
    }
}
