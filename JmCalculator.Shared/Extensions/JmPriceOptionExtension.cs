using JmCalculator.Shared.Domain;
using JmCalculator.Shared.Models;
using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace JmCalculator.Shared.Extensions
{
    public static class JmOptionExtensions
    {
        public static JmOptionDomain CreateOption<T>(this T value, decimal price, JmOperationTypes operationType)
            where T : Enum
        {
            return CreateOption(value,
                price,
                JmUnitTypes.JmComfort | JmUnitTypes.JmComfortWired | JmUnitTypes.JmConsole | JmUnitTypes.JmProfi70 | JmUnitTypes.JmProfi90,
                operationType);
        }

        public static JmOptionDomain CreateOption<T>(this T value, decimal price, JmUnitTypes unitType)
            where T : Enum
        {
            return CreateOption(value,
                price,
                unitType,
                JmOperationTypes.Hand | JmOperationTypes.Motor);
        }

        public static JmOptionDomain CreateOption<T>(this T value, decimal price = 0)
            where T : Enum
        {
            return CreateOption(value,
                price,
                JmUnitTypes.JmComfort | JmUnitTypes.JmComfortWired | JmUnitTypes.JmConsole | JmUnitTypes.JmProfi70 | JmUnitTypes.JmProfi90,
                JmOperationTypes.Hand | JmOperationTypes.Motor);
        }

        public static JmOptionDomain CreateOption<T>(this T value,
            decimal price,
            JmUnitTypes unitType,
            JmOperationTypes operationTypes)
            where T : Enum
        {
            return new JmOptionDomain
            {
                Name = Enum.GetName(typeof(T), value),
                Type = typeof(T).FullName,
                UnitType = unitType,
                Price = price,
                OperationType = operationTypes
            };
        }

        public static JmOptionDomain CreateDomain(this JmOption option)
        {
            return new JmOptionDomain
            {
                OperationType = option.OperationType,
                UnitType = option.UnitType,
                Name = option.Name,
                Type = option.Type,
                Price = option.Price

            };
        }

        public static JmOptionRequest CreateOptionRequest(this JmPriceRequest request)
        {
            return new JmOptionRequest
            {
                OperationType = request.OperationType,
                UnitType = request.UnitType
            };
        }

        public static string GetDescription(this JmOptionDomain option)
        {
            var member = Type.GetType(option.Type)
                .GetMember(option.Name)
                .FirstOrDefault();

            var attribute =   member?.GetCustomAttribute<DescriptionAttribute>();

            return
                attribute != null ?
                attribute.Description :
                member.Name;
                
        }

    }


    public static class JmEnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var member = value
                .GetType()
                .GetMember(value.ToString())
                .FirstOrDefault();

            var attribute = member?.GetCustomAttribute<DescriptionAttribute>();

            return
                attribute != null ?
                attribute.Description :
                member.Name;
        }
    }
}
