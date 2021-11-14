using DesignPatterns.Observer.Models;

namespace DesignPatterns.Observer.Services
{
    public interface IOrderServices : IIrderNotifierService
    {
        /// <summary>
        /// Updates the order and sends notification to the customer
        /// </summary>
        /// <param name="order"></param>
        void UpdateOrder(Order order);
    }
}