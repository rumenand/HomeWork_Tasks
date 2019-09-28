using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;

        public double TravelledDistance
        {
            get { return travelledDistance; }
            set { travelledDistance = value; }
        }


        public double FuelConsumptionPerKilometer
        {
            get { return fuelConsumptionPerKilometer; }
            set { fuelConsumptionPerKilometer = value; }
        }
        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public bool Drive(int distance)
        {
            var neededFuel = distance * FuelConsumptionPerKilometer;
            if (fuelAmount > neededFuel)
            {
                fuelAmount -= neededFuel;
                travelledDistance += distance;
                return true;
            }
            return false;
        }
    }
}
