namespace DesignPatterns.Strategy.Services.Commands
{
    public class VanCommand : IPayTollCommand
    {
        public decimal GetPrice()
        {
            return 30.6m;
        }
    }
}