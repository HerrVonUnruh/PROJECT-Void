using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenue : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenueUI;

    // Update is called once per frame
    private void Start()
    {
        PauseMenueUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7) )

        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume ()
    {
        PauseMenueUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        
    }

    void Pause()
    {
        PauseMenueUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
