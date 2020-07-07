using System;
using System.Collections.Generic;
using System.Text;

namespace IMJunior
{
    public class Ability
    {
        private int _points;

        public readonly AbilityType Type;

        public Ability(AbilityType type)
        {
            Type = type;
            _points = 0;
        }

        public void UpdatePoints(Func<int, int> updater)
        {
            _points = updater(_points);
        }

        public override string ToString()
        {
            return $"{Type.GetDescription()} - [{"".PadLeft(_points, '#').PadRight(10, '_')}]";
        }
    }
}
