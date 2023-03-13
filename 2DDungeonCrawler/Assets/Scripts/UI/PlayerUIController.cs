using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUIController : MonoBehaviour
{
    public static PlayerUIController Instance;
    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] private Image healthBar1;
    [SerializeField] private Image healthBar2;
    [SerializeField] private Image healthBar3;

    public void UpdateHP(float hp)
    {
        if (hp <= 100)
        {
            healthBar2.fillAmount = 0;                ;
            healthBar3.fillAmount = 0;
            healthBar1.fillAmount = ExtensionMethods.Remap(hp, 0, 100, 0, 1);
        }
        else if (hp <= 200)
        {
            healthBar1.fillAmount = 1;
            healthBar3.fillAmount = 0;
            healthBar2.fillAmount = ExtensionMethods.Remap(hp, 100, 200, 0, 1);
        }
        else if (hp <= 300)
        {
            healthBar1.fillAmount = 1;
            healthBar2.fillAmount = 1;
            healthBar3.fillAmount = ExtensionMethods.Remap(hp, 200, 300, 0, 1);
        }
    }
}
