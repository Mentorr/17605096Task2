using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17605096_GADE6112_POE
{
    public abstract class Building
    {
        protected int xpos;
        protected int ypos;
        protected int health;
        protected int maxHealth;
        protected int faction;
        protected string symbol;

        public abstract void Death();
        public abstract override string ToString();
        public abstract void Save();
    }
}
