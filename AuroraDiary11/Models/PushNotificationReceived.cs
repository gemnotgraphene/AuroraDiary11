﻿using CommunityToolkit.Mvvm.Messaging.Messages;

namespace AuroraDiary.Models
{
    public class PushNotificationReceived : ValueChangedMessage<string>
    {
        public PushNotificationReceived(string message) : base(message) { }
    }
}
