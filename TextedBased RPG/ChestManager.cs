using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class ChestManager
    {
        private int chestAmount = 15;
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
            chest[3].SetPos(12, 1);
            chest[4].SetPos(1, 3);
            chest[5].SetPos(0, 13);
            chest[7].SetPos(4, 15);
            chest[6].SetPos(6, 21);
            chest[8].SetPos(10, 23);
            chest[9].SetPos(18, 23);
            chest[10].SetPos(23, 21);
            chest[11].SetPos(15, 9);
            chest[12].SetPos(22, 7);
            chest[13].SetPos(27, 3);
            chest[14].SetPos(27, 0);

            for (int z = 4; z < chestAmount; z++)
            {
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
