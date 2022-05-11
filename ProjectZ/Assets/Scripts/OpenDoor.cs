using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private int levelToLoad;
    [SerializeField] private GameObject doorSign;
    private SpriteRenderer doorSignRenderer;
    private bool isPressed = false;

    private void Start()
    {
        doorSignRenderer = doorSign.GetComponent<SpriteRenderer>();
        doorSignRenderer.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isPressed = true;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            isPressed = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") == true)
        {
            doorSignRenderer.enabled = true;
        }

        if (collision.CompareTag("Player") == true && isPressed == true)
        {
            GameObserver.SaveCoinsToMemory(collision.GetComponent<PlayerState>().coinAmount);
            SceneManager.LoadScene(levelToLoad);
        }
    }

    private void OnTriggerExit2D()
    {
        doorSignRenderer.enabled = false;
    }
}
