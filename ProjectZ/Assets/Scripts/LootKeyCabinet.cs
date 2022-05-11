using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootKeyCabinet : MonoBehaviour
{
    [SerializeField] private GameObject openDrawer;
    [SerializeField] private GameObject closeDrawer;
    private SpriteRenderer openDrawerRenderer;
    private SpriteRenderer closeDrawerRenderer;

    [SerializeField] private GameObject keyAcquiredSign;
    [SerializeField] private GameObject searchDrawerSign;
    [SerializeField] private GameObject cabinetJammedSign;
    private SpriteRenderer keyAcquiredSprite;
    private SpriteRenderer searchDrawerSprite;
    private SpriteRenderer cabinetJammedSprite;

    private float startTime = 0f;
    [SerializeField] private float holdTime = 2.0f;
    private float timer = 0f;

    private bool held = false;

    private int isKeyTaken;
    private int isCrowbarTaken;

    private void Start()
    {
        isCrowbarTaken = PlayerPrefs.GetInt("IsCrowbarTaken");

        openDrawerRenderer = openDrawer.GetComponent<SpriteRenderer>();
        openDrawerRenderer.enabled = false;

        closeDrawerRenderer = closeDrawer.GetComponent<SpriteRenderer>();
        closeDrawerRenderer.enabled = true;

        keyAcquiredSprite = keyAcquiredSign.GetComponent<SpriteRenderer>();
        keyAcquiredSprite.enabled = false;

        searchDrawerSprite = searchDrawerSign.GetComponent<SpriteRenderer>();
        searchDrawerSprite.enabled = false;

        cabinetJammedSprite = cabinetJammedSign.GetComponent<SpriteRenderer>();
        cabinetJammedSprite.enabled = false;

        if (isKeyTaken > 0)
        {
            openDrawerRenderer.enabled = true;
            closeDrawerRenderer.enabled = false;
        }
    }

    private void Update()
    {

        isKeyTaken = PlayerPrefs.GetInt("IsKeyTaken");

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

        if (collision.CompareTag("Player") == true && isKeyTaken > 0)
        {
            keyAcquiredSprite.enabled = true;

        } else if(collision.CompareTag("Player") == true && isCrowbarTaken > 0)
        {
            searchDrawerSprite.enabled = true;

            if (held == true)
            {
                openDrawerRenderer.enabled = true;
                closeDrawerRenderer.enabled = false;
                keyAcquiredSprite.enabled = true;
                searchDrawerSprite.enabled = false;
                GameObserver.SaveKeyToMemory(1);

                UI_PickupsScript.EnableKey();
            }
        } else if (collision.CompareTag("Player") == true && isCrowbarTaken == 0) {
            cabinetJammedSprite.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        keyAcquiredSprite.enabled = false;
        searchDrawerSprite.enabled = false;
        cabinetJammedSprite.enabled = false;
    }
}
