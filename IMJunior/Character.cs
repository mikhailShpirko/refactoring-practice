using IMJunior.Operation;
using System;
using System.Linq;


namespace IMJunior
{
    public class Character
    {
        private Ability[] _abilities;
        private int _age;
        private int _points;


        public int Points => _points;

        public Character(int points)
        {
            _points = points;
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

            _points = operation.UpdatePoints(_points);
        }


        public override string ToString()
        {
            return $"Возраст - {_age}\n{string.Join('\n', _abilities.Select(a => a.ToString()))}";
        }
    }
}
