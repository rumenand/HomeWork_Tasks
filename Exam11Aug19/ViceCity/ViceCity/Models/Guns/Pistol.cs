
namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private int bulletsPerShot=1;
        public Pistol(string name) 
            : base(name, 10, 100)
        {
        }

        public override int Fire()
        {
            if (this.currentBullets >= bulletsPerShot)
            {
                this.currentBullets -= bulletsPerShot;
                return bulletsPerShot;
            }
            else if (this.Reload()) this.Fire();
            return 0;
        }
    }
}
