using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace _17605096_GADE6112_POE
{
    class FactoryBuilding : Building
    {
        GameEngine engine;
        Map map;
        Random r = new Random();
        List<Unit> units;
        string output;

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
        public FactoryBuilding(int x, int y, int h, int f, string symb)
        {
            Xpos = x;
            Ypos = y;
            Health = h;
            Faction = f;
            Symbol = symb;
        }


        public void UnitProduce()
        {
            int unitR = r.Next(0, 2);
            if(unitR == 1)
            {
                MeleeUnit m = new MeleeUnit(Xpos,
                                            Ypos - 1,
                                            100,
                                            1,
                                            20,
                                            (1),
                                            "M", "Grunt");
                int GenSpeed = r.Next(0, 20);
                for (int i = 1; i < GenSpeed; i++)
                {
                    if (i == GenSpeed)
                    {
                        units.Add(m);
                    }
                }
            }
            else
            {
                RangedUnit b = new RangedUnit(Xpos,
                                              Ypos - 1,
                                              100,
                                              1,
                                              20,
                                              2,
                                              (2),
                                              "R", "Archer");
                
                int GenSpeed = r.Next(0, 20);
                for (int i = 1; i < GenSpeed; i++)
                {
                    if (i == GenSpeed)
                    {
                        units.Add(b);
                        
                    }
                }
            }
        }
        public override void Death()
        {
            Symbol = "XX";
            IsDead = true;
        }
        
        public override string ToString()
        {
            string temp = "";
            temp += "Factory:";
            temp += "{" + Symbol + "}";
            temp += "(" + Xpos + "," + Ypos + ")";
            temp += Health + ", " + Faction;
            temp += (IsDead ? " Dead" : " Alive ");
            return temp;
        }

        public override void Save()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fout = new FileStream("Save.dat", FileMode.Create, FileAccess.Write, FileShare.None);
            try
            {
                using (fout)
                {
                    bf.Serialize(fout, map);
                    MessageBox.Show("Info Saved");
                }
            }
            catch (FileNotFoundException exc)
            {
                MessageBox.Show("Error Occured " + exc.Message);
            }        
        }
    }
}
