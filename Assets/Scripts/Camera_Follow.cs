using UnityEngine;

public class Camera_Follow : MonoBehaviour {
    public Transform player;
    public float delayCamera = 0.05f;
    public Vector3 offset;

     void FixedUpdate ()
    {
        Vector3 playerPos = player.position + offset;
        Vector3 delayPlayerPos = Vector3.Lerp(transform.position, playerPos, delayCamera);
        transform.position = delayPlayerPos;
    }


}
