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
        private ItemManager items;
        private Random random;


        public ChestManager(ItemManager itemTarget, Random randomTarget)
        {
            chest = new Chest[chestAmount];
            items = itemTarget;
            random = randomTarget;
        }

        public void chestInitialize()
        {
            int contents = 99; 
            chest[0] = new Chest(ITEMTYPE.ITEM, ITEM.RAFT, items, random);
            for (int z = 1; z < chestAmount; z++)
            {
                int randomNumber;
                randomNumber = random.Next(1, 10);
                if (randomNumber >= 5)
                { 
                    contents = (int)ITEM.POTION;
                }
                else if (randomNumber <= 6)
                {
                    contents = (int)ITEM.MONEY;
                    //Console.ReadKey(true);
                }
                chest[z] = new Chest(ITEMTYPE.ITEM, (ITEM)contents, items, random);
            }

            //changes?
            chest[1].ChangeID(ITEM.RAFT);
            chest[2].ChangeID(ITEM.BOW);
            chest[2].ChangeType(ITEMTYPE.WEAPON);
            chest[3].ChangeID(ITEM.SWORD);
            chest[3].ChangeType(ITEMTYPE.WEAPON);

            //chest postitions
            chest[0].SetPos(12, 26);
            chest[1].SetPos(11, 2);
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
