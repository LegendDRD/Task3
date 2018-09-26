using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevAS
{
    [Serializable]
    class FactoryBuilding: Building
    {
        private int units;

        public int Units
        {
            get { return units; }
            set { units = value; }
        }
        private int productionrate;

        public int Productionrate
        {
            get { return Productionrate; }
            set { Productionrate = value; }
        }
        private int spawnpt;

        public int SpawnPt
        {
            get { return spawnpt; }
            set { spawnpt = value; }
        }



        public int Xpos
        {
            get { return X_position; }
            set { X_position = value; }
        }
        public int Ypos
        {
            get { return Y_position; }
            set { Y_position = value; }
        }
        public int health
        {
            get { return Health; }
            set { Health = value; }
        }

        public int Fact
        {
            get { return Faction; }
            set { Faction = value; }
        }
        public string symbol
        {
            get { return Symbol; }
            set { Symbol = value; }
        }

        public FactoryBuilding(int X_position, int Y_position, int Health, int Faction, string symbol, int unita, int pr,int spawn)// this constructor add all the imforamtion that is passed through to fill out the units imformations
        {
            Xpos = X_position;
            Ypos = Y_position;
            health = Health;
            Fact = Faction;
            Symbol = symbol;
            units = unita;
            productionrate = pr;
            spawnpt = spawn;

        }
        public override bool isDestoryed()
        {
            return false;
        }
        public override string toString()// this gets all the imformation to display it 
        {
            return "Factory"+"\r\nXpos: "+Xpos+"\r\nYpos: "+Ypos+"\r\nHealth: "+health+"\r\nFaction: "+Faction+"\r\nProductionRate: "+productionrate;
        }
        public Unit SpawnUnits(Unit unit)
        {
            Random r = new Random();
            

            MeleeUnits M = new MeleeUnits(r.Next(0, 10), r.Next(0, 10), r.Next(5, 10) * 10, r.Next(5, 20), 1, 1, 1 % 2, "}", "Knight");
            return M;
           
            
              
        }
        public override void Save()
        {

        }



    }
}
