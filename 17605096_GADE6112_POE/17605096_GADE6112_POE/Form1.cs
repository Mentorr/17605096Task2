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
{ [Serializable]
    public partial class Form1 : Form
    {
        GameEngine engine;
        FactoryBuilding fb;

        Map map;


        public Form1()
        {
                InitializeComponent();
        }
        private void BtnStart_Click(Object sender, EventArgs e)
        {
            Timer1.Enabled = true;
        }
        private void BtnPause_Click(object sender, EventArgs e)
        {
            Timer1.Enabled = false;
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            lblRoundSim.Text = "Round: " + engine.RoundNum.ToString();
            engine.Update();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            engine = new GameEngine(20, 5, txtInfo, GBMap);
        }

        private void BtnStartSim_Click(object sender, EventArgs e)
        {
            Timer1.Enabled = true;
        }

        private void BtnPauseSim_Click(object sender, EventArgs e)
        {
            Timer1.Enabled = false;
        }

        private void Timer1_Tick_1(object sender, EventArgs e)
        {
            lblRoundSim.Text = "Round: " + engine.RoundNum.ToString();
            engine.Update();
            
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            engine = new GameEngine(20, 5, txtInfo, GBMap);
        }
        
        private void BtnSave_Click(object sender, EventArgs e)
        {
            Map map1 = new Map(20, 4, txtInfo);
            map1.Save();
        }

        private void BtnRead_Click(object sender, EventArgs e)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fin = new FileStream("Save.dat", FileMode.Open, FileAccess.Read, FileShare.None);

            try
            {
                using (fin)
                {
                    map = (Map)bf.Deserialize(fin);
                    MessageBox.Show("Info Saved");
                }
            }
            catch
            {
                MessageBox.Show("Error Occured");
            }
            string contents = File.ReadAllText("Save.dat");
        }
    }
}
