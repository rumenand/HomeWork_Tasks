﻿
namespace NeedForSpeed
{
    class SportCar : Car
    {
        public SportCar(int horsePower, double fuel) : base(horsePower,fuel)
        {
            this.DefaultFuelConsumption = 10;
        }
    }
}
