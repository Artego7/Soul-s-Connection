using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Bool to active
    bool isJumping;
    bool isCrouch;
    bool isOnGround;
    public bool isDead;
    public bool isSoul;

    //Var from Player
    public float speed = 4f;
    float horizontalMove = 0f;
    public int live = 100;
    public float jumpForce = 6f;
    Vector3 LastPlayerPosition;

    //Components from Player
    public Animator animator;
    Rigidbody2D RbPlayer;
    BoxCollider2D CollPlayer;
    SpriteRenderer RenderPlayer;

    //Components from Soul
    public GameObject GameObjSoul;
    Transform TransformSoul;
    Soul scriptSoul;
    CircleCollider2D CollSoul;
    Rigidbody2D RbSoul;

    //Var Security Camera
    float timeOnCollision;


    //Var for Soul
    public float delayCamera = 0.05f;
    public Vector3 offset;


    // Use this for initialization
    void Start()
    {
        //Player
        RenderPlayer = GetComponent<SpriteRenderer>();
        RbPlayer = GetComponent<Rigidbody2D>();
        CollPlayer = GetComponent<BoxCollider2D>();

        //Soul
        TransformSoul = GameObjSoul.GetComponent<Transform>();
        scriptSoul = GameObjSoul.GetComponent<Soul>();
        CollSoul = GameObjSoul.GetComponent<CircleCollider2D>();
        RbSoul = GameObjSoul.GetComponent<Rigidbody2D>();

        isOnGround = false;
        isDead = false;
        timeOnCollision = 0f;
    }
    // Update is called once per frame
    void Update()
    {
        LastPlayerPosition = transform.position;
    }

    void FixedUpdate()
    {
        SoulFollow();
        Movement();
        Jump();
        ChangeColorForDamage();
        if (isOnGround)
        {
            ChangeToSoul();
        }
    }

    void Movement()
    {
        Crouch();
        if (!isCrouch && !isSoul)
        {
            horizontalMove = Input.GetAxis("Horizontal");
        }
        if (Input.GetKey(KeyCode.LeftArrow)
            || Input.GetKey(KeyCode.RightArrow))
        {
            horizontalMove = 0;
        }
        //animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetKey(KeyCode.LeftControl))
        {
            print("hola");
            horizontalMove = horizontalMove * 1.5f;
        }
        RbPlayer.velocity = new Vector2(speed * horizontalMove, RbPlayer.velocity.y);
        OrentationPlayer();
    }

    void OrentationPlayer()
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

    void Crouch()
    {
        if (Input.GetKey(KeyCode.LeftShift) && !isCrouch && !isJumping && !isSoul)
        {
            isCrouch = true;
            horizontalMove = 0f;
            //animator.SetBool("Crouch", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isCrouch = false;
            //animator.SetBool("Crouch", false);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping && !isCrouch && !isSoul)
        {
            isJumping = true;
            isOnGround = false;
            RbPlayer.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            //animator.SetBool("Jumping", true);
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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Door"))
        {
            transform.position = LastPlayerPosition;
        }
        if (collision.gameObject.CompareTag("SecurityCamera"))
        {
            timeOnCollision += Time.deltaTime;
            if (timeOnCollision >= 2f)
            {
                isDead = true;
            }
        }
        if (!collision.gameObject.CompareTag("SecurityCamera")
            && timeOnCollision > 0)
        {
            timeOnCollision -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
    }

    void ChangeColorForDamage()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            RenderPlayer.color = new Color(0.7019608f, 0.3960785f, 0.4235294f, 1f);
            print(RenderPlayer.material.color);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            RenderPlayer.color = new Color(1f, 1f, 1f, 1f);
            print(RenderPlayer.material.color);
        }
    }

    void SoulFollow()
    {
        if(!isSoul)
        {
            Vector3 playerPos = transform.position + offset;
            Vector3 delayPlayerPos = Vector3.Lerp(TransformSoul.position, playerPos, delayCamera);
            TransformSoul.position = delayPlayerPos;
        }
    }

    void ChangeToSoul()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow) 
            && !isSoul
            && !isJumping)
        {
            TransformSoul.eulerAngles = new Vector3( 0.0f, 0.0f, 90.0f );
            isSoul = true;
            ActiveSouAndDisablePlayer();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)
            && !isSoul
            && !isJumping)
        {
            print("leftply");
            TransformSoul.eulerAngles = new Vector3(0.0f, 0.0f, 270.0f);
            isSoul = true;
            ActiveSouAndDisablePlayer();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) 
            && !isSoul
            && !isJumping)
        {
            TransformSoul.eulerAngles = new Vector3(0.0f, 0.0f, 180.0f);
            isSoul = true;
            ActiveSouAndDisablePlayer();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) 
            && !isSoul 
            && !isJumping)
        {
            TransformSoul.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            isSoul = true;
            ActiveSouAndDisablePlayer();
        }

    }
    void ActiveSouAndDisablePlayer()
    {
        if (isSoul)
        {
            scriptSoul.enabled = !scriptSoul.enabled;
            CollSoul.enabled = !CollSoul.enabled;

            horizontalMove = 0.0f;
            CollPlayer.enabled = !CollPlayer.enabled;
            RbPlayer.gravityScale = 0f;
        }
    }
}
