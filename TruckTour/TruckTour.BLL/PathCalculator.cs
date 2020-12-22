using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TruckTour.Util;

namespace TruckTour.BLL
{
    public class PathCalculator
    {
        public int GetStartPumpStationIndex(LinkedList<PumpStation> stations)
        {
            var stationsList = stations.ToList();
            //special case - overall not enough petrol to reach the distance
            if (stationsList.Sum(s => s.Petrol) < stationsList.Sum(s => s.DistanceToNextStation))
            {
                return -1;
            }

            //by default we can start from first station
            var startIndex = 0;

            //get the stations from where we can't reach further if we start from here
            var stationsCantStartFrom = stationsList.Where(s => !s.HasEnoughPetrolToReachNextStationFromHere);

            //if we are not going in this loop - all stations by default have enough petrol to go further 
            //without considering previous stations
            foreach (var station in stationsCantStartFrom)
            {
                //go backwards and check where we should start to reach this station

                var stationNode = stations.Find(station);
                var petrolLeft = station.PetrolAfterReachingNextStationFromHere;

                LinkedListNode<PumpStation> previousStationNode;

                do
                {
                    previousStationNode = stationNode.PreviousOrLast();
                    var previousStation = previousStationNode.Value;

                    petrolLeft = petrolLeft + previousStation.PetrolAfterReachingNextStationFromHere;

                    //we can reach here starting from this station
                    if (petrolLeft > 0)
                    {
                        //can be the following case:
                        //station from where we don't have enough petrol is 5th
                        //but we can reach there starting from 3rd
                        //so it means we still can start from 1st and make whe whole loop

                        //othervise, we should start from station which is further from the station 
                        //where we don't have enough petrol

                        //additionally, station.Index < previousStation.Index - means that 
                        //we should start further form the station
                        //but if previousStation.Index > startIndex means that
                        //previously set starting index is still valid and we can reach the station from that one
                        //no need to increment the index as the result will be not the smallest index of station
                        //from where we can start from
                        if (!(station.Index < previousStation.Index && previousStation.Index > startIndex))
                        {
                            startIndex = previousStation.Index;
                            break;
                        }
                    }

                } while (stationNode == previousStationNode);

            }

            return startIndex;
        }
    }
}
