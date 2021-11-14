namespace DesignPatterns.Strategy.Services.Commands
{
    public class CarCommand : IPayTollCommand
    {
        public decimal GetPrice()
        {
            return 20.0m;
        }
    }
}