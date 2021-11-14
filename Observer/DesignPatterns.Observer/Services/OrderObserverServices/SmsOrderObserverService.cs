using System;
using DesignPatterns.Observer.Models;

namespace DesignPatterns.Observer.Services
{
    public class SmsOrderObserverService : IOrderObserverService
    {
        public void NotifyForUpdate(Order order)
        {
            Console.WriteLine($"Order '{order.OrderNumber}' is updated to '{order.OrderStatus.ToString()}'. Sms is sent to customer.");
        }
    }
}