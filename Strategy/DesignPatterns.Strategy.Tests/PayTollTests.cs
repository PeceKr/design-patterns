using DesignPatterns.Strategy.Models;
using DesignPatterns.Strategy.Services;
using NUnit.Framework;
using static DesignPatterns.Strategy.Enums.VehicleEnums;

namespace DesignPatterns.Strategy.Tests
{
    public class Tests
    {
        private IPayTollServices _payTollService;
        private Vehicle vehicle;

        [SetUp]
        public void Setup()
        {
            _payTollService = new PayTollServices();            
        }

        [Test]
        public void Get_Car_Price()
        {
            vehicle = new Vehicle { VehicleType = VehicleTypes.Car };

            var price = _payTollService.GetPrice(vehicle.VehicleType);

            Assert.AreEqual(price, Constants.PriceConstants.CAR_PRICE);
        }
    }
}