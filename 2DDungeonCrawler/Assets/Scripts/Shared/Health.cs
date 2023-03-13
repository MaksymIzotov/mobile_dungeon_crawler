using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Health", menuName = "Shared/Health", order = 1)]
public class Health : ScriptableObject
{
    public float healthPoints;
    public float defence;
    public float healthRegen;

    [Space(10)]

    public float base_healthPoints;
    public float base_defence;
    public float base_healthRegen;
}
