using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace GADE6112_POE
{
    public class Map
    {

        public Unit[] units = new Unit[10];        //create new array of units


        private Random ran = new Random();

        public Map(int mapsizeX, int mapsizeY)                       //constructor 
            /*
             * Generates random ranged/melee units 
             * random pos between 20X and 20Y
             */
        {
            for (int i = 0; i < 10; i++)
            {
                int newX = ran.Next(0, mapsizeX);                        //random X pos
                int newY = ran.Next(0, mapsizeY);                         //random Y pos
                int team = 1 % 2;                                   //random team
                int tempAttack = 0;                                 //temporary attack 
                switch (ran.Next(0,4))                              //set temp attac to random between 4 values
                {
                    case 0: tempAttack = 5; break;
                    case 1: tempAttack = 10; break;
                    case 2: tempAttack = 15; break;
                    case 3: tempAttack = 20; break;
                }
                switch (ran.Next(0, 2))
                {
                    case 0: units[i] = new MeleeUnit(newX, newY, 100, 1, tempAttack, 1, team, i.ToString(), "UNIT NAME"); break;  //generate new instance of melee/ranged unit
                    case 1: units[i] = new RangedUnit(newX, newY, 100, 1, tempAttack, 1, team, i.ToString(), "UNIT NAME"); break;
                }
            }
        }

        public void Write()
        {
            string[] map = new string[units.Length];

            for (int i = 0; i < map.Length; i++)
            {
                map[i] = units[i].GetX() + "_" + units[i].GetY() + "_" +            //format string
                        units[i].Symbol + "_" + units[i].Team() + "_" +
                        units[i].Attack + "_" + units[i].GetType() + "_";
            }

            StreamWriter fileX = new StreamWriter(@"MapFile.txt", false);
            if (!File.Exists(@"MapFile.txt"))                                          //if file doesnt exist...
            {   
                File.WriteAllLines(@"MapFile.txt", map);                               //create and write whole array
            }
            else
            {
                for (int i = 0; i < map.Length; i++)
                {
                    fileX.WriteLine(map[i]);                                            //else 
                }
            }

            fileX.Close();
        }

        public void Read()
        {
            int currX, currY;
            string Sym, type;
            float currTeam, atk;

            StreamReader fileX = new StreamReader(@"MapFile.txt");
            string line = fileX.ReadLine();
            /*while (line != null)
            {
                
            }*/
            fileX.Close();
        }


    }
}
