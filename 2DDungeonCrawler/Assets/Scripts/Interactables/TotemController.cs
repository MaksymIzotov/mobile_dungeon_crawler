using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemController : MonoBehaviour
{
    [SerializeField] GameObject minimapHighlight;

    private Animator animator;

    private bool isUsed;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isUsed) { return; }
        if (!collision.CompareTag("Player")) { return; }

        GameManager.instance.ActivateTotem();
        Destroy(minimapHighlight);
        animator.Play("Use");
        isUsed = true;
    }
}
