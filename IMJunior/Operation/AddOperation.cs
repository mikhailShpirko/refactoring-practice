using System;
using System.Collections.Generic;
using System.Text;

namespace IMJunior.Operation
{
    public class AddOperation : BaseOperation
    {

        private int AddAbility(int abilityPoints)
        {
            int overhead = _operandPoints - (10 - abilityPoints);
            overhead = overhead < 0 ? 0 : overhead;
            _operandPoints -= overhead;

            return abilityPoints + _operandPoints;
        }

        private int SubtractPoints(int points)
        {
            return points - _operandPoints;
        }

        public override Func<int, int> UpdateAbility => AddAbility;

        public override Func<int, int> UpdatePoints => SubtractPoints;
    }
}
