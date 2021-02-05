using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoulController : MonoBehaviour
{
    public  GameObject player;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), this.GetComponent<Collider2D>()); 
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, 0);
        if (this.GetComponentInParent<PlayerController>().isSpirit)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                this.GetComponentInParent<PlayerController>().isSpirit = false;
            }

            if (Input.GetKey(KeyCode.Q))
            {
                rb.velocity = new Vector2(-10, rb.velocity.y);
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.velocity = new Vector2(10, rb.velocity.y);
            }
            if (Input.GetKey(KeyCode.Z))
            {
                rb.velocity = new Vector2(rb.velocity.x, 7f);
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.velocity = new Vector2(rb.velocity.x, -7f);
            } 
        }
        else
        {
            transform.position = new Vector2(player.transform.position.x, player.transform.position.y);
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
