using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    public GameObject GameObjPlayer;
    Player playerScript;
    public GameObject SoulChange;
    public GameObject SoulAngleChange;


    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObjPlayer.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.isSoul)
        {
            SoulChange.SetActive(false);
            SoulAngleChange.SetActive(true);
        }
        if (!playerScript.isSoul)
        {
            SoulChange.SetActive(true);
            SoulAngleChange.SetActive(false);
        }
    }
}
