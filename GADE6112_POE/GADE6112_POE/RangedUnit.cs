using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE
{
    class RangedUnit : Unit
    {
     /*
      *Structure is the same as 
      * the Melee class
      */
      public RangedUnit(int _xPos, int _yPos, float _health, int _speed, int _attack, int _attackRange, int _teamID, string _symbol, string _name)  //constructor
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
                if (health < 25)
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


        public override float Attack                        //A method to handle combat with another unit;
        {
            get { return attack; }
            set { attack = value; }
        }

        public int X
        {
            get { return xPos; }
            set { xPos = value; }
        }

        public int Y
        {
            get { return yPos; }
            set { yPos = value; }
        }

        public string Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }

        public float Team
        {
            get { return teamID; }
            set { teamID = value; }
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

        public override Unit Closest(ref Unit[] map)
        {
            Unit closest = this;
            int smallestRange = 100;
            foreach (Unit u in map)
            {
                if (u.Team() != teamID)
                {
                    if (smallestRange > DistanceTo(u) && u != this)
                    {
                        smallestRange = DistanceTo(u);
                        closest = u;
                    }
                }
            }
            return closest;
        }

        public override void Death()
        {
            throw new DeathException(this.ToString() + "IS DEAD");
        }

        public override string FindClosest()                 // A method to return position of the closest other unit to this unit;
        {
            return "0_0";
        }

        public override string ToString()                      //A ToString() method to return a neatly formatted string showing all the unit information.
        {
            return symbol + ": [" + xPos + "," + yPos + "] " + health + "hp " + attack;
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

        public class DeathException : System.Exception
        {
            public DeathException() : base() { }
            public DeathException(string message) : base(message) { }
            public DeathException(string message, System.Exception inner) : base(message, inner) { }

            protected DeathException(System.Runtime.Serialization.SerializationInfo info,
                System.Runtime.Serialization.StreamingContext context)
            { }


        }
    }
}
