using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinitBackground : MonoBehaviour
{

    Material material;
    Vector2 offset;
    public float Velocity;

    public Transform cam;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
    }
    // Update is called once per frame
    private void Start()
    {
    }


    void Update()
    {
        offset = new Vector2(cam.position.x, 0);
        material.mainTextureOffset = offset * Velocity;
    }
}
