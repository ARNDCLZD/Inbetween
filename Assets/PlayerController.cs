using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public BoxCollider2D box;
    public LayerMask platformLayerMask;
    public bool isSpirit;
    public float fallMultiplier = 3.5f;
    public float lowJumpMultiplier = 3f;

    private void Start()
    {
        isSpirit = false;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isSpirit = !isSpirit;
        }
        if (!isSpirit)
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
            if (Input.GetKeyDown(KeyCode.Z) && IsGrounded())
            {
                rb.velocity = Vector2.up * 10f;
            }

            if(Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.D))
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
            // Accélération / Décélération lors d'un saut
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            } else if(rb.velocity.y > 0 && !Input.GetKey(KeyCode.Z))
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
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
            if(IsGrounded())rb.velocity = new Vector2(0, rb.velocity.y);
            if (rb.velocity.y == 0) anim.SetBool("jumping", false);
            if (rb.velocity.x == 0) anim.SetBool("running", false);
        }     
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

    public void changeSpirit()
    {
        isSpirit = !isSpirit;
    }
}
