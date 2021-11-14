using DesignPatterns.Strategy.Constants;

namespace DesignPatterns.Strategy.Services.Commands
{
    public class CarCommand : IPayTollCommand
    {
        public decimal GetPrice()
        {
            return PriceConstants.CAR_PRICE;
        }
    }
}