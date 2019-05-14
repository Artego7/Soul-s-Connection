using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{

    //Var from Soul
    public float speed = 4f;
    float horizontalMove = 0f;
    public float jumpForce = 6f;
    bool isJumping;

    //Components from Player
    public GameObject GameObjPlayer;
    Player playerScript;
    BoxCollider2D CollPlayer;
    Rigidbody2D RbPlayer;

    //Components from Soul
    Transform TransformSoul;
    //GameObject GameObjSoul;
    Soul scriptSoul;
    CircleCollider2D CollSoul;
    Rigidbody2D RbSoul;

    void Start()
    {
        TransformSoul = GetComponent<Transform>();
        //GameObjSoul = GetComponent<GameObject>();
        scriptSoul = GetComponent<Soul>();
        CollSoul = GetComponent<CircleCollider2D>();
        RbSoul = GetComponent<Rigidbody2D>();

        playerScript = GameObjPlayer.GetComponent<Player>();
        CollPlayer = GameObjPlayer.GetComponent<BoxCollider2D>();
        RbPlayer = GameObjPlayer.GetComponent<Rigidbody2D>();

    }
    void FixedUpdate()
    {
        if(TransformSoul.eulerAngles == new Vector3(0.0f, 0.0f, 90.0f))
        {
            RightMovement();
            //RightJump();
        }
        if (TransformSoul.eulerAngles == new Vector3(0.0f, 0.0f, -90.0f))
        {
            //LeftMovement();
            //LeftJump();
        }
        if (TransformSoul.eulerAngles == new Vector3(0.0f, 0.0f, 180.0f))
        {
            //UpMovement();
            //UpJump();
        }
        if (TransformSoul.eulerAngles == new Vector3(0.0f, 0.0f, 0.0f))
        {
            NormalMovement();
            NormalJump();
        }

        ChangeToSoul();
    }

    void NormalMovement()
    {

            horizontalMove = Input.GetAxis("Horizontal");
        //animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetKey(KeyCode.LeftControl))
        {
            horizontalMove = horizontalMove * 1.5f;
        }
        RbSoul.velocity = new Vector2(speed * horizontalMove, RbSoul.velocity.y);
        OrentationSoul();
    }
    void RightMovement()
    {
        if (Input.GetKeyDown(KeyCode.D))
           {
               TransformSoul.position += new Vector3( 0.0f, horizontalMove, 0.0f );
           }
    }

    void OrentationSoul()
    {
        if (horizontalMove < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (horizontalMove > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void NormalJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping && playerScript.isSoul)
        {
            isJumping = true;
            RbSoul.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            //animator.SetBool("Jumping", true);
        }
    }

    private void CollisionJump(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Flor"))
        {
            isJumping = false;
            //animator.SetBool("Jumping", false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        CollisionJump(collision);
    }

    void ChangeToSoul()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow)
            && TransformSoul.eulerAngles == new Vector3(0.0f, 0.0f, 90.0f))
        {
            TransformSoul.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            playerScript.isSoul = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)
            && TransformSoul.eulerAngles == new Vector3(0.0f, 0.0f, -90.0f))
        {
            TransformSoul.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            playerScript.isSoul = false;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)
            && TransformSoul.eulerAngles == new Vector3(0.0f, 0.0f, 180.0f))
        {
            TransformSoul.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            playerScript.isSoul = false;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)
            && TransformSoul.eulerAngles == new Vector3(0.0f, 0.0f, 0.0f))
        {
            playerScript.isSoul = false;
        }
        if (Input.GetKeyDown(KeyCode.R) && playerScript.isSoul)
        {
            TransformSoul.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            playerScript.isSoul = false;
        }
        if (!playerScript.isSoul)
        {
            scriptSoul.enabled = !scriptSoul.enabled;
            CollSoul.enabled = !CollSoul.enabled;
            RbSoul.gravityScale = 0f;
            horizontalMove = 0.0f;
                        
            CollPlayer.enabled = !CollPlayer.enabled;
            RbPlayer.gravityScale = 1f;
        }
    }

}
