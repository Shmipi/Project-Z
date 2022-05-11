using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Health : MonoBehaviour {

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private float timer = 0f;
    [SerializeField] private float timeBeforeReset;
    private bool isUsingHealthPickup = false;

    PlayerState playerScript;


    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isUsingHealthPickup == true)
        {
            timer += Time.deltaTime;
            if (timer >= timeBeforeReset)
            {
                timer = 0f;
                isUsingHealthPickup = false;
                spriteRenderer.enabled = true;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isUsingHealthPickup == false)
        {
            if (collision.CompareTag("Player") == true)
            {
                if (playerScript == null)
                {
                    playerScript = collision.GetComponent<PlayerState>();
                }
                isUsingHealthPickup = true;
                playerScript.oneUp();
                audioSource.PlayOneShot(audioClip);
                spriteRenderer.enabled = false;
            }
        }
    }
}