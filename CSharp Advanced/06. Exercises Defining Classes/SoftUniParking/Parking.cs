using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    class Parking
    {
        public  List<Car> parkedCars { get; set; }       

        public int Count
        {
            get { return parkedCars.Count; }           
        }

        private int capacity;
        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.parkedCars = new List<Car>();
        }

        public string AddCar(Car car)
        {
            if (parkedCars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
                return "Car with that registration number, already exists!";
            if (parkedCars.Count == capacity)
                return "Parking is full!";
            parkedCars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrateNumber)
        {
            int index = parkedCars.FindIndex(x => x.RegistrationNumber == registrateNumber);
            if (index >-1)
            {
                parkedCars.RemoveAt(index);
                return $"Successfully removed {registrateNumber}";
            }                
            else return $"Car with that registration number, doesn't exist!";
        }

        public Car GetCar(string registrationNumber)
        {
            int index = parkedCars.FindIndex(x => x.RegistrationNumber == registrationNumber);
            if (index > -1)  return parkedCars[index];
            return null;            
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var plateNum in registrationNumbers)
            {
                this.RemoveCar(plateNum);
            }
        }
    }
}
