using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public List<GameObject> ItemList = new List<GameObject>();


    void OptionSelectedMainMenu()
    {
        ItemList[0].SetActive(true);
        ItemList[1].SetActive(true);
        //ItemList[2].SetActive(true);
        //ItemList[3].SetActive(true);
        //ItemList[4].SetActive(true);
        //ItemList[5].SetActive(true);
        //ItemList[0].SetActive(false);
        //ItemList[1].SetActive(false);
        //ItemList[2].SetActive(false);
        //ItemList[3].SetActive(false);
        //ItemList[4].SetActive(false);
        //ItemList[5].SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
