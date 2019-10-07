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
    class ResourceBuilding : Building
    {
        Map map;

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

        private string ResType;     //Resource Type (Gold, Silver, etc)
        private int ResGen;         //Resources Generated Number
        private int ResPR;          //Resources Per Round
        private int ResRem;         //Resources Remaining

        public void ResGenerate()
        {
            ResGen += ResPR;
            ResRem -= ResPR;
        }
        public override void Death()
        {
            symbol = "X";
            IsDead = true;
        }
        public override string ToString()
        {
            string temp = "";
            temp += "Building: ";
            temp += "{" + Symbol + "}";
            temp += " " + ResType + " ";
            temp += " " + ResRem + " ";
            temp += "(" + Xpos + ")";
            temp += Health;
            temp += (IsDead ? "Destroyed" : "Active");
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
