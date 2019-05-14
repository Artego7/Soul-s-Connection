using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform TransformSoul;
    public GameObject GameObjPlayer;
    public GameObject SoulGround;
    Transform TransformPlayer;

    public float delayCamera = 0.05f;
    public Vector3 offset;

    Player playerScript;

    void Start()
    {
        playerScript = GameObjPlayer.GetComponent<Player>();
        TransformPlayer = GameObjPlayer.GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        if (!playerScript.isSoul)
        {
            Follow(TransformPlayer);
        }
        //else if (playerScript.isSoul)
        //{
        //    Follow(TransformSoul);
        //}
    }

    void Follow(Transform transObj)
    {
        Vector3 playerPos = transObj.position + offset;
        Vector3 delayPlayerPos = Vector3.Lerp(transform.position, playerPos, delayCamera);
        transform.position = delayPlayerPos;
        SoulGround.transform.position = transform.position;
    }
}
