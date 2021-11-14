using DesignPatterns.Strategy.Constants;

namespace DesignPatterns.Strategy.Services.Commands
{
    public class MotorBikeCommand : IPayTollCommand
    {
        public decimal GetPrice()
        {
            return PriceConstants.MOTOR_BIKE_PRICE;
        }
    }
}