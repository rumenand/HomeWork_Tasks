﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public string RegistrationNumber { get; set; }

        public Car (string make, string model, int hoursePower, string registrationNumber)
        {
            this.Make = make;
            this.Model = model;
            this.HorsePower = hoursePower;
            this.RegistrationNumber = registrationNumber;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Make: {this.Make}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"HorsePower: {this.HorsePower}");
            sb.AppendLine($"RegistrationNumber: {this.RegistrationNumber}");
            return sb.ToString().Trim();
        }
    }
}
