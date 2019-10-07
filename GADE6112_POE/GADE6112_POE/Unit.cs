using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE
{
    public abstract class Unit
    {
        protected int xPos;
        protected int yPos;
        protected float health;
        protected float maxHealth;
        protected int speed;
        protected float attack;
        protected float attackRange;
        protected float teamID;
        protected string symbol;
        protected bool isAttacking = false;
        protected string name = "";


        public virtual void Set(int _xPos, int _yPos, float _health, int _speed, int _attack, int _attackRange, int _teamID, string _symbol, string _name)     //s
        {
            xPos = _xPos;
            yPos = _yPos;
            health = _health;
            maxHealth = health;
            speed = _speed;
            attack = _attack;
            attackRange = _attackRange;
            teamID = _teamID;
            symbol = _symbol;
            name = _name;
        }

        public virtual int GetX() { return xPos; }
        public virtual int GetY() { return yPos; }

        public virtual float GetHealthMax() { return maxHealth; }       // Method to return Max Health of all units

        public virtual void MoveUnit(ref Unit FindClosest)          //A method to move to a new position;
        {

        }

        public virtual float Attack                        //A method to handle combat with another unit;
        {
            get;
            set;
        }

        public virtual bool Scan()                          //A method to determine whether another unit is within attack range;
        {
            return false;
        }

        public virtual void Combat(ref Unit attacker)
        {
            this.health = this.health - attacker.Attack;
            if (health <= 0)
            {
                Death();
            }
        }

        public virtual bool InRange(ref Unit attacker)
        {
            return false;
        }

        public virtual Unit Closest(ref Unit[] map)
        {
            return this;
        }

        public virtual string FindClosest()                 // A method to return position of the closest other unit to this unit;
        {
            return "0_0";
        }

        public virtual void Death()                         //A method to handle the death/ destruction of this unit;
        {

        }

        public virtual string Symbol
        {
            get { return symbol; }
        }

        public virtual string ToString()                      //A ToString() method to return a neatly formatted string showing all the unit information.
        {
            return "";
        }

        public float Team()
        {
            return teamID;
        }

    }
}
