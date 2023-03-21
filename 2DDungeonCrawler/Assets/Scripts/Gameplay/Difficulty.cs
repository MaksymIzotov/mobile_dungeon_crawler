using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Difficulty", menuName = "Gameplay/Diffculty", order = 1)]
public class Difficulty : ScriptableObject
{
    public float enemyHpMult;
    public float enemyDamageMult;
}
