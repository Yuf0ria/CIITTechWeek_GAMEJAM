using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    void Update()
    {
        
    }

    public void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Continue();
        }
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
