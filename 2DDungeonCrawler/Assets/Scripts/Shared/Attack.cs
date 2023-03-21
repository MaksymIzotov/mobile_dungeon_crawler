using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack", menuName = "Shared/Attack", order = 1)]
public class Attack : ScriptableObject
{
    public float damage;
    public float delay;
    public float explosionRadius;

    [Space(10)]

    public float base_damage;
    public float base_delay;
    public float base_explosionRadius;
}
