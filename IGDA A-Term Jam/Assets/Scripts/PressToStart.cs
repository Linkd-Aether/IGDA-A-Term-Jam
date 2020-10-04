using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressToStart : MonoBehaviour
{
    private int timeToWait;
    // Start is called before the first frame update
    void Start()
    {
        timeToWait = 180;
    }

    // Update is called once per frame
    void Update()
    {
        timeToWait--;
        if(timeToWait <= 0)
        {
            if (false) SceneManager.LoadScene("Game");
        }
    }
}
