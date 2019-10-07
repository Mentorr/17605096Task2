using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17605096_GADE6112_POE
{ [Serializable]
    class RangedUnit : Unit
    {
        public bool IsDead { get; set; }
        public int Xpos
        {
            get { return base.xpos; }
            set { base.xpos = value; }
        }
        public int Ypos
        {
            get { return base.ypos; }
            set { base.ypos = value; }
        }
        public int Health
        {
            get { return base.health; }
            set { base.health = value; }
        }
        public int Speed
        {
            get { return base.speed; }
            set { base.speed = value; }
        }
        public int Attack
        {
            get { return base.attack; }
            set { base.attack = value; }
        }
        public int Attackrange
        {
            get { return base.attackrange; }
            set { base.attackrange = value; }
        }
        public int Faction
        {
            get { return base.faction; }
            set { base.faction = value; }
        }
        public string Symbol
        {
            get { return base.symbol; }
            set { base.symbol = value; }
        }
        public int MaxHealth
        {
            get { return base.maxHealth; }
        }
        public bool isAttacking
        {
            get { return base.isAttacking; }
            set { base.isAttacking = value; }
        }
        public string Name
        {
            get { return base.name; }
            set { base.name = value; }
        }



        public RangedUnit(int x, int y, int h, int s, int a, int ar, int f, string symb, string na)
        {
            Xpos = x;
            Ypos = y;
            Health = h;
            Speed = s;
            Attack = a;
            Attackrange = ar;
            base.faction = f;
            base.maxHealth = h;
            Symbol = symb;
            isAttacking = false;
            IsDead = false;
            Name = na;
        }

        public override void Death()
        {
            Symbol = "X";
            IsDead = true;
        }
        public override void Move(int direction)
        {
            switch (direction)
            {
                case 0:
                    Ypos--;
                    break;
                case 1:
                    Xpos++;
                    break;
                case 2:
                    Ypos++;
                    break;
                case 3:
                    Xpos--;
                    break;
                default: break;
            }
        }
        public override void Combat(Unit attacker)
        {
            if (attacker is MeleeUnit)
            {
                Health = Health - ((MeleeUnit)attacker).Attack;
            }
            else if (attacker is RangedUnit)
            {
                RangedUnit ru = (RangedUnit)attacker;
                Health = Health - (ru.attack - ru.attackrange);
            }
            if (Health <= 0)
            {
                Death();
            }
        }
        public override bool InRange(Unit other)
        {
            int distance = 0;
            int otherx = 0;
            int othery = 0;
            if (other is MeleeUnit)
            {
                otherx = ((MeleeUnit)other).Xpos;
                othery = ((MeleeUnit)other).Ypos;
            }
            else if (other is RangedUnit)
            {
                otherx = ((RangedUnit)other).Xpos;
                othery = ((RangedUnit)other).Ypos;
            }

            distance = Math.Abs(Xpos - otherx) + Math.Abs(Ypos - othery);
            if (distance <= Attackrange)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override (Unit, int) Closest(List<Unit> units)
        {
            int shortest = 100;
            Unit closest = this;
            foreach (Unit u in units)
            {
                if (u is MeleeUnit)
                {
                    MeleeUnit otherMU = (MeleeUnit)u;
                    int distance = Math.Abs(this.Xpos - otherMU.Xpos) + Math.Abs(this.Ypos - otherMU.Ypos);
                    if (distance < shortest)
                    {
                        shortest = distance;
                        closest = otherMU;
                    }
                }
                else if (u is RangedUnit)
                {
                    RangedUnit otherRU = (RangedUnit)u;
                    int distance = Math.Abs(this.Xpos - otherRU.Xpos) + Math.Abs(this.Ypos - otherRU.Ypos);
                    if (distance < shortest)
                    {
                        shortest = distance;
                        closest = otherRU;
                    }
                }
            }
            return (closest, shortest);
        }
        public override string ToString()
        {
            string temp = "";
            temp += "Ranged: ";
            temp += "{" + Symbol + "}";
            temp += "(" + Xpos + "," + Ypos + ")";
            temp += Health + ", " + Attack + ", " + Attackrange + ", " + Speed;
            temp += (IsDead ? " Dead" : " Alive ");
            temp += Name;
            return temp;
        }


    }

}