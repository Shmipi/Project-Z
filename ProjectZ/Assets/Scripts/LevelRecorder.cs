using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelRecorder : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObserver.SaveLevelToMemory(SceneManager.GetActiveScene().buildIndex);
    }
}
