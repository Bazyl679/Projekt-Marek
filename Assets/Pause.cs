using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    [SerializeField] GameObject pause;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause.SetActive(true);
            Time.timeScale = 0f;
          
        }
    }

    public void Return()
    {
        SceneManager.LoadScene(0);
    }

    public void Resume()
    {
        pause.SetActive(false);
        Time.timeScale = 1f;
    }

}
