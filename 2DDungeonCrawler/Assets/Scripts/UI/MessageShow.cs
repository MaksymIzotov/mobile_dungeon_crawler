using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageShow : MonoBehaviour
{
    public static MessageShow instance;
    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private GameObject notificationPrefab;
    [SerializeField] private Transform notificationParent;

    public void ShowNotification(string text)
    {
        GameObject notification = Instantiate(notificationPrefab, notificationParent);
        notification.GetComponent<TMP_Text>().text = text;
    }
}
