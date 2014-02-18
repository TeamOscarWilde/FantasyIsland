using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyIsland
{
    public class Stats
    {
        protected int attackPower;
        protected int accuracy;
        protected int defence;

        public Stats(int attack, int accuracy, int defence)
        {
            this.attackPower = attack;
            this.accuracy = accuracy;
            this.defence = defence;
        }

        public int AttackPower
        {
            get { return this.attackPower; }
            protected set { }
        }

        public int Accuracy
        {
            get { return this.accuracy; }
            protected set { }
        }

        public int Defence
        {
            get { return this.defence; }
            protected set { }
        }
    }
}
