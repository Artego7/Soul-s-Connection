using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{

    //Var from Soul
    public float speed = 4f;
    public float jumpForce = 6f;
    public float grabityForce = 9.8f;
    float horizontalMove = 0f;
    bool isJumping;
    bool isOnGround;
    bool isChangingEulerAngle;
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
        isOnGround = false;
        isChangingEulerAngle = false;
    }
    void FixedUpdate()
    {
        //ChangeEulerAngles();
        if (TransformSoul.eulerAngles == new Vector3(0.0f, 0.0f, 90.0f))
        {
            RightMovement();
            RightJump();
        }
        if (TransformSoul.eulerAngles == new Vector3(0.0f, 0.0f, 270.0f))
        {
            LeftMovement();
            LeftJump();
        }
        if (TransformSoul.eulerAngles == new Vector3(0.0f, 0.0f, 180.0f))
        {
            UpMovement();
            UpJump();
        }
        if (TransformSoul.eulerAngles == new Vector3(0.0f, 0.0f, 0.0f))
        {
            NormalMovement();
            NormalJump();
        }
        if (Input.GetKey(KeyCode.LeftArrow)
               || Input.GetKey(KeyCode.RightArrow))
        {
            horizontalMove = 0;
        }
        if (isOnGround)
        {
            ChangeEulerAngles();
            ChangeToPlayer();
        }
    }

    void NormalMovement()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        RbSoul.AddForce(Vector2.down * grabityForce, ForceMode2D.Force);
        //animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetKey(KeyCode.LeftControl))
        {
            horizontalMove = horizontalMove * 1.5f;
        }
        RbSoul.velocity = new Vector2(speed * horizontalMove, RbSoul.velocity.y);
        OrentationSoul();
    }
    void NormalJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping && playerScript.isSoul)
        {
            isJumping = true;
            isOnGround = false;
            RbSoul.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            //animator.SetBool("Jumping", true);
        }
    }

    void UpMovement()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        RbSoul.AddForce(Vector2.up * grabityForce, ForceMode2D.Force);
        //animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetKey(KeyCode.LeftControl))
        {
            horizontalMove = horizontalMove * 1.5f;
        }
        RbSoul.velocity = new Vector2(-speed * horizontalMove, RbSoul.velocity.y);
        OrentationSoul();
    }
    void UpJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping && playerScript.isSoul)
        {
            isJumping = true;
            isOnGround = false;
            RbSoul.AddForce(Vector2.down * jumpForce, ForceMode2D.Impulse);
            //animator.SetBool("Jumping", true);
        }
    }

    void RightMovement()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        RbSoul.AddForce(Vector2.right * grabityForce, ForceMode2D.Force);
        //animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetKey(KeyCode.LeftControl))
        {
            horizontalMove = horizontalMove * 1.5f;
        }

        RbSoul.velocity = new Vector2( RbSoul.velocity.x, speed * horizontalMove);
    }
    void RightJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping && playerScript.isSoul)
        {
            isJumping = true;
            isOnGround = false;
            RbSoul.AddForce(Vector2.left * jumpForce, ForceMode2D.Impulse);
            //animator.SetBool("Jumping", true);
        }
    }

    void LeftMovement()
    {
            horizontalMove = Input.GetAxis("Horizontal");
        RbSoul.AddForce(Vector2.left * grabityForce, ForceMode2D.Force);
        //animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetKey(KeyCode.LeftControl))
        {
            horizontalMove = horizontalMove * 1.5f;
        }

        RbSoul.velocity = new Vector2(RbSoul.velocity.x, -speed * horizontalMove);
    }
    void LeftJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping && playerScript.isSoul)
        {
            print("leftjump");
            isJumping = true;
            isOnGround = false;
            RbSoul.AddForce(Vector2.right * jumpForce, ForceMode2D.Impulse);
            //animator.SetBool("Jumping", true);
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

    private void CollisionJump(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Flor"))
        {
            isJumping = false;
            isOnGround = true;
            //animator.SetBool("Jumping", false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        CollisionJump(collision);
    }
    void ChangeEulerAngles()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)
            && TransformSoul.eulerAngles != new Vector3(0.0f, 0.0f, 90.0f))
        {
            TransformSoul.eulerAngles = new Vector3(0.0f, 0.0f, 90.0f);
            isJumping = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)
            && TransformSoul.eulerAngles != new Vector3(0.0f, 0.0f, 270.0f))
        {
            TransformSoul.eulerAngles = new Vector3(0.0f, 0.0f, 270.0f);
            isJumping = true;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)
            && TransformSoul.eulerAngles != new Vector3(0.0f, 0.0f, 180.0f))
        {
            TransformSoul.eulerAngles = new Vector3(0.0f, 0.0f, 180.0f);
            isJumping = true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)
            && TransformSoul.eulerAngles != new Vector3(0.0f, 0.0f, 0.0f))
        {
            TransformSoul.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            isJumping = true;
        }
    }

    void ChangeToPlayer()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow)
            && TransformSoul.eulerAngles == new Vector3(0.0f, 0.0f, 90.0f)
            && !isJumping)
        {
            TransformSoul.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            playerScript.isSoul = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)
            && TransformSoul.eulerAngles == new Vector3(0.0f, 0.0f, 270.0f)
            && !isJumping)
        {
            TransformSoul.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            playerScript.isSoul = false;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)
            && TransformSoul.eulerAngles == new Vector3(0.0f, 0.0f, 180.0f)
            && !isJumping)
        {
            TransformSoul.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            playerScript.isSoul = false;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)
            && TransformSoul.eulerAngles == new Vector3(0.0f, 0.0f, 0.0f)
            && !isJumping)
        {
            playerScript.isSoul = false;
        }
        if (Input.GetKeyDown(KeyCode.R) && playerScript.isSoul
            && !isJumping)
        {
            TransformSoul.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            playerScript.isSoul = false;
        }
        if (!playerScript.isSoul)
        {
            scriptSoul.enabled = !scriptSoul.enabled;
            CollSoul.enabled = !CollSoul.enabled;
            horizontalMove = 0.0f;
                        
            CollPlayer.enabled = !CollPlayer.enabled;
            RbPlayer.gravityScale = 1f;
        }
    }
}
