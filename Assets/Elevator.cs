using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField]
    float velocity;

    [SerializeField]
    float posYMin;
    [SerializeField]
    float posYMax;
    [SerializeField]
    float posYFinal;

    bool isElevator;
    bool isDestiny;
    // Start is called before the first frame update
    void Start()
    {
        isElevator = false;
        isDestiny = false;
    }

    // Update is called once per frame
    void Update()
    {
        MoveElevator();
    }

    void MoveElevator()
    {
        if (isElevator && !isDestiny)
        {
            print("+" + isDestiny);
            transform.position += new Vector3(0, -(velocity/10), 0);
        }
        if(transform.position.y <= posYMin
            && transform.position.y >= posYMax)
        {
            print("destiny");
            transform.position = new Vector3(transform.position.x, posYFinal, transform.position.z);
            isElevator = false;
            isDestiny = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador")
            && !isDestiny)
        {
            print("collision");
            isElevator = true;
        }
        else
        {
            print("nocoll");
            isDestiny = false;
        }
    }
}
