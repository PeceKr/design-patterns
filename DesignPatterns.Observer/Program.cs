using System;
using DesignPatterns.Observer.Models;
using DesignPatterns.Observer.Services;
using static DesignPatterns.Observer.Enums.OrderEnums;

namespace DesignPatterns.Observer
{
    class Program
    {
        public static IServiceProvider _serviceProvider { get; set; }
        static void Main(string[] args)
        {
            // Inject Order Services
            _serviceProvider = Resolver.ConfigureService();
            var _orderService = (IOrderServices)_serviceProvider.GetService(typeof(IOrderServices));

            // Attach observers
            var smsObserver = new SmsOrderObserverService();
            var emailObserver = new EmailOrderObserverService();
            _orderService.Attach(smsObserver);
            _orderService.Attach(emailObserver);

            // Simulate order change
            Console.WriteLine("Updating Order Status...");
            var order = new Order
            {
                OrderDate = DateTime.UtcNow,
                OrderNumber = new Random().Next(3000),
                OrderStatus = OrderStatuses.Shipped,
                TotalAmount = 220
            };

            // Update order and notify
            _orderService.UpdateOrder(order);


            // Detach email and send only sms
            Console.WriteLine("Detaching email observer...");
            _orderService.Detach(emailObserver);

            var newOrder = new Order
            {
                OrderDate = DateTime.UtcNow,
                OrderNumber = new Random().Next(3000),
                OrderStatus = OrderStatuses.Shipped,
                TotalAmount = 2220
            };

            _orderService.UpdateOrder(newOrder);

        }
    }
}
