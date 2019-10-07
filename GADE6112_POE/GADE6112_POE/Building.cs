using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE
{
    /*
     * A base building class with some global
     * definitions for all buildings
     */
    class Building
    {
        protected int x;
        protected int y;
        protected float health;
        protected float maxHealth;
        protected float teamID;
        protected string symbol;

        public Building()
        {

        }

        public virtual int X { get { return x; } set { x = value; } }
        public virtual int Y { get { return y; } set { y = value; } }
        public virtual float Health { get { return health; } set { health = value; } }
        public virtual float TeamID { get { return teamID; } set { teamID = value; } }
        public virtual string Symbol { get { return symbol; } set { symbol = value; } }

        public virtual void Death()
        {

        }

        public virtual string ToString()
        {
            return "";
        }

    }
}
