using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeState : MonoBehaviour {

    public GameObject GameObjPlayer;
    Player playerScript;

    public GameObject SoulGround;
    public GameObject SoulCanvas;


    // Use this for initialization
    void Start () {
        playerScript = GameObjPlayer.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update () {
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
}
