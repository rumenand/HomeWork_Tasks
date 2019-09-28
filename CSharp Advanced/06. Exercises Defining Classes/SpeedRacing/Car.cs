using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    class Car
    {
        public int TravelledDistance { get; set; }
        public decimal FuelConsumptionPerKilometer { get; set; }
        public decimal FuelAmount { get; set; }   
        public string Model { get; set; }
        public bool Drive(int distance)
        {
            decimal neededFuel = distance * FuelConsumptionPerKilometer;
            if (FuelAmount >= neededFuel)
            {
                FuelAmount -= neededFuel;
                TravelledDistance += distance;
                return true;
            }
            return false;
        }
    }
}
