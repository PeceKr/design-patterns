namespace DesignPatterns.Strategy.Services.Commands
{
    public class MotorBikeCommand : IPayTollCommand
    {
        public decimal GetPrice()
        {
            return 10.3m;
        }
    }
}