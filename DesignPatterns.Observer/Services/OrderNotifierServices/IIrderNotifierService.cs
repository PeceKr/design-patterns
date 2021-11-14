using DesignPatterns.Observer.Models;

namespace DesignPatterns.Observer.Services
{
    public interface IIrderNotifierService
    {
        // Attach an order observer to the subject.
        void Attach(IOrderObserverService observer);

        // Detach an order observer from the subject.
        void Detach(IOrderObserverService observer);

        // Notify all order observers about an event.
        void Notify(Order order);
    }
}