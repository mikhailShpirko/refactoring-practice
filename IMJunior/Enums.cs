using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace IMJunior
{
    public enum AbilityType
    {
        [Description("Сила")]
        Strength,
        [Description("Ловкость")]
        Agility,
        [Description("Интелект")]
        Intelligence
    }

    public enum OperationType
    {
        [Description("+")]
        Add,
        [Description("-")]
        Subtract
    }
}
