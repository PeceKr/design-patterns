using DesignPatterns.Observer.Models;

namespace DesignPatterns.Observer.Services
{
    public interface IOrderObserverService
    {
        void NotifyForUpdate(Order order);
    }
}