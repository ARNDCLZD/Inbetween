using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteController : MonoBehaviour
{
    private Animator animator;
    private int interact;
    public int seuil;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        Debug.Log(animator.GetBool("Ouvert"));
    }

    void Update()
    {
        Debug.Log(interact);
        if(this.interact >= seuil)
        {
            this.Open();
        }
        else
        {
            this.Close();
        }
    }
    // Start is called before the first frame update
    public void Open()
    {
        animator.SetBool("Ouvert", true);
    }
    public void Close()
    {
        animator.SetBool("Ouvert", false);
    }

    public void Interact()
    {
        this.interact += 1;
    }

    public void ReverseInteract()
    {
        this.interact -= 1;
    }
}
