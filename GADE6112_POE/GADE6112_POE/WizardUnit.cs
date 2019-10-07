using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE
{
    class WizardUnit : Unit
    {
        public WizardUnit(int _xPos, int _yPos, float _health, int _speed, int _attack, int _attackRange, int _teamID, string _symbol, string _name)  //constructor
        {
            this.xPos = _xPos;
            this.yPos = _yPos;
            this.health = _health;
            this.speed = _speed;
            this.attack = _attack;
            this.attackRange = _attackRange;
            this.teamID = _teamID;
            this.symbol = _symbol;
            this.name = _name;
        }

        public override void MoveUnit(ref Unit FindClosest)          //A method to move to a new position;
        {
            if (this == FindClosest)
            {
                return;
            }

            if (FindClosest.Team() != teamID)
            {
                if (health < 50)  //if below 50hp run
                {
                    Random r = new Random();

                    switch (r.Next(0, 2))
                    {
                        case 0: xPos += (1 * speed); break;
                        case 1: xPos -= (1 * speed); break;
                    }

                    switch (r.Next(0, 2))
                    {
                        case 0: yPos += (1 * speed); break;
                        case 1: yPos -= (1 * speed); break;
                    }

                    xPos = Convert.ToInt32(Clamp(xPos, 20));
                    yPos = Convert.ToInt32(Clamp(yPos, 20));
                }
                else
                {
                    if (xPos > FindClosest.GetX())
                    {
                        xPos -= speed;
                    }
                    else if (xPos < FindClosest.GetX())
                    {
                        xPos += speed;
                    }

                    if (yPos > FindClosest.GetY())
                    {
                        yPos -= speed;
                    }
                    else if (yPos < FindClosest.GetY())
                    {
                        yPos += speed;
                    }

                }

            }

        }

        public bool InRange(ref Unit attacker)
        {
            if (DistanceTo(attacker) == attackRange)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int DistanceTo(Unit unit)
        {
            int dx = Math.Abs(unit.GetX() - xPos);
            int dy = Math.Abs(unit.GetY() - yPos);
            double part = Convert.ToDouble((dx * dx) + (dy * dy));
            return Convert.ToInt32(Math.Sqrt(part));
        }


        private float Clamp(float value, float max, float min = 0)
        {
            float Clamped = value;
            if (value < min)
            {
                Clamped = min;
            }
            else if (value > max)
            {
                Clamped = max;
            }
            return Clamped;
        }

    }
}
