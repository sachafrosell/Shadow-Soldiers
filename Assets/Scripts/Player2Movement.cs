using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    public float speed = 1f;
    public float jumpHeight = 30f;
    public float playerWeight = 2.5f;
    public bool externalController = false;

    private Animator anim;
    private float prevY;
    private float moveY;
    private float moveY2;
    private bool isWalking = false;
    private bool jumpAnim = false;
    private bool isMoving = false;
    private bool isFlipped = false;
    private bool isSprinting = false;
    private int sprintMultiplier = 1;
    private bool isJumping = false;
    private bool isGrounded = false;
    private bool isJump = false;
    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        prevY = rb.velocity.y;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Floor" || collision.gameObject.tag == "Bird")
        {
            isGrounded = true;
        }
      
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    private void CheckMaxY()
    {
        if (rb.velocity.y > 8f)
        {
            Vector2 max = new Vector2(rb.velocity.x, 5f);
            rb.velocity = max;
        }
    }

    void Update()
    {

        float moveX = Input.GetAxis("Horizontal");
        float shiftDown = Input.GetAxis("Fire3");
        float fire = Input.GetAxis("Fire1");

        anim.SetBool("isSprinting", isSprinting);
        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isJumping", jumpAnim);
        anim.SetBool("isJump", isJump);

        CheckMaxY();
        CheckFlipped(moveX);
        CheckShift(shiftDown);
        CheckMovement(moveX);

    }

    private void CheckMovement(float moveX)
    {
        if (Mathf.Abs(moveX) > 0.5f)
        {
            isWalking = true;
            isSprinting = true;
            isMoving = true;
            anim.SetBool("isWalking", isWalking);
        }
        else if (Mathf.Abs(moveX) <= 0.5f)
        {
            isSprinting = false;
            isWalking = false;
            isMoving = false;
            anim.SetBool("isWalking", isWalking);
        }
    }

    private void FixedUpdate()
    {

        //print(isJumping);

        if (prevY > rb.velocity.y)
        {
            isJump = true;
        }
        else if (prevY < rb.velocity.y)
        {
            isJump = false;
        }

        float moveX = Input.GetAxis("Horizontal");
        if (externalController)
        {
            moveY = -Input.GetAxis("Vertical");
            moveY2 = Input.GetAxis("Jump");
        }
        else
        {
            moveY = Input.GetAxis("Jump");
        }

        if (isJumping)
        {
            if (moveX > 0f)
            {
                transform.Translate(1 * Time.deltaTime * sprintMultiplier * speed, 0f, 0f);
            }
            else if (moveX < 0f)
            {
                transform.Translate(-1 * Time.deltaTime * sprintMultiplier * speed, 0f, 0f);
            }

        }
        else
        {
            transform.Translate(moveX * Time.deltaTime * sprintMultiplier * speed, 0f, 0f);
        }

        CheckJumping(moveY, moveY2);

        if (isJumping == true && isGrounded == true)
        {
            Vector3 motionless = new Vector3(0f, 0f, 0f);
            Vector3 jump = new Vector3(0f, 5f * jumpHeight, 0f);
            rb.AddForce(motionless);
            rb.AddForce(jump);
        }


        if (isFlipped == true)
        {
            Vector3 newScale = new Vector3(-0.1f, 0.1f, 0.1f);
            transform.localScale = newScale;
        }
        else if (isFlipped == false)
        {
            Vector3 newScale = new Vector3(0.1f, 0.1f, 0.1f);
            transform.localScale = newScale;
        }

        prevY = rb.velocity.y;
    }

    private void CheckJumping(float moveY, float moveY2)
    {
        if (moveY > 0.01f || moveY2 > 0.01f)
        {
            isJumping = true;
        }
        else if (moveY < 0.01f && moveY2 < 0.01f)
        {
            isJumping = false;
            rb.velocity += Vector2.up * Physics2D.gravity.y * playerWeight * Time.deltaTime;
        }
    }

    private void CheckShift(float shiftDown)
    {
        if (shiftDown > 0.1f)
        {
            isSprinting = true;
            sprintMultiplier = 2;
        }
        else
        {
            isSprinting = false;
            sprintMultiplier = 2;
        }
    }

    private void CheckFlipped(float moveX)
    {
        if (moveX > 0.1f)
        {
            isFlipped = false;
        }
        else if (moveX < -0.1f)
        {
            isFlipped = true;
        }
    }
}

