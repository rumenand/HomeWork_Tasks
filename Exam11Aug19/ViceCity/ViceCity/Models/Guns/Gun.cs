using ViceCity.Models.Guns.Contracts;
using System;

namespace ViceCity.Models.Guns
{
    public abstract class Gun : IGun
    {
        protected int currentBullets;
        protected Gun(string name, int bulletsPerBarrel, int totalBullets)
        {
            this.currentBullets = 0;
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be null or a white space!");
            this.Name = name;
            if (bulletsPerBarrel < 0) throw new ArgumentException("Bullets cannot be below zero!");
            this.BulletsPerBarrel = bulletsPerBarrel;
            if (totalBullets < 0) throw new ArgumentException("Total bullets cannot be below zero!");
            this.TotalBullets = totalBullets;
            this.Reload();
        }
        public string Name { get; }

        public int BulletsPerBarrel { get; }

        public int TotalBullets { get; protected set; }

        public bool CanFire => this.TotalBullets>0 || this.currentBullets>this.BulletsPerBarrel;

        public abstract int Fire();

        protected bool Reload()
        {
            if (!this.CanFire) return false;
            if (this.TotalBullets > this.BulletsPerBarrel)
            {
                this.TotalBullets -= BulletsPerBarrel;
                this.currentBullets = this.TotalBullets;                
            }
            this.currentBullets = this.TotalBullets;
            this.TotalBullets = 0;
            return true;
        }
    }
}
