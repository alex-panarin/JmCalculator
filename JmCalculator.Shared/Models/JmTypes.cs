using System;
using System.ComponentModel;

namespace JmCalculator.Shared.Models
{
    [Flags]
    public enum JmUnitTypes : byte
    {
        [Description("JmComfort с направляющими")]
        JmComfort = 1,
        [Description("JmComfort с тросом")]
        JmComfortWired = 2,
        [Description("JmComfort консоль")]
        JmConsole = 4,
        [Description("JmProfi 90")]
        JmProfi90 = 8,
        [Description("JmProfi 70")]
        JmProfi70 = 16
    }

    public enum JmHeadrailBracketTypes : byte
    {
        [Description("Без кронштейнов")]
        Without,
        MD1a,
        DK3,
        DK5,
        DK6,
        DK5c,
        MD2a,
        MD2b,
        MD1c
    }

    public enum JmRailBracketTypes : byte
    {
        [Description("Без кронштейнов")]
        Without,
        K1,
        K2,
        K3,
        TK3,
        TK4,
        TK5,
        TK6
    }

    public enum JmWireBracketTypes : byte
    {
        [Description("Без кронштейнов")]
        Without,
        DL1,
        DL2,
        DL3,
        DL4
    }

    [Flags]
    public enum JmOperationTypes : byte
    {
        [Description("Без управления")]
        Without,
        [Description("Ручное управление")]
        Hand,
        [Description("Управление двигателем")]
        Motor
    }

    public enum JmMotorOperationTypes : byte
    {
        [Description("Двигатель SOMFY 6Hm")]
        SOMFY6,
        [Description("Двигатель SOMFY 10Hm")]
        SOMFY10,
        [Description("Двигатель SOMFY 18Hm")]
        SOMFY18,
        [Description("Двигатель SOMFY 6Hm RTS")]
        SOMFY6RTS,
        [Description("Двигатель SOMFY 10Hm RTS")]
        SOMFY10RTS
    }

    
    public enum JmHandOperationTypes : byte
    {
        [Description("Стандартный редуктор")]
        ExteriorGear,
        [Description("Интерьерный редуктор")]
        InteriorGear
    }

    public enum JmColorTypes : byte
    {
        [Description("Без покраски")]
        Without,
        RAL1015,
        RAL7016,
        RAL8014,
        RAL8017,
        RAL9003,
        RAL9005,
        RAL9006,
        RAL9007
    }

    public enum JmComponentColorTypes : byte
    {
        [Description("Серый")]
        Grey,
        [Description("Черный")]
        Black
    }

    public enum JmGuidingRailTypes : byte
    {
        [Description("Без направляющих")]
        Without,
        VL2,
        VL3,
        VL6,
        VL7
    }
}
