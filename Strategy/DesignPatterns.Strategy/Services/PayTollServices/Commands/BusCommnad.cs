using DesignPatterns.Strategy.Constants;

namespace DesignPatterns.Strategy.Services.Commands
{
    public class BussCommand : IPayTollCommand
    {
        public decimal GetPrice()
        {
            return PriceConstants.BUS_PRICE;
        }
    }
}