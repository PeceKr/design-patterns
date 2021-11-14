using DesignPatterns.Strategy.Constants;

namespace DesignPatterns.Strategy.Services.Commands
{
    public class VanCommand : IPayTollCommand
    {
        public decimal GetPrice()
        {
            return PriceConstants.VAN_PRICE;
        }
    }
}