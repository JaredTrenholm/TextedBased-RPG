using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class ChestManager
    {
        private Chest[] chest = new Chest[4];

        public void chestInitialize()
        {
            for (int z = 1; z < 4; z++)
            {
                chest[z] = new Chest(0,1);
            }
            chest[1].SetPos(12, 1);
            chest[2].SetPos(11, 2);
            chest[2].ChangeID(2);
            chest[3].ChangeType(1);
            chest[3].SetPos(13, 3);


        }

        public void FindPlayer(Player playerTarget)
        {
            for(int z = 1; z < 4; z++)
            {
            chest[z].FindPlayer(playerTarget);
            }
        }

        public void Draw()
        {
            for (int z = 1; z < 4; z++)
            {
                chest[z].Draw();
            }
        }

        public Chest LocateChest(int x, int y)
        {
            Chest chestTarget = null;
            for (int z = 1; z < 4; z++)
            {
                if ((chest[z].xPos == x) && (chest[z].yPos == y) && (chest[z].Opened == false))
                {
                    chestTarget = chest[z];
                }
            }
            return chestTarget;
        }
    }
}
