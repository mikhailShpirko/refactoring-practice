using IMJunior.BLL.Operation;
using IMJunior.Util;
using System.Linq;

namespace IMJunior.BLL
{
    public class Character
    {
        protected readonly Ability[] _abilities;
        private readonly int _age;

        public Character()
        {
            _abilities = new Ability[EnumExtensions.EnumArrayLength<AbilityType>()];
            foreach (AbilityType abilityType in EnumExtensions.EnumToArray<AbilityType>())
            {
                _abilities[(int)abilityType] = new Ability(abilityType);
            }
        }

        public Character(Ability[] abilities,
                        int age)
        {
            _abilities = abilities;
            _age = age;
        }

        public override string ToString()
        {
            return $"Возраст - {_age}\n{AbilitiesToString()}";
        }

        protected string AbilitiesToString()
        {
            return string.Join('\n', _abilities.Select(a => a.ToString()));
        }
    }
}
