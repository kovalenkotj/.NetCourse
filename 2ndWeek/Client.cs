using System;
using System.Collections.Generic;
using System.Text;

namespace _2ndWeek
{
    /* Task 8, Week 2:
         "Imagine that your application use NotifyClient event to notify remote clients. 
         In case if client is disconnected exception will be thrown and other delegates will not be invoke, 
         so other clients will not be notified. 
         Implement a method which will fire NotifyClient event and will be free of this problem."*/
    public enum SubscribeOrNot
    {
        Yes,
        No
    }
    public delegate void Action();
    class Client
    {
        public Action Notify;

        public Client(SubscribeOrNot s, ref Action Notify)
        {
            if (s == SubscribeOrNot.Yes)
            {
                this.Notify += Notifying;
            }
            Notify += this.Notify;
        }

        public void Notifying()
        {
            Console.WriteLine($"The client is notified");
        }
    }
}
