using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    [SerializeField]
    string Level;

    public void PlayGame()
    {
        SceneManager.LoadScene(Level);
    }
}
