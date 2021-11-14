using static DesignPatterns.Strategy.Enums.VehicleEnums;

namespace DesignPatterns.Strategy.Services
{
    public interface IPayTollServices
    {
        decimal GetPrice(VehicleTypes vehicleType);
    }
}