using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSoulController : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;
    public bool status;
    public int essence;
    private int maxEssence = 1000;
    public MentalBarController mentalbar;
    // Start is called before the first frame update
    void Start()
    {
        this.essence = maxEssence;
        this.status = false;
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());
        mentalbar.SetMental(essence, maxEssence);
    }

    // Update is called once per frame
    void Update()
    {
        mentalbar.SetMental(essence, maxEssence);
        mentalbar.gameObject.SetActive(false);
        rb.velocity = new Vector2(0, 0);
        if (this.GetComponentInParent<PlayerController>().isSpirit)
        {
            mentalbar.gameObject.SetActive(true);
            if (this.status != this.GetComponentInParent<PlayerController>().isSpirit)
            {
                this.status = !this.status;
            }
            GetComponent<SpriteRenderer>().enabled = true;
            /*if (Input.GetKeyDown(KeyCode.Space))
            {
                this.GetComponentInParent<PlayerController>().isSpirit = false;
            }*/

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
            if (this.essence > 0)
            {
                this.essence = this.essence - 1;
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else
        {
            if (this.status == this.GetComponentInParent<PlayerController>().isSpirit)
            {
                this.status = !this.status;
            }
            transform.position = new Vector2(player.transform.position.x, player.transform.position.y);
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D gameObj)
    {
        if (gameObj.tag == "deathBoxSpirit")
        {
            this.essence = 0;
        }
        if (gameObj.tag == "gazoual")
        {
            this.essence = 1000;
        }
    }

    
}
