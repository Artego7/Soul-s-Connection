using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Proximamente : MonoBehaviour
{
    private void Awake()
    {
        Invoke("GoLevelSelector", 4f);
    }
    void GoLevelSelector()
    {
        SceneManager.LoadScene("Level_Selector");
    }
}
