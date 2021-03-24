using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class EnemyManager
    {
        private static int EnemyAmount = Global.ENEMY_COUNT;
        public Enemy[] enemy = new Enemy[EnemyAmount];
        public int EnemyLimit = EnemyAmount;

        public EnemyManager()
        {
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

            if(deaths > EnemyLimit)
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
                enemy[x] = new Enemy(enemies, 0);
                enemy[x].SetSpeciesType(0);
                enemy[x].GetPlayerTarget(playerTarget);
                enemy[x].SetPos(x, 1);
            }

            enemy[0] = new Enemy(enemies, 1);
            enemy[0].SetPos(10, 10);
            enemy[0].SetSpeciesType(0);
            enemy[0].GetPlayerTarget(playerTarget);


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
                    Renderer.RenderData[enemy[z].CharacterY, enemy[z].CharacterX] = Map.mapData[enemy[z].CharacterY, enemy[z].CharacterX];
                    enemy[z].SetAttackMessage(" ");
                }
            }
        }

    }
}
