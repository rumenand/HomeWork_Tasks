﻿using System;

namespace CarManufacturer
{
    class Car
    {
        private string make;
        private string model;
        private int year;

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public string Make
        {
            get { return make; }
            set { make = value; }
        }
    }
}
