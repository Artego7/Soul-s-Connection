using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    bool isGoToChange;
    // Start is called before the first frame update
    void Start()
    {
        isGoToChange = false;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeViewSide();
    }
    void ChangeViewSide()
    {
        float timer = Time.deltaTime;
        if (transform.eulerAngles.z >= 284  
            && transform.eulerAngles.z <= 286)
        {
            isGoToChange = false;
        }
        if (transform.eulerAngles.z >= 74
            && transform.eulerAngles.z <= 76)
        {
            isGoToChange = true;
        }
        if (isGoToChange)
        {
            transform.eulerAngles += new Vector3(0, 0, -(timer * 30));
        }
        if (!isGoToChange)
        {
            transform.eulerAngles += new Vector3(0, 0, (timer * 30));
        }
    }
}
