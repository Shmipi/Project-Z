using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Camera_Follow : MonoBehaviour {

    GameObject followTarget;
    private Vector3 offset = new Vector3(0f, 1f, -5f);

    public float smoothSpeed = 0.1f;

    // Start is called before the first frame update
    void Start() {
        followTarget = GameObject.Find("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desiredPosition = followTarget.transform.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(gameObject.transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        gameObject.transform.position = smoothPosition;
    }
}
