using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8BitFighter
{
    class Player
    {
        public int health;
        public int weapon;

        public Player()
        {
            //
            health = 100;
            
        }

        public void Attacked(int value)
        {
            health-=value;
        }

        public void ChangeWeapon(int value)
        {
            weapon = value;
        }
    }
}
