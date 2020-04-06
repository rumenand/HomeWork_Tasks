using System.Collections.Generic;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players.Contracts;
using System.Linq;

namespace ViceCity.Models.Neghbourhoods
{
    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            while (mainPlayer.GunRepository.Models.Count>0 && civilPlayers.Count>0)
            {
                var currentGun = mainPlayer.GunRepository.Models.First();
                var currentEnemy = civilPlayers.First();
                currentEnemy.TakeLifePoints(currentGun.Fire());
                if (!currentGun.CanFire) mainPlayer.GunRepository.Remove(currentGun);
                if (!currentEnemy.IsAlive) civilPlayers.Remove(currentEnemy);                
            }
            var shoters = civilPlayers.ToList();
            while(shoters.Count>0 && mainPlayer.IsAlive)
            {                 
                var currentEnemy = shoters.First();
              
                if (currentEnemy.GunRepository.Models.Count==0)
                {
                    shoters.Remove(currentEnemy);
                    continue;
                }
                var currentGun = currentEnemy.GunRepository.Models.First();                
               
                mainPlayer.TakeLifePoints(currentGun.Fire());
                if (!currentGun.CanFire)
                {
                    currentEnemy.GunRepository.Remove(currentGun);                       
                }                
            }
        }
    }
}
