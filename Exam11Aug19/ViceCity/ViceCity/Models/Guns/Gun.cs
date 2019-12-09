using ViceCity.Models.Guns.Contracts;
using System;

namespace ViceCity.Models.Guns
{
    public abstract class Gun : IGun
    {
        protected int bulletsPerShot;
        private int currentBullets;

        protected Gun(string name, int bulletsPerBarrel, int totalBullets)
        {
            this.currentBullets = 0;
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be null or a white space!");
            this.Name = name;
            if (bulletsPerBarrel < 0) throw new ArgumentException("Bullets cannot be below zero!");
            this.BulletsPerBarrel = bulletsPerBarrel;
            if (totalBullets < 0) throw new ArgumentException("Total bullets cannot be below zero!");
            this.TotalBullets = totalBullets;
        }
        public string Name { get; }

        public int BulletsPerBarrel { get; }

        public int TotalBullets { get; protected set; }

        public bool CanFire => this.currentBullets+this.TotalBullets>=bulletsPerShot;

        public int Fire()
        {
            if (this.currentBullets >= bulletsPerShot)
            {
                this.currentBullets -= bulletsPerShot;               
                return bulletsPerShot;
            }
            else if (this.Reload()) return this.Fire();
            return 0;
        }

        protected bool Reload()
        {
            if (this.TotalBullets == 0) return false;
            if (this.TotalBullets > this.BulletsPerBarrel)
            {
                this.TotalBullets -= BulletsPerBarrel;
                this.currentBullets = this.BulletsPerBarrel;
                return true;
            }
            this.currentBullets = this.TotalBullets;
            this.TotalBullets = 0;
            return true;
        }
    }
}
