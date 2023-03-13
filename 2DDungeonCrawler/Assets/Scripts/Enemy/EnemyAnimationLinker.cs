using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAnimationLinker : MonoBehaviour
{
    private void Die()
    {
        Destroy(gameObject);
    }
}
