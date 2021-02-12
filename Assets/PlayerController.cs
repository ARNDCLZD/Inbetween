using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public BoxCollider2D box;
    public LayerMask platformLayerMask;
    public bool isSpirit;
    public float fallMultiplier = 3.5f;
    public float lowJumpMultiplier = 3f;
    public Respawn mort;
    private Vector2 vector = new Vector2(0, 0);


    public AudioSource audioFoot;
    public AudioSource audioJump;
    public AudioSource audioSwap;

    private void Start()
    {
        isSpirit = false;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSwap.Play();

            isSpirit = !isSpirit;
        }
        if (!isSpirit)
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                mort.respawn();
            }
            if (Input.GetKey(KeyCode.Q))
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                anim.SetBool("running", true);
                vector.x = -10;
            }
            if (Input.GetKey(KeyCode.D))
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                anim.SetBool("running", true);
                vector.x = 10;
                /*rb.velocity = new Vector2(10, rb.velocity.y);*/
            }
            if (Input.GetKeyDown(KeyCode.Z) && IsGrounded())
            {
                vector = Vector2.up * 14f;
                /*rb.velocity = Vector2.up * 10f;*/
                audioJump.Play();
                rb.velocity = Vector2.up * 10f;
            }

            if(Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.D))
            {
                vector.x = 0;
                /*rb.velocity = new Vector2(0, rb.velocity.y);*/
            }
            // Accélération / Décélération lors d'un saut
            
            // Choix de l'animation de saut
            if (IsGrounded())
            {
                anim.SetBool("jumping", false);
            }
            else
            {
                anim.SetBool("jumping", true);
            }
            // Reset de l'animation de course
            if (rb.velocity.x == 0) anim.SetBool("running", false);
            // Switch Normal/Spirit
        } else
        {
            if (IsGrounded())
            {
                vector.x = 0;
            }
            /*rb.velocity = new Vector2(0, rb.velocity.y);*/
            anim.SetBool("jumping", false);
            anim.SetBool("running", false);
        }
        Debug.Log(IsGrounded());
        if (rb.velocity.y < 0 && !IsGrounded())
        {
            vector.y += 1 * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            /*rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;*/
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Z))
        {
            vector.y += 2 * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            /*rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;*/
        }
        else
        {
            if (!IsGrounded())
            {
                vector.y += 1 * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
        }
        
        rb.velocity = vector;
        /*if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Z))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }*/
    }

    private void FixedUpdate()
    {
        PlayFootsteps();
    }

    private bool IsGrounded()
    {
        float extraHeightText = .1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(box.bounds.center,box.bounds.size,0f,Vector2.down, extraHeightText, platformLayerMask);
        Color rayColor;
        if (raycastHit.collider != null) rayColor = Color.green;
        else rayColor = Color.red;
        Debug.DrawRay(box.bounds.center, Vector2.down * (box.bounds.extents.y + extraHeightText), rayColor);
        return raycastHit.collider != null;
    }

    void OnTriggerEnter2D(Collider2D gameObj)
    {
        if(gameObj.tag == "deathBox")
        {
            Debug.Log("Mort");
        }
    }

    public void changeSpirit()
    {
        isSpirit = !isSpirit;
    }


    public void stabiliser()
    {
        vector.y = 0;
    }
    private void PlayFootsteps()
    {
        if (IsGrounded() && (rb.velocity.x > 0.1f || rb.velocity.x < -0.1f))
        {
            audioFoot.enabled = true;
            audioFoot.loop = true;
        }else
        {
            audioFoot.enabled = false;
            audioFoot.loop = false;
        }
    }

    private void PlayJump()
    {
        if (Input.GetKeyDown(KeyCode.Z) && IsGrounded())
        {
            audioJump.Play();
        }

    }
}
