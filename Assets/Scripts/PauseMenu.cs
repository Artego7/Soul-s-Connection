using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseMenu : MonoBehaviour {

    GameObject pauseMenu;

	// Use this for initialization
	void Start () {
	}

    KeyCode FetchKey()
    {
        int e = System.Enum.GetNames(typeof(KeyCode)).Length;
        for (int i = 0; i < e; i++)
        {
            if (Input.GetKey((KeyCode)i))
            {
                return (KeyCode)i;
            }
        }
        return KeyCode.None;
    }

        // Update is called once per frame
        void Update () {
        print(FetchKey());
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("hola");
            pauseMenu.SetActive(true);
        }
	}
}
