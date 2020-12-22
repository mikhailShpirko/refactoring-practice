using System;
using System.Collections.Generic;
using System.Text;
using TruckTour.BLL;

namespace TruckTour.ConsoleApp
{
    public class InputHelper
    {
        private readonly Action<string> _displayMessage;
        private readonly Func<string> _readUserInput;

        public InputHelper(Action<string> displayMessage,
            Func<string> readUserInput)
        {
            _displayMessage = displayMessage;
            _readUserInput = readUserInput;
        }

        private int GetIntInput()
        {
            var input = _readUserInput?.Invoke();
            if (!int.TryParse(input, out var intInput))
            {
                throw new Exception("Invalid input. Please enter a number");
            }
            return intInput;
        }

        private PumpStation GetPumpStation(int index)
        {
            while (true)
            {
                try
                {
                    var input = _readUserInput?.Invoke();
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        throw new Exception("Input must not be empty");
                    }

                    //should be 2 int split by space
                    var tokens = input.Split(' ');

                    if (tokens.Length != 2)
                    {
                        throw new Exception("Invalid input. Should be 2 integers split by space");
                    }

                    if (!int.TryParse(tokens[0], out var petrol))
                    {
                        throw new Exception("Petrol amount is not a number");
                    }

                    if (!int.TryParse(tokens[1], out var distanceToNextStation))
                    {
                        throw new Exception("Distance to next station is not a number");
                    }

                    return new PumpStation(index, petrol, distanceToNextStation);
                }
                catch (Exception e)
                {
                    _displayMessage?.Invoke(e.Message);
                }
            }
        }

        public int GetNumberOfStations()
        {
            _displayMessage?.Invoke("Enter number of stations");

            while (true)
            {
                try
                {
                    var numberOfStations = GetIntInput();
                    if (numberOfStations < 1)
                    {
                        throw new Exception("There should be at least 1 station");
                    }

                    return numberOfStations;
                }
                catch (Exception e)
                {
                    _displayMessage?.Invoke(e.Message);
                }              
            }            
        }

        public LinkedList<PumpStation> GetPimpStations(int numberOfStations)
        {
            _displayMessage?.Invoke("Enter information about petrol stations: amount of petrol and distance to next petrol split by space");

            var stations = new LinkedList<PumpStation>();

            for (var i = 0; i < numberOfStations; i++)
            {
                stations.AddLast(GetPumpStation(i));
            }

            return stations;
        } 
    }
}
