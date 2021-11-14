using System;
using System.Collections.Generic;
using System.Linq;
using DesignPatterns.Strategy.Services.Commands;
using static DesignPatterns.Strategy.Enums.VehicleEnums;

namespace DesignPatterns.Strategy.Services
{
    public class PayTollServices : IPayTollServices
    {
        private IPayTollCommand _payTollCommand;
        private readonly Dictionary<VehicleTypes, Func<IPayTollCommand>> commands = new Dictionary<VehicleTypes, Func<IPayTollCommand>>();
        public decimal GetPrice(VehicleTypes vehicleType)
        {            
            // Check if we need to register commands
            RegisterCommands();

            // Create the client 
            var commandClient = Client(vehicleType);

            // Execute the action
            return commandClient.GetPrice();
        }

        IPayTollCommand Client(VehicleTypes leaderboardType)
        {
            Func<IPayTollCommand> _func;
            if (commands.TryGetValue(leaderboardType, out _func))
            {
                _payTollCommand = _func.Invoke();
            }

            return _payTollCommand ?? default;
        }

        private void RegisterCommands()
        {
            if (!commands.Any())
            {
                commands.TryAdd(VehicleTypes.Bus, () => new BussCommand());
                commands.TryAdd(VehicleTypes.Car, () => new CarCommand());
                commands.TryAdd(VehicleTypes.MotorBike, () => new MotorBikeCommand());
                commands.TryAdd(VehicleTypes.Van, () => new VanCommand());
            }
        }
    }
}