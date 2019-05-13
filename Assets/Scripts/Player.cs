using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Bool to active
    bool isJumping;
    bool isCrouch;
    public bool isSoul;

    //Var from Player
    public float speed = 4f;
    float horizontalMove = 0f;
    public int live = 100;
    public float jumpForce = 6f;

    //Components from Player
    public Animator animator;
    Rigidbody2D RbPlayer;
    SpriteRenderer RenderPlayer;
    GameObject GameObjPlayer;

    //Components from Soul
    public Transform TransformSoul;
    public GameObject GameObjSoul;
    Soul scriptSoul;
    CircleCollider2D CollSoul;
    Rigidbody2D RbSoul;


    //Var for Soul
    public float delayCamera = 0.05f;
    public Vector3 offset;


    // Use this for initialization
    void Start()
    {
        //Player
        RenderPlayer = GetComponent<SpriteRenderer>();
        RbPlayer = GetComponent<Rigidbody2D>();
        GameObjPlayer = GetComponent<GameObject>();
        
        //Soul
        scriptSoul = GameObjSoul.GetComponent<Soul>();
        CollSoul = GameObjSoul.GetComponent<CircleCollider2D>();
        RbSoul = GameObjSoul.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        SoulFollow();
        Damage();
        Movement();
        Jump();
        ChangeColorForDamage();
        ChangeToSoul();
    }

    void Movement()
    {
        Crouch();

        if (!isCrouch && !isSoul)
        {
            horizontalMove = Input.GetAxis("Horizontal");
        }
        //animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetKey(KeyCode.LeftControl))
        {
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
            RbPlayer.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
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
    //private void ColliderJump(Collider2D collider)
    //{
    //    if (collider.gameObject.CompareTag("Water"))
    //    {
    //        isJumping = false;
    //        animator.SetBool("Jumping", false);
    //    }
    //}

    void OnCollisionEnter2D(Collision2D collision)
    {
        CollisionJump(collision);
    }
    //private void OnTriggerStay2D(Collider2D collider)
    //{
    //    ColliderJump(collider);
    //}

    void Damage()
    {
        if(live <= 0)
        {

        }
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
        if(Input.GetKeyDown(KeyCode.C) && !isSoul)
        {
            scriptSoul.enabled = !scriptSoul.enabled;
            CollSoul.enabled = !CollSoul.enabled;
            RbSoul.gravityScale = 1f;
            isSoul = true;
        }
    }
}
