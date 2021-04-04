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
            try
            {           
                //на английской версии винды выводит ? вместо кирилицы
                //смена кодировки фиксит проблему
                Console.OutputEncoding = Encoding.UTF8;

                CharacterBuilder characterBuilder = new CharacterBuilder(25, new Operations());
                InputHelper inputHelper = new InputHelper();


                Console.WriteLine("Добро пожаловать в меню выбора создания персонажа!");
                Console.WriteLine("У вас есть 25 очков, которые вы можете распределить по умениям");
                Console.WriteLine("Нажмите любую клавишу чтобы продолжить...");
                Console.ReadKey();

                while (characterBuilder.AvailablePoints > 0)
                {
                    try
                    {                   
                        Console.Clear();

                        Console.WriteLine(characterBuilder.ToString());

                        Console.WriteLine("Какую характеристику вы хотите изменить?");
                        AbilityType abilityType = inputHelper.GetAbilityType();

                        Console.WriteLine(@"Что вы хотите сделать? +\-");
                        OperationType operationType = inputHelper.GetOperationType();

                        Console.WriteLine(@"Колличество поинтов которые следует {0}", operationType == OperationType.Add ? "прибавить" : "отнять");

                        int operandPoints = inputHelper.GetPositiveNumberWithLimit(characterBuilder.AvailablePoints);

                        characterBuilder.SpendPonts(operandPoints, operationType, abilityType);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Ошибка при распределении очков: {e.Message}");
                    }
                }

                Console.WriteLine("Вы распределили все очки. Введите возраст персонажа:");

                Character character = characterBuilder.Build(inputHelper.GetPositiveNumber());

                Console.Clear();

                Console.WriteLine(character.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine($"Произошла ошибка: {e.Message}");
            }

            Console.ReadKey();
        }
    }
}
