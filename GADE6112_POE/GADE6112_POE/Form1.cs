using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GADE6112_POE
{
    /*
     * WISHING THIS WAS IN UNITY -_-
     */
    public partial class Form1 : Form
    {
        GameEngine engine;
        int count = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnGamePlay_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            engine.UpdateMap();
            engine.UpdateDisplay();
            label1.Text = (++count).ToString();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        public void displayInfo(string msg)
        {
            listBox1.Items.Add(msg);
        }

        private void BtnWrite_Click(object sender, EventArgs e)
        {
            engine.MAP.Write();
        }

        private void BtnStartGame_Click(object sender, EventArgs e)
        {
            engine = new GameEngine(this, this.groupBox1, (int)mapsizex.Value, (int)mapsizey.Value);
        }
    }
}
