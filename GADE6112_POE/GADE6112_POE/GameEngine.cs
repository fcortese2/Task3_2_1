using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GADE6112_POE
{
    public class GameEngine
    {
        
        static private int mapsizeX, mapsizeY;
        public Map MAP = new Map(mapsizeX, mapsizeY);
        private GroupBox msgGroup;
        private Form1 form;

        public GameEngine(Form1 form, GroupBox msgGroup, int _mapsizeX, int _mapsizeY)    //Constructor
        {
            this.form = form;
            this.msgGroup = msgGroup;
            mapsizeX = _mapsizeX;
            mapsizeY = _mapsizeY;
            foreach (Unit u in MAP.units) 
            {
                /* 
                 * this chunk of code creates button instances for each unit on the form
                 */
                Button b = new Button();
                b.Location = new Point(u.GetX() * 35, u.GetY() * 35);               //button loc
                b.Size = new Size(30, 30);                                          //button size
                b.Text = u.Symbol;                                                  //unit symbol
                /*
                 * Set button color depending on the team
                 */
                if (u.Team() == 0)
                {
                    b.BackColor = Color.Red;
                }
                else
                {
                    b.BackColor = Color.Green;
                }

                if (u.GetType() == typeof(MeleeUnit))
                {
                    b.ForeColor = Color.White;
                }
                else
                {
                    b.ForeColor = Color.Black;
                }

                b.Click += buttonClick;
                this.form.Controls.Add(b);
            }
        }

        public void UpdateDisplay()
        {
            form.Controls.Clear();
            form.Controls.Add(msgGroup);

            foreach (Unit u in MAP.units)
            {
                Button b = new Button();
                b.Location = new Point(u.GetX() * 35, u.GetY() * 35);
                b.Size = new Size(30, 30);
                b.Text = u.Symbol;

                if (u.Team() == 0)
                {
                    b.BackColor = Color.Red;
                }
                else
                {
                    b.BackColor = Color.Green;
                }

                if (u.GetType() == typeof(MeleeUnit))
                {
                    b.ForeColor = Color.White;
                }
                else
                {
                    b.ForeColor = Color.Black;
                }

                b.Click += buttonClick;
                form.Controls.Add(b);
            }

        }

        public void UpdateMap()
        {
            foreach (Unit u in MAP.units)
            {
                Unit closestUnit = u.Closest(ref MAP.units);

                try
                {
                    u.MoveUnit(ref closestUnit);
                }
                catch (MeleeUnit.DeathException d)
                {
                    form.displayInfo(d.Message);
                    Unit[] temp = new Unit[MAP.units.Count() - 1];
                    int j = 0;
                    for (int i = 0; i <MAP.units.Count(); i++)
                    {
                        if (u != MAP.units[i])
                        {
                            temp[j++] = MAP.units[i];
                        }
                    }

                    MAP.units = temp;
                }
            }
        }

        public void buttonClick(object sender, EventArgs args)
        {
            foreach (Unit u in MAP.units)
            {
                if (((Button)sender).Text == u.Symbol)
                {
                    form.displayInfo(u.ToString());
                    break;
                }
            }
        }
    }
}
