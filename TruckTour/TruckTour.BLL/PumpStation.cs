using System;

namespace TruckTour.BLL
{
    public class PumpStation
    {
        public int Index { get; private set; }
        public int Petrol { get; private set; }
        public int DistanceToNextStation { get; private set; }

        public int PetrolAfterReachingNextStationFromHere => Petrol - DistanceToNextStation;
        public bool HasEnoughPetrolToReachNextStationFromHere => PetrolAfterReachingNextStationFromHere > 0;

        public PumpStation(int index,
                            int petrol,
                            int distanceToNextStation)
        {
            if (index < 0)
            {
                throw new ArgumentException("Pump station Index must not be negative number");
            }

            if (petrol < 1)
            {
                throw new ArgumentException("Pump station must have some petrol");
            }

            if (distanceToNextStation < 1)
            {
                throw new ArgumentException("Invalid distance to next pump station");
            }

            Index = index;
            Petrol = petrol;
            DistanceToNextStation = distanceToNextStation;
        }

        public override bool Equals(object obj)
        {
            if (obj is PumpStation station)
            {
                return Index == station.Index;
            }
            return base.Equals(obj);
        }
    }
}
