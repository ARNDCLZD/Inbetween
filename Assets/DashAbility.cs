using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAbility : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;

    public CooldownIndicator cdi;
    public GameObject dashEffect;

    private float startCooldown = 0f;
    public float cooldown = 3f;
    public bool canDash;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    void Update()
    {
        canDash = Time.time > startCooldown + cooldown;
        if (direction == 0 && !GetComponent<PlayerController>().isSpirit)
        {
            if (Input.GetKey(KeyCode.Q) && Input.GetKeyDown(KeyCode.LeftShift) && canDash)
            {
                startCooldown = Time.time;
                
                Instantiate(dashEffect, transform.position, Quaternion.identity);
                direction = 1;
            }
            else if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.LeftShift) && canDash)
            {
                startCooldown = Time.time;
                
                Instantiate(dashEffect, transform.position, Quaternion.identity);
                direction = 2;
            }
            else if (Input.GetKey(KeyCode.Z) && Input.GetKeyDown(KeyCode.LeftShift) && canDash)
            {
                startCooldown = Time.time;
                
                Instantiate(dashEffect, transform.position, Quaternion.identity);
                direction = 3;
            }
            else if (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.LeftShift) && canDash)
            {
                startCooldown = Time.time;
                
                Instantiate(dashEffect, transform.position, Quaternion.identity);
                direction = 4;
            }
        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;

                if (direction == 1)
                {
                    rb.velocity = Vector2.left * dashSpeed;
                }
                else if (direction == 2)
                {
                    rb.velocity = Vector2.right * dashSpeed;
                }
                else if (direction == 3)
                {
                    rb.velocity = Vector2.up * dashSpeed;
                }
                else if (direction == 4)
                {
                    rb.velocity = Vector2.down * dashSpeed;
                }
            }
        }
    }
}