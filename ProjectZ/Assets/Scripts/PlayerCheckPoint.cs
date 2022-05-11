using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckPoint : MonoBehaviour
{

    private Animator animator;

    public void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            collision.GetComponent<PlayerState>().ChangeRespawnPosition(gameObject);
            animator.SetTrigger("SetRespawn");
        }
    }
}
