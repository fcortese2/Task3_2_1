using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6112_POE
{
    class FactoryBuilding : Building
    {
        private string toProduce;
        private int productionSpeed;   
        private int[] spawnPoint = new int[2];  // spawn point as X,Y

        public FactoryBuilding(int _x, int _y, float _health, float _maxHealth, float _teamID, string _symbol)
        {
            this.x = _x;
            this.y = _y;
            this.health = _health;
            this.maxHealth = _maxHealth;
            this.teamID = _teamID;
            this.symbol = _symbol;

            if (this.y == 0)
            {
                spawnPoint[0] = this.x;
                spawnPoint[1] = this.y + 1;
            }
            else
            {
                spawnPoint[0] = this.x;
                spawnPoint[1] = this.y - 1;
            }
        }

        public int ProductionSpeed { get { return productionSpeed; } }

        public Unit SpawnUnit()
        {
            Random ran = new Random();
            if (toProduce == "Melee")
            {
                return new MeleeUnit(spawnPoint[0], spawnPoint[1], 100, 1, ran.Next(20), 1, (int)teamID, symbol, "UNIT NAME");
            }
            else
            {
                return new RangedUnit(spawnPoint[0], spawnPoint[1], 100, 1, ran.Next(20), 2, (int)teamID, symbol, "UNIT NAME");
            }
        }

        public override void Death()
        {

        }

        public override string ToString()
        {
            return symbol + ": [" + x + "," + y + "] " + health + "hp, is generating " + toProduce + " units";
        }
    }
}
