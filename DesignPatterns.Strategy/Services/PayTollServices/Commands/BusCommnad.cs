namespace DesignPatterns.Strategy.Services.Commands
{
    public class BussCommand : IPayTollCommand
    {
        public decimal GetPrice()
        {
            return 44.3m;
        }
    }
}