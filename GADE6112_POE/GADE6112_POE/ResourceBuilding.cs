using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE
{
    class ResourceBuilding : Building
    {
        private string resourceType;
        private int resourcesGenerated;
        private int resourcesPerRound;
        private int resourcePoolLeft;

        public ResourceBuilding(int _x, int _y, float _health, float _maxHealth, float _teamID, string _symbol)
        {
            this.x = _x;
            this.y = _y;
            this.health = _health;
            this.maxHealth = _maxHealth;
            this.teamID = _teamID;
            this.symbol = _symbol;
        }

        //A method to generate resources
        public void GenerateResources()
        {
            if (resourcesPerRound >= resourcePoolLeft && health > 0)    //if not dead and resources still available then...
            {
                resourcesGenerated += resourcesPerRound;
                resourcePoolLeft -= resourcesPerRound;
            }
            else return;
        }

        public override void Death()
        {
            if (health <= 0)
            {
                //Remove unit
            }
        }

        public override string ToString()
        {
            return symbol + ": [" + x + "," + y + "] " + health + "hp, generated " + resourcesGenerated + " resources";
        }

        public float TeamID { get { return teamID; } }
    }
}
