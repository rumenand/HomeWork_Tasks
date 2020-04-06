
namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        public Pistol(string name) 
            : base(name, 10, 100)
        {
            this.bulletsPerShot = 1;
        }
    }
}
