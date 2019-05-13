using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform player;
    public Transform soul;
    public GameObject GameObjPlayer;

    public float delayCamera = 0.05f;
    public Vector3 offset;

    Player playerScript;

    void Start()
    {
        playerScript = GameObjPlayer.GetComponent<Player>();
    }

    void FixedUpdate()
    {
        if (!playerScript.isSoul)
        {
            Follow(player);
        }
        else if (playerScript.isSoul)
        {
            Follow(soul);
        }
    }

    void Follow(Transform transObj)
    {
        Vector3 playerPos = transObj.position + offset;
        Vector3 delayPlayerPos = Vector3.Lerp(transform.position, playerPos, delayCamera);
        transform.position = delayPlayerPos;
    }
}
