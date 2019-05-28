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
    public enum Direction
    {
        Left,
        Down,
        Right,
        Up
    }
    Direction direction;
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
    }
    void FixedUpdate()
    {
        //ChangeEulerAngles();
        switch (direction)
        {
            case Direction.Left:
                LeftMovement();
                LeftJump();
                break;
            case Direction.Down:
                NormalMovement();
                NormalJump();
                break;
            case Direction.Right:
                RightMovement();
                RightJump();
                break;
            case Direction.Up:
                UpMovement();
                UpJump();
                break;
        }
        if (Input.GetKey(KeyCode.LeftArrow)
               || Input.GetKey(KeyCode.RightArrow))
        {
            horizontalMove = 0;
        }
            ChangeEulerAngles();
        
          //    ChangeToPlayer();
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

        RbSoul.velocity = new Vector2(RbSoul.velocity.x, speed * horizontalMove);
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
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Flor"))
        {
            isJumping = false;
            isOnGround = true;
            //animator.SetBool("Jumping", false);
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Flor"))
        {
            isOnGround = false;
            //animator.SetBool("Jumping", false);
        }
    }
    void ChangeEulerAngles()
    {
        if (isOnGround)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (direction != Direction.Right) //Estoy mirando en otra direccion
                {
                    transform.eulerAngles = new Vector3(0.0f, 0.0f, 90.0f);
                    direction = Direction.Right;
                }
                else // Estoy mirando a la derecha
                {
                    transform.eulerAngles = Vector3.zero;
                    ChangeToPlayer();
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (direction != Direction.Left)
                {
                    transform.eulerAngles = new Vector3(0.0f, 0.0f, 270.0f);
                    direction = Direction.Left;
                }
                else // Estoy mirando a la derecha
                {
                    transform.eulerAngles = Vector3.zero;
                    ChangeToPlayer();
                }
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (direction != Direction.Up)
                {
                    transform.eulerAngles = new Vector3(0.0f, 0.0f, 180.0f);
                    direction = Direction.Up;
                }
                else // Estoy mirando a la derecha
                {
                    transform.eulerAngles = Vector3.zero;
                    ChangeToPlayer();
                }
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (direction != Direction.Down)
                {
                    transform.eulerAngles = Vector3.zero;
                    direction = Direction.Down;
                }
                else // Estoy mirando a la derecha
                {
                    transform.eulerAngles = Vector3.zero;
                    ChangeToPlayer();
                }

            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                TransformSoul.eulerAngles = Vector3.zero;
            }
        }
    }
    
    public void InitialDir(Direction dir) {
        direction = dir;
        switch (dir)
        {
            case Direction.Left:
                transform.eulerAngles = new Vector3(0.0f, 0.0f, 270.0f);
                break;
            case Direction.Down:
                transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                break;
            case Direction.Right:
                transform.eulerAngles = new Vector3(0.0f, 0.0f, 90.0f);
                break;
            case Direction.Up:
                transform.eulerAngles = new Vector3(0.0f, 0.0f, 180.0f);
                break;
        }
    }

    void ChangeToPlayer()
    {


            scriptSoul.enabled = !scriptSoul.enabled;
            CollSoul.enabled = !CollSoul.enabled;
            horizontalMove = 0.0f;
            playerScript.isSoul = false;
            CollPlayer.enabled = !CollPlayer.enabled;
            RbPlayer.gravityScale = 1f;
    }


}
