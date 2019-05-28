using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinitBackground : MonoBehaviour
{

    Material material;
    Vector2 offset;
    [SerializeField]
    float VelocityX;
    [SerializeField]
    float VelocityY;
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
        offset = new Vector2(cam.position.x + 5.780137f, cam.position.y + 1.627612f);
        material.mainTextureOffset = offset * new Vector2(VelocityX, VelocityY);
    }
}
