using System.ComponentModel;

namespace IMJunior.BLL
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
