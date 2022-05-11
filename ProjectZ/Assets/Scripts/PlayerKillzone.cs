using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKillzone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            collision.gameObject.GetComponent<PlayerState>().Respawn();
        }

        if (collision.CompareTag("Box") == true)
        {
            collision.gameObject.GetComponent<BoxRespawn>().Respawn();
        }
    }
}
