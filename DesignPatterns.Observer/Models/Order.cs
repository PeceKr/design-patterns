using System;
using static DesignPatterns.Observer.Enums.OrderEnums;

namespace DesignPatterns.Observer.Models
{
    public class Order
    {
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatuses OrderStatus { get; set; }
    }
}