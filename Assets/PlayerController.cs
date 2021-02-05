using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public bool isSpirit = false;

    private bool playerOnGround;
    private void Update()
    {
        if (!isSpirit)
        {
            if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Z))
            {
                if (Input.GetKey(KeyCode.Q))
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                    anim.SetBool("running", true);
                    rb.velocity = new Vector2(-10, rb.velocity.y);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                    anim.SetBool("running", true);
                    rb.velocity = new Vector2(10, rb.velocity.y);
                }
                if (Input.GetKey(KeyCode.Z) && playerOnGround)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 7f);
                    anim.SetBool("jumping", true);
                    playerOnGround = false;
                }
            }
            else
            {
                anim.SetBool("jumping", false);
                anim.SetBool("running", false);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                isSpirit = true;
            }
            /*if (Input.GetKey(KeyCode.S))
            {
                rb.velocity = new Vector2(rb.velocity.x, -2);
            }*/
        } else
        {
            anim.SetBool("jumping", false);
            anim.SetBool("running", false);
        }     
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            playerOnGround = true;
        }
    }

}
