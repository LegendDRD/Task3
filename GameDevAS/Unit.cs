using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevAS
{
    
    public enum Direction { Nort, East, South, West }
    [Serializable]
    public abstract class Unit
    {
        
        protected string Name;
        protected int X_position;
        protected int Y_position;
        protected int Health;
        protected int Speed;
        protected int Attack;
        protected int Attack_range;
        protected int Faction;
        protected string Symbol;

        public Unit() { }
        abstract public void NewMovePos(Direction direction);
        abstract public void Combat(Unit u);
        abstract public bool AttackRange(Unit u);
        abstract public Unit UnitDistance(Unit[] units);
        abstract public bool isDead();
        abstract public string ToString();
        abstract public void Save();

    }
}
