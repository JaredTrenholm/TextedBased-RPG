using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class ChestManager
    {
        private int chestAmount = Global.CHEST_LIMIT;
        private Chest[] chest;

        public ChestManager()
        {
         chest = new Chest[chestAmount];

        }

        public void chestInitialize()
        {
            chest[0] = new Chest(1, 2);
            for (int z = 1; z < chestAmount; z++)
            {
                chest[z] = new Chest(0,1);
            }
            chest[0].SetPos(12, 26);
            chest[1].SetPos(11, 2);
            chest[1].ChangeID(2);
            chest[2].ChangeType(1);
            chest[2].SetPos(13, 3);
            
            for(int z = 3; z < chestAmount; z++)
            {
                chest[z].SetPos(z, 0);
                chest[z].ChangeType(1);
            }


        }

        public void FindPlayer(Player playerTarget)
        {
            for(int z = 0; z < chestAmount; z++)
            {
            chest[z].FindPlayer(playerTarget);
            }
        }

        public void Draw()
        {
            for (int z = 0; z < chestAmount; z++)
            {
                chest[z].Draw();
            }
        }

        public Chest LocateChest(int x, int y)
        {
            Chest chestTarget = null;
            for (int z = 0; z < chestAmount; z++)
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
