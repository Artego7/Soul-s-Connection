using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverInteraction : MonoBehaviour
{
    public GameObject lever;
    public GameObject door;
    BoxCollider2D CollDoor;

    bool isTouching;
    bool isActived;
    bool isOpenDoor;

    float startLeverEulerAngle;

    // Start is called before the first frame update
    void Start()
    {
        isTouching = false;
        isActived = false;
        isOpenDoor = false;
        startLeverEulerAngle = transform.eulerAngles.z;
        lever.transform.eulerAngles = new Vector3(0, 0, getLeverEulerAngleZ(40, startLeverEulerAngle));
        door.transform.position = new Vector3(8.68f, -3.16f, 0);
        CollDoor = door.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        OpenDoor();
    }

    void OpenDoor()
    {
        float timer = Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.E) && isTouching)
        {
            isActived = true;
        }
        if (isActived)
        {
            lever.transform.eulerAngles += new Vector3(0, 0, -(timer * 20));
            print(startLeverEulerAngle);
            if (lever.transform.eulerAngles.z >= getLeverEulerAngleZ(300, startLeverEulerAngle)
                && lever.transform.eulerAngles.z <= getLeverEulerAngleZ(320, startLeverEulerAngle))
            {
                lever.transform.eulerAngles = new Vector3(0, 0, getLeverEulerAngleZ(320, startLeverEulerAngle));
                isActived = false;
                isOpenDoor = true;
            }
        }
        if (isOpenDoor)
        {
            door.transform.position += new Vector3(0, timer, 0);
            CollDoor.isTrigger = true;
        }
        if (door.transform.position.y >= 0f)
        {
            isOpenDoor = false;
        }
    }

    float getLeverEulerAngleZ(float eulerA, float eulerB)
    {
        float result = eulerA + eulerB;
        if (result >= 360)
        {
            result -= 360;
        }
        return result;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Soul")
            || collision.gameObject.CompareTag("Jugador"))
        {
            isTouching = true;
        }
        else
        {
            isTouching = false;
        }
    }
}
