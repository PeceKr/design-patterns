using System;
using DesignPatterns.Observer.Models;

namespace DesignPatterns.Observer.Services
{
    public class EmailOrderObserverService : IOrderObserverService
    {
        public void NotifyForUpdate(Order order)
        {            
            Console.WriteLine($"Order '{order.OrderNumber}' is updated to '{order.OrderStatus.ToString()}'. An email is sent to customer.");
        }
    }
}