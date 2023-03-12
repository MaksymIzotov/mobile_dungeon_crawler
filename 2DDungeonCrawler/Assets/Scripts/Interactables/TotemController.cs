using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemController : MonoBehaviour
{
    private Animator animator;

    private bool isUsed;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isUsed) { return; }
        if(collision.CompareTag("Player"))

        animator.Play("Use");
        isUsed = true;
    }
}
