using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour   
{
    public bool isPaused=false;
    public string titleScene;
    public GameObject pauseMenu;
    public bool isDead=false;
    public GameObject deathMenu;
    public float menuTimer=2f;

    void Start()
    {

    }

    void Update()
    {
        if (isDead)
        {
            if (menuTimer>0)
            {
                menuTimer = menuTimer - Time.deltaTime;
                return;
            }
            deathMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ReturnToTitle()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(titleScene);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void PauseGame()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            isPaused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;

            Cursor.lockState = CursorLockMode.None;
        }
    }
}
