using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        Debug.Log(animator.GetBool("Ouvert"));
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
}
