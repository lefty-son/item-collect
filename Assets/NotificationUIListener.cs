using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationUIListener : MonoBehaviour {

    private Text t_NotificatioNumbers;

    // Use this for initialization
    private void Awake()
    {
        t_NotificatioNumbers = GetComponent<Text>();
    }

    private void OnEnable()
    {
        var numbers = PlayerManager.instance.GetNotification();
        t_NotificatioNumbers.text = numbers.ToString();
    }
}
