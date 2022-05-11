using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Crowbar : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    private bool canPickUpCrowbar = true;

    private bool removeGameObject = false;
    private float timer = 0f;
    [SerializeField] private float timeBeforeDeletion = 1f;

    private int shouldCrowbarExist;

    private void Start()
    {
        shouldCrowbarExist = PlayerPrefs.GetInt("IsCrowbarTaken");
        if (shouldCrowbarExist > 0)
        {
            spriteRenderer.sprite = null;
            removeGameObject = true;
            canPickUpCrowbar = false;
        }
    }

    private void Update()
    {
        if (removeGameObject == true)
        {
            timer += Time.deltaTime;
            if (timer >= timeBeforeDeletion)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            if (canPickUpCrowbar == true)
            {
                GameObserver.SaveCrowbarToMemory(1);
                spriteRenderer.sprite = null;
                removeGameObject = true;
                canPickUpCrowbar = false;

                UI_PickupsScript.EnableCrowbar();
            }
        }
    }
}
