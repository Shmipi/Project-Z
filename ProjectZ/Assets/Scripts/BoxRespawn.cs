using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxRespawn : MonoBehaviour
{

    private Vector3 respawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        respawnPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        gameObject.transform.position = respawnPosition;
    }
}
