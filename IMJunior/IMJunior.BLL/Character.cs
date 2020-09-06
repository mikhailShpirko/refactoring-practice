using IMJunior.BLL.Operation;
using IMJunior.Util;
using System.Linq;

namespace IMJunior.BLL
{
    public class Character
    {
        private Ability[] _abilities;
        private int _age;

        public int Points { get; private set; }

        public Character(int points)
        {
            Points = points;
            _abilities = new Ability[EnumExtensions.EnumArrayLength<AbilityType>()];
            foreach (AbilityType abilityType in EnumExtensions.EnumToArray<AbilityType>())
            {
                _abilities[(int)abilityType] = new Ability(abilityType);
            }
        }

        public void SetAge(int age)
        {
            _age = age;
        }

        public void SpendPoints(AbilityType abilityType, IOperation operation)
        {
            _abilities[(int)abilityType].UpdatePoints(operation.UpdateAbility);

            Points = operation.UpdatePoints(Points);
        }


        public override string ToString()
        {
            return $"Возраст - {_age}\n{string.Join('\n', _abilities.Select(a => a.ToString()))}";
        }
    }
}
