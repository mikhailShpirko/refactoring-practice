using System;
using TruckTour.BLL;

namespace TruckTour.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputHelper = new InputHelper(Console.WriteLine, Console.ReadLine);

            var numberOfStations = inputHelper.GetNumberOfStations();
            var stations = inputHelper.GetPimpStations(numberOfStations);

            var pathCalculator = new PathCalculator();

            var startIndex = pathCalculator.GetStartPumpStationIndex(stations);

            Console.WriteLine(startIndex);
            Console.ReadLine();
        }
    }
}
