using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseMenu;

    public NinjaCharacer nj;

    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //GameState currentGameState = GameStateManager.Instance.CurrentGameState;
            //GameState newGameState = currentGameState == GameState.Gameplay
            //    ? GameState.Paused
            //    : GameState.Gameplay;
            //GameStateManager.Instance.setState(newGameState);

            if (!isPaused)
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
                isPaused = true;
            }
            else if (isPaused)
            {
                if(nj.slowingDownTime == true)
                {
                    Time.timeScale = 0.7f;
                }
                else if(nj.slowingDownTime == false)
                {
                    Time.timeScale = 1;

                }
                pauseMenu.SetActive(false);
                isPaused = false;
            }
        }

    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
    public void RestartGame(string iLevelToLoad)
    {
        SceneManager.LoadScene(iLevelToLoad);
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }
    public void exitWholeGame()
    {
        Application.Quit();
    }
}
