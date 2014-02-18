using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyIsland
{
    public class Stats
    {
        private int attackPower;
        private int accuracy;
        private int defence;

        public Stats(int attack, int accuracy, int defence)
        {
            this.attackPower = attack;
            this.accuracy = accuracy;
            this.defence = defence;
        }

        public int AttackPower
        {
            get { return this.attackPower; }
            set { this.attackPower = value; }
        }

        public int Accuracy
        {
            get { return this.accuracy; }
            set { this.accuracy = value; }
        }

        public int Defence
        {
            get { return this.defence; }
            set { this.defence = value; }
        }

        public decimal CalculateDefencePercentage()
        {
            return (100 - this.defence) / 100m;
        }

    }
}
