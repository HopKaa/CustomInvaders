using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool _isPaused;
    [SerializeField] private GameObject _pausePanel;
    void Start()
    {
        _pausePanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(_isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        _pausePanel.SetActive(true);
        _isPaused = true;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
        _pausePanel.SetActive(false);
        _isPaused = false;
    }
}
