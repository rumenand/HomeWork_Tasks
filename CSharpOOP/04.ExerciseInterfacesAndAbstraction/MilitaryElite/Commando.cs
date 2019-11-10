using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private List<Mission> missions;
        public Commando(int id, string firstName, string lastName, decimal salary, string corp, IEnumerable<string> listOfMissions) 
            : base(id, firstName, lastName, salary, corp)
        {
            this.Missions = GetMissions(listOfMissions);         
        }       

        public List<Mission> Missions
        {
            get => this.missions;
            private set => this.missions = new List<Mission>(value);            
        }

        public void CompleteMission(Mission mission)
        {
            var askedMission = this.missions.Where(x => x.CodeName == mission.CodeName).FirstOrDefault();
            if (askedMission != null) askedMission.State = "Finished";
        }

        private List<Mission> GetMissions(IEnumerable<string> listOfMissions)
        {
            var data = listOfMissions.ToArray();
            var listSelected = new List<Mission>();
            for (int i = 0; i < data.Length - 1; i +=2)
            {
                string state = data[i + 1];
                if (state == "inProgress" || state == "Finished")
                {
                    listSelected.Add(new Mission(data[i], data[i + 1]));
                }
            }
            return listSelected;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(this.GetName());
            sb.Append("Missions:");
            sb.Append(Environment.NewLine);
            foreach (var item in Missions)
            {
                sb.Append($"  {item.ToString()}");
                sb.Append(Environment.NewLine);
            }
            return sb.ToString().Trim();
        }
    }
}
