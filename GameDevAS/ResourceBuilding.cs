using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevAS
{
    [Serializable]
     public class ResourceBuilding: Building
    {
        private int ResType;

        public int resType
        {
            get { return resType; }
            set { resType = value; }
        }
        private int respertick;

        public int Respertick
        {
            get { return Respertick; }
            set { Respertick = value; }
        }
        private int resourceRemaing;

        public int ResRemaing
        {
            get { return resourceRemaing; }
            set { resourceRemaing = value; }
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

        public ResourceBuilding(int X_position, int Y_position, int Health, int Faction, string Symbol, int rt, int rpt, int rr)
        {
            Xpos = X_position;
            Ypos = Y_position;
            health = Health;
            Fact = Faction;
            symbol = Symbol;
            ResType = rt;
            respertick = rpt;
            ResRemaing = rr;

        }
        public override bool isDestoryed()
        {
            return false;
        }
        public override string toString()
        {
            return "Symbol "+symbol+"\r\nXpos: "+Xpos+"\r\nYpos "+Ypos ;
        }
       
        
        public void resourceDepletion()
        {
           ResRemaing = ResRemaing-Respertick;

        }
        public override void Save()
        {

        }

    }
}
