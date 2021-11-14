using System;
using DesignPatterns.Observer.Models;
using DesignPatterns.Observer.Services;
using NUnit.Framework;
using static DesignPatterns.Observer.Enums.OrderEnums;

namespace DesignPatterns.Observer.Tests
{
    public class Tests
    {
        private IOrderServices _orderService;

        [SetUp]
        public void Setup()
        {
            _orderService = new OrderServices();
            var smsObserver = new SmsOrderObserverService();
            var emailObserver = new EmailOrderObserverService();
            _orderService.Attach(smsObserver);
            _orderService.Attach(emailObserver);
        }

        [Test]
        public void Email_And_Sms_Should_be_Sent()
        {
            var order = new Order
            {
                OrderDate = DateTime.UtcNow,
                OrderNumber = new Random().Next(3000),
                OrderStatus = OrderStatuses.Shipped,
                TotalAmount = 220
            };

            _orderService.UpdateOrder(order);
        }
    }
}