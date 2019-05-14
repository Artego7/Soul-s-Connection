using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_State : MonoBehaviour {

    public GameObject GameObjPlayer;
    Player playerScript;

    public GameObject Ground;
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
            Ground.SetActive(true);
            SoulGround.SetActive(false);
            SoulCanvas.SetActive(false);
        }
        else if (playerScript.isSoul)
        {
            Ground.SetActive(false);
            SoulGround.SetActive(true);
            SoulCanvas.SetActive(true);
        }

    }
}
