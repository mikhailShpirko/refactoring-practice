using System;

namespace IMJunior.BLL.Operation
{
    public class SubtractOperation : BaseOperation
    {
       
        private int SubtractAbility(int abilityPoints)
        {
            int overhead = abilityPoints - _operandPoints;
            overhead = overhead < 0 ? overhead : 0;
           _operandPoints += overhead;

            return abilityPoints - _operandPoints;
        }

        private int AddPoints(int points)
        {
            return points + _operandPoints;
        }

        public override Func<int, int> UpdateAbility => SubtractAbility;

        public override Func<int, int> UpdatePoints => AddPoints;
    }
}
