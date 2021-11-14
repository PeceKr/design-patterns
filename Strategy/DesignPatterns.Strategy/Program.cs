using System;
using DesignPatterns.Strategy.Models;
using DesignPatterns.Strategy.Services;
using static DesignPatterns.Strategy.Enums.VehicleEnums;

namespace DesignPatterns.Strategy
{
    class Program
    {
        public static IServiceProvider _serviceProvider { get; set; }
        static void Main(string[] args)
        {
            // Inject PayToll Services
            _serviceProvider = Resolver.ConfigureService();
            var _payTollService = (IPayTollServices)_serviceProvider.GetService(typeof(IPayTollServices));

            // Display vehicle paytoll price
            var vehicle = new Vehicle { VehicleType = VehicleTypes.MotorBike };
            System.Console.WriteLine($"Paytoll price for {vehicle.VehicleType} is {_payTollService.GetPrice(vehicle.VehicleType)}");
        }
    }
}
