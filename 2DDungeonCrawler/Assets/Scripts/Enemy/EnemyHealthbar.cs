using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthbar : MonoBehaviour
{
    [SerializeField] private Transform healthBar;

    private float currentValue = 0.5f;

    void Update()
    {
        UpdateHealthbar();
    }

    private void UpdateHealthbar()
    {
        currentValue = Mathf.Clamp(currentValue, 0, 0.3f);
        healthBar.localScale = new Vector3(Mathf.Lerp(healthBar.localScale.x, currentValue, 4f * Time.deltaTime), 0.03f, 1);
    }

    public void UpdateHealthbarValue(float maxHp, float currentHp)
    {
        currentValue = ExtensionMethods.Remap(currentHp, 0, maxHp, 0, 0.3f);
    }
}
