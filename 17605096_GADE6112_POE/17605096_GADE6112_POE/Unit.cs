using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17605096_GADE6112_POE
{
    public abstract class Unit
    {
        protected int xpos;
        protected int ypos;
        protected int health;
        protected int speed;
        protected int attack;
        protected int attackrange;
        protected int faction;
        protected string symbol;
        protected bool isAttacking;
        protected int maxHealth;
        protected string name;

        public abstract void Move(int dir);
        public abstract void Combat(Unit attacker);
        public abstract bool InRange(Unit other);
        public abstract (Unit, int) Closest(List<Unit> units);
        public abstract void Death();
        public abstract override string ToString();

    }
}
