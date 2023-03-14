using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerEnemiesCounter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        transform.root.GetComponent<PlayerAttackController>().ChangeEnemiesList(collision.gameObject, true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
            transform.root.GetComponent<PlayerAttackController>().ChangeEnemiesList(collision.gameObject, false);
    }
}
