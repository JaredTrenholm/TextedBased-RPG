using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class EnemyManager
    {
        private static int EnemyAmount = 25;
        public Enemy[] enemy = new Enemy[EnemyAmount];
        public int EnemyLimit = EnemyAmount;
        private Random random;

        public EnemyManager(Random randomTarget)
        {
            random = randomTarget;
        }

        public bool AllDeadCheck()
        {
            int deaths = 0;
            for (int z = 0; z < EnemyLimit; z++)
            {
                if (enemy[z].Alive == true)
                {
                }
                else
                {
                    deaths = deaths + 1;
                }
            }

            if(deaths >= EnemyLimit)
            {
                return true;
            } else
            {
                return false;
            }

        }
        public void enemyInitialize(Player playerTarget, EnemyManager enemies)
        {
            for (int x = 1; x < EnemyLimit; x++)
            {
                if (x > 11) enemy[x] = new Slime(random);

                else if (x > 20) enemy[x] = new Dog(random);

                else enemy[x] = new Bandit(random);

                enemy[x].SetSpeciesType(0);
                enemy[x].GetPlayerTarget(playerTarget);
                enemy[x].SetPos(x, 1);

                enemy[x].GrabManager(enemies);
            }

            enemy[0] = new Boss(random);
            enemy[0].SetPos(40, 10);
            enemy[0].SetSpeciesType(0);
            enemy[0].GetPlayerTarget(playerTarget);
            enemy[0].GrabManager(enemies);

            enemy[1].SetPos(41, 11);
            enemy[2].SetPos(39, 9);
            enemy[3].SetPos(2, 23);
            enemy[4].SetPos(2, 22);
            enemy[5].SetPos(0, 22);
            enemy[6].SetPos(1, 22);
            enemy[7].SetPos(0, 20);
            enemy[8].SetPos(14,25);
            enemy[9].SetPos(12, 23);
            enemy[10].SetPos(19, 22);
            enemy[11].SetPos(18, 20);
            enemy[12].SetPos(6, 1);
            enemy[13].SetPos(2, 1);
            enemy[14].SetPos(2, 2);
            enemy[15].SetPos(6, 3);
            enemy[16].SetPos(3, 5);
            enemy[17].SetPos(0, 6);
            enemy[18].SetPos(18, 2);
            enemy[19].SetPos(18, 1);
            enemy[20].SetPos(23, 0);
            enemy[21].SetPos(8, 18);
            enemy[22].SetPos(14, 14);
            enemy[24].SetPos(22, 14);
            enemy[23].SetPos(5, 14);






        }


        public bool BossDead()
        {
            if (enemy[0].Alive == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Enemy LocateEnemy(int x, int y)
        {
            Enemy enemyTarget = null;
            for (int z = 0; z < EnemyAmount; z++)
            {
                if((enemy[z].CharacterX == x) && (enemy[z].CharacterY == y) && (enemy[z].Alive == true))
                {
                    enemyTarget = enemy[z];
                }
            }
            return enemyTarget;
        }

        public void Update()
        {
            for (int z = 0; z < EnemyLimit; z++)
            {
                if (enemy[z].Alive == true)
                {
                    enemy[z].EnemyTurn();
                }
            }
        }

        public void Draw()
        {
            for (int z = 0; z < EnemyLimit; z++)
            {
                if (enemy[z].Alive == true)
                {
                    enemy[z].Draw();
                }
                else
                {
                    enemy[z].SetAttackMessage(" ");
                }
            }
        }

    }
}
