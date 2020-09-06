using IMJunior.BLL;
using IMJunior.BLL.Operation;
using System;
using System.Text;

namespace IMJunior.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //на английской версии винды выводит ? вместо кирилицы
            //смена кодировки фиксит проблему
            Console.OutputEncoding = Encoding.UTF8;

            Character character = new Character(25);
            InputHelper inputHelper = new InputHelper();
            Operations availableOperations = new Operations();


            Console.WriteLine("Добро пожаловать в меню выбора создания персонажа!");
            Console.WriteLine("У вас есть 25 очков, которые вы можете распределить по умениям");
            Console.WriteLine("Нажмите любую клавишу чтобы продолжить...");
            Console.ReadKey();

            while (character.Points > 0)
            {
                Console.Clear();

                Console.WriteLine("Поинтов - {0}", character.Points);
                Console.WriteLine(character.ToString());

                Console.WriteLine("Какую характеристику вы хотите изменить?");
                AbilityType abilityType = inputHelper.GetAbilityType();

                Console.WriteLine(@"Что вы хотите сделать? +\-");
                OperationType operationType = inputHelper.GetOperationType();

                Console.WriteLine(@"Колличество поинтов которые следует {0}", operationType == OperationType.Add ? "прибавить" : "отнять");

                int operandPoints = inputHelper.GetNumber();

                IOperation currentOperation = availableOperations.GetOperation(operationType, operandPoints);
                character.SpendPoints(abilityType, currentOperation);
            }

            Console.WriteLine("Вы распределили все очки. Введите возраст персонажа:");

            character.SetAge(inputHelper.GetNumber());

            Console.Clear();

            Console.WriteLine(character.ToString());
            Console.ReadKey();
        }
    }
}
