
namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        public Rifle(string name) 
            : base(name, 50, 500)
        {
            this.bulletsPerShot = 5;
        }        
    }
}
