using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warcraftlogs
{
    class Player
    {
        private int parse1;
        private string nev { get; }
        private int amount { get; }
        private int felszerelesLevel { get; }
        private int teljesitmenyLevel { get; }
        private double parse2 { get; }
        private float dps { get; }
       
        public Player()
        {

        }
        public Player(int parse1, string nev, int amount, int felszerelesLevel, int teljesitmenyLevel, double parse2, float dps)
        {
            this.parse1 = parse1;
            this.nev = nev;
            this.amount = amount;
            this.felszerelesLevel = felszerelesLevel;
            this.teljesitmenyLevel = teljesitmenyLevel;
            this.parse2 = parse2;
            this.dps = dps;
        }

        public int getFelszerelesLevel()
        {
            return this.felszerelesLevel;
        }
        public int getTeljesitmenyLevel()
        {
            return this.teljesitmenyLevel;
        }
        public int getParse1()
        {
            return this.parse1;
        }

        public string getNev()
        {
            return this.nev;
        }

        public double getParse2()
        {
            return this.parse2;
        }

        public int getAmount()
        {
            return this.amount;
        }

        public float getDps()
        {
            return this.dps;
        }


        public override string ToString()
        {

            return string.Format("{0} {1} {2} {3} {4} {5} {6}", this.parse1,
                this.nev,
                this.amount,
                this.felszerelesLevel,
                this.teljesitmenyLevel,
                this.parse2,
                this.dps);
        }
    }
}
