
using System;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        public double averageSkills;
        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
            this.averageSkills = Math.Round((endurance + sprint + dribble + passing + shooting) /(double)5,0);
        }

        public string Name { get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("A name should not be empty.");
                this.name = value;
            }
        }
        private int Endurance{
            set
            {
                ValidateValue(value, nameof(Endurance));
                this.endurance = value;
            }
        }      

        public int Sprint
        {
            set
            {
                ValidateValue(value, nameof(Sprint));
                this.sprint = value;
            }
        }
        public int Dribble
        {
            set
            {
                ValidateValue(value, nameof(Dribble));
                this.dribble = value;
            }
        }
        public int Passing
        {
            set
            {
                ValidateValue(value, nameof(Passing));
                this.passing = value;
            }
        }
        public int Shooting
        {
            set
            {
                ValidateValue(value, nameof(Shooting));
                this.shooting = value;
            }
        }

        private void ValidateValue(int value, string v)
        {
            if (value < 0 || value > 100) throw new ArgumentException($"{v} should be between 0 and 100.");
        }
    }
}
