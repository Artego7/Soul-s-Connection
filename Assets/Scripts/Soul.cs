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

    //Components from Soul
    GameObject GameObjSoul;
    Soul scriptSoul;
    CircleCollider2D CollSoul;
    Rigidbody2D RbSoul;

    void Start()
    {
        GameObjSoul = GetComponent<GameObject>();
        scriptSoul = GetComponent<Soul>();
        CollSoul = GetComponent<CircleCollider2D>();
        RbSoul = GetComponent<Rigidbody2D>();
        playerScript = GameObjPlayer.GetComponent<Player>();
    }
    void FixedUpdate()
    {
        Movement();
        Jump();
        ChangeToSoul();
    }

    void Movement()
    {

        if (playerScript.isSoul)
        {
            horizontalMove = Input.GetAxis("Horizontal");
        }
        //animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetKey(KeyCode.LeftControl))
        {
            horizontalMove = horizontalMove * 1.5f;
        }
        RbSoul.velocity = new Vector2(speed * horizontalMove, RbSoul.velocity.y);
        OrentationSoul();
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

    void Jump()
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
        if (Input.GetKeyDown(KeyCode.C) && playerScript.isSoul)
        {

            scriptSoul.enabled = !scriptSoul.enabled;
            CollSoul.enabled = !CollSoul.enabled;
            RbSoul.gravityScale = 0f;
            playerScript.isSoul = false;
        }
    }

}
