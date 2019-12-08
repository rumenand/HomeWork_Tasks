using System.Text;
using System.Collections.Generic;
using System.Linq;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Players.Contracts;
using ViceCity.Models.Players;
using ViceCity.Models.Neghbourhoods;
using System;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private List<IPlayer> civilPlayers;
        private Queue<IGun> guns;
        private MainPlayer mainPlayer;

        public Controller()
        {
            this.civilPlayers = new List<IPlayer>();
            this.guns = new Queue<IGun>();
            this.mainPlayer = new MainPlayer();
        }
        public string AddGun(string type, string name)
        {
           switch (type)
            {
                case "Pistol": this.guns.Enqueue(new Pistol(name));break;
                case "Rifle": this.guns.Enqueue(new Rifle(name)); break;
                default: return "Invalid gun type!";
            }
            return $"Successfully added {name} of type: {type}";
        }

        public string AddGunToPlayer(string name)
        {
            if (guns.Count == 0) return "There are no guns in the queue!";
            var currentGun = this.guns.Dequeue();
            if (name == "Vercetti")
            {                
                mainPlayer.GunRepository.Add(currentGun);
                return $"Successfully added {currentGun.Name} to the Main Player: Tommy Vercetti";                
            }
            var currentCivil = this.civilPlayers.Where(x => x.Name == name).FirstOrDefault();
            if (currentCivil == null) return "Civil player with that name doesn't exists!";
            currentCivil.GunRepository.Add(currentGun);
            return $"Successfully added {currentGun.Name} to the Civil Player: {name}";
        }

        public string AddPlayer(string name)
        {
            this.civilPlayers.Add(new CivilPlayer(name));
            return $"Successfully added civil player: {name}!";
        }

        public string Fight()
        {
            var mainPlInitialHealt = this.mainPlayer.LifePoints;
            var civilInitialHealts = this.civilPlayers.ToList();
            new GangNeighbourhood().Action(this.mainPlayer, civilPlayers);
            if (mainPlInitialHealt == this.mainPlayer.LifePoints && CheckForCasulties(civilInitialHealts, this.civilPlayers))
                return "Everything is okay!";
            else
            {
                var deadCivils = civilInitialHealts.Count - this.civilPlayers.Count;
                var sb = new StringBuilder();
                sb.AppendLine("A fight happened:");
                sb.AppendLine($"Tommy live points: {this.mainPlayer.LifePoints}!");
                sb.AppendLine($"Tommy has killed: {deadCivils} players!");
                sb.AppendLine($"Left Civil Players: {this.civilPlayers.Count}!");
                return sb.ToString().TrimEnd();
            }
        }

        private bool CheckForCasulties(List<IPlayer> civilInitialHealts, List<IPlayer> civilPlayers)
        {
            if (civilInitialHealts.Count != civilPlayers.Count) return false;
            for (int i = 0; i < civilInitialHealts.Count; i++)
            {
                if (civilInitialHealts[i].LifePoints != civilPlayers[i].LifePoints)
                    return false;
            }
            return true;
        }
    }
}
