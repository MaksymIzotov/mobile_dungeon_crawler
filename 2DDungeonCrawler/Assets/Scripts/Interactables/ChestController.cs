using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private bool isSuper;

    private bool isUsed;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isUsed) { return; }
        if (!collision.CompareTag("Player")) { return; }

        animator.Play("Use");
        isUsed = true;
    }

    private void GiveUpgrade()
    {
        UpgradesController.Instance.GenerateUpgrades(isSuper);
    }
}
