using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform TransformSoul;
    public GameObject GameObjPlayer;
    public GameObject SoulGround;
    public Transform BackGround;
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
        SoulGround.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, 0);
        BackGround.transform.position = new Vector3(transform.position.x, BackGround.transform.position.y, 0);
    }
}
