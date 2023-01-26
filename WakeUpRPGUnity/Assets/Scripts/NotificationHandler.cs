using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;
using UnityEngine.Android;

public class NotificationHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AndroidNotificationCenter.Initialize();
        var channel = new AndroidNotificationChannel()
        {
            Id = "BOAE",
            Name = "Blink Of An Eye Notifications",
            Importance = Importance.Default,
            Description = "Alarm for the game Blink of An Eye",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        if (!Permission.HasUserAuthorizedPermission("android.permission.POST_NOTIFICATIONS"))
        {
            Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendTestNotification(int minutes)
    {
        var notification = new AndroidNotification
        {
            Title = "Blink of An Eye",
            Text = "This is a Test Notification from Blink of an Eye!",
            FireTime = System.DateTime.Now.AddMinutes(minutes)
        };

        Debug.Log(AndroidNotificationCenter.SendNotification(notification, "BOAE"));
    }
}

