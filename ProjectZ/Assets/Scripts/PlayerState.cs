using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerState : MonoBehaviour {

    public int healthPoints = 2;
    public int initialHealthPoints = 2;

    public int coinAmount = 0;

    private GameObject respawnPosition;
    [SerializeField] private GameObject startPosition;
    [SerializeField] private GameObject startPositionOnReEnter;
    [SerializeField] private bool useStartPosition = true;

    // Start is called before the first frame update
    void Start() {
        healthPoints = initialHealthPoints;

        if (SceneManager.GetActiveScene().buildIndex < PlayerPrefs.GetInt("LevelInt")) {
            useStartPosition = false;
        }

        if (useStartPosition == true) {
            gameObject.transform.position = startPosition.transform.position;
        } else
        {
            gameObject.transform.position = startPositionOnReEnter.transform.position;
        }
       
        respawnPosition = startPosition;
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void DoHarm(int DoHarmByThisMuch) {
        healthPoints -= DoHarmByThisMuch;
        if (healthPoints <= 0) {
            Respawn();
        }
    }

    public void Respawn() {
        healthPoints = initialHealthPoints;
        gameObject.transform.position = respawnPosition.transform.position;
    }

    public void oneUp() {
        healthPoints = initialHealthPoints;
    }

    public void CoinPickup() {
        coinAmount++;
    }

    public void ChangeRespawnPosition(GameObject newRespawnPosition)
    {
        respawnPosition = newRespawnPosition;
    }

}
