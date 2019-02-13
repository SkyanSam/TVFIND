using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Sprite walkSprite, stillSprite, jumpSprite;

    public float speed;
    public float jumpForce;

    private Rigidbody2D rb;
    SpriteRenderer sr;

    private bool isGrounded;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.rotation = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
            sr.sprite = jumpSprite;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            sr.sprite = walkSprite;
        } else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            sr.sprite = walkSprite;
        } else
        {
            sr.sprite = stillSprite;
        }

        if (isGrounded)
        {
            rb.velocity = new Vector2(0, 0);
        } else
        {
            rb.velocity = new Vector2(0, -1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = false;
    }
}