using System.Collections.Generic;
using DesignPatterns.Observer.Models;

namespace DesignPatterns.Observer.Services
{
    public class OrderServices : IOrderServices
    {
        public List<IOrderObserverService> Observers = new List<IOrderObserverService>();

        public void UpdateOrder(Order order)
        {
            /*
              ....

              code block for updateing the order
              
              ....
            */

            // Notify customer
            Notify(order);
        }

        public void Attach(IOrderObserverService observer)
        {
            Observers.Add(observer);
        }

        public void Detach(IOrderObserverService observer)
        {
            Observers.Remove(observer);
        }

        public void Notify(Order order)
        {
            foreach (var observer in Observers)
            {
                observer.NotifyForUpdate(order);
            }
        }
    }
}