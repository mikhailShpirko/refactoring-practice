using System;
using System.Collections.Generic;
using System.Text;
using IMJunior.BLL.Operation;

namespace IMJunior.BLL
{
    public class CharacterBuilder: Character
    {

        private readonly Operations _availableOperations;
        public int AvailablePoints { get; private set; }

        public CharacterBuilder(int points,
                                Operations availableOperations)
        {
            if (points <= 0)
            {
                throw new ArgumentException("Поинтов должно быть больше 0");
            }
            AvailablePoints = points;
            _availableOperations = availableOperations;
        }

        public Character SpendPonts(int operandPoints, OperationType operationType, AbilityType targetAbilityType)
        {
            if (operandPoints > AvailablePoints)
            {
                throw new ArgumentException("Нехватает поинтов");
            }
            IOperation currentOperation = _availableOperations.GetOperation(operationType, operandPoints);
            ExecuteOperation(currentOperation, targetAbilityType);
            return this;
        }
        
        public Character Build(int age)
        {
            if (age <= 0)
            {
                throw new ArgumentException("Возраст должен быть больше 0");
            }
            return new Character(_abilities, age);
        }

        public override string ToString()
        {
            return $"Поинтов - {AvailablePoints}\n{AbilitiesToString()}";
        }

        private void ExecuteOperation(IOperation operation, AbilityType targetAbilityType)
        {
            _abilities[(int)targetAbilityType].UpdatePoints(operation.UpdateAbility);
            AvailablePoints = operation.UpdatePoints(AvailablePoints);
        }

    }
}
