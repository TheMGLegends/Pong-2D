using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseMenuScript : MonoBehaviour
{
    private bool escapePressed = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!escapePressed)
            {
                Pause();
                escapePressed = true;
            }
            else
            {
                Back();
                escapePressed = false;
            }
        }
    }

    public void Quit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
        ChildObjects(true);
    }

    public void Back()
    {
        Time.timeScale = 1.0f;
        ChildObjects(false);
    }

    private void ChildObjects(bool activate)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(activate);
        }
    }
}