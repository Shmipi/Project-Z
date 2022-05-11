using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToNextLevel : MonoBehaviour
{
    [SerializeField] private int levelToLoad;

    [SerializeField] private GameObject doorLockedSign;
    [SerializeField] private GameObject openDoorSign;

    private SpriteRenderer doorLockedSprite;
    private SpriteRenderer openDoorSprite;

    private bool isPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        doorLockedSprite = doorLockedSign.GetComponent<SpriteRenderer>();
        openDoorSprite = openDoorSign.GetComponent<SpriteRenderer>();

        doorLockedSprite.enabled = false;
        openDoorSprite.enabled = false;
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
        if (collision.CompareTag("Player") == true && PlayerPrefs.GetInt("IsKeyTaken") == 1)
        {

            openDoorSprite.enabled = true;

            if (isPressed == true)
            {
                GameObserver.SaveKeyToMemory(0);
                GameObserver.SaveCrowbarToMemory(0);
                GameObserver.CluesCollected(0);
                GameObserver.SearchBoxesOne(0);
                GameObserver.SearchBoxesTwo(0);
                GameObserver.SearchedCabinet(0);
                GameObserver.SearchCrate(0);
                GameObserver.CalendarInteraction(0);
                SceneManager.LoadScene(levelToLoad);
            }

        } else if (collision.CompareTag("Player") == true && PlayerPrefs.GetInt("IsKeyTaken") != 1)
        {
            doorLockedSprite.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        openDoorSprite.enabled = false;
        doorLockedSprite.enabled = false;
    }
}
