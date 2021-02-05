using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public BoxCollider2D box;
    public LayerMask platformLayerMask;
    public bool isSpirit = false;
    private void Update()
    {
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
                rb.velocity = new Vector2(rb.velocity.x, 7f);
                anim.SetBool("jumping", true);
            }
            Debug.Log("Grounded : " + IsGrounded());
            if (IsGrounded()) anim.SetBool("jumping", false);
            if (rb.velocity.x == 0) anim.SetBool("running", false);
            if (Input.GetKey(KeyCode.Space)) isSpirit = true;   
        } else
        {
            anim.SetBool("jumping", false);
            anim.SetBool("running", false);
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
}
