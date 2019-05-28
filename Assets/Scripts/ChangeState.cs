using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeState : MonoBehaviour
{

    public GameObject GameObjPlayer;
    Player playerScript;

    public GameObject SoulGround;
    public GameObject SoulCanvas;
    public GameObject DeadPanel;
    public GameObject DeadText;

    // Use this for initialization
    void Start()
    {
        playerScript = GameObjPlayer.GetComponent<Player>();
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        SoulState();
        DeadState();
        DeadState();
    }
    void SoulState()
    {
        if (!playerScript.isSoul)
        {
            SoulGround.SetActive(false);
            SoulCanvas.SetActive(false);
        }
        else if (playerScript.isSoul)
        {
            SoulGround.SetActive(true);
            SoulCanvas.SetActive(true);
        }
    }
    void DeadState()
    {
        if (playerScript.isDead)
        {
            DeadPanel.SetActive(true);
            DeadText.SetActive(true);
            Invoke("RestartGame", 4f);
        }
    }
    void RestartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
