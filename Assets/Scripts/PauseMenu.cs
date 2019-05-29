using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{

    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    // Use this for initialization

    void Start()
    {

    }

    //CHECK_WHAT_KEY_IS_USING//
    //KeyCode FetchKey()
    //{
    //    int e = System.Enum.GetNames(typeof(KeyCode)).Length;
    //    for (int i = 0; i < e; i++)
    //    {
    //        if (Input.GetKey((KeyCode)i))
    //        {
    //            return (KeyCode)i;
    //        }
    //    }
    //    return KeyCode.None;
    //}
    //print(FetchKey());

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start");
        Resume();
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Resume();
    }
    public void LoadLevelsMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level_Selector");
        Resume();
    }

}
