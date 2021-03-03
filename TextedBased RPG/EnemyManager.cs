using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class EnemyManager
    {
        private static int EnemyAmount = 4;
        public Enemy[] enemy = new Enemy[4];
        public int EnemyLimit = EnemyAmount;

        public EnemyManager()
        {
        }
        public void enemyInitialize(Player playerTarget, EnemyManager enemies)
        {

            for (int x = 1; x < EnemyLimit; x++)
            {
                enemy[x] = new Enemy(enemies);
                enemy[x].SetSpeciesType(0);
                enemy[x].GetPlayerTarget(playerTarget);
                enemy[x].Alive = true;
            }


            enemy[1].CharacterX = 1;
            enemy[1].CharacterY = 1;
            enemy[1].WeaponChange(0);
            enemy[1].SetName("Serdun");

            enemy[2].CharacterX = 2;
            enemy[2].CharacterY = 2;
            enemy[2].Avatar = "B";
            enemy[2].SetSpeciesType(1);
            enemy[2].SetName("Dory");
            enemy[2].WeaponChange(1);

            enemy[3].CharacterX = 3;
            enemy[3].CharacterY = 3;
            enemy[3].Avatar = "D";
            enemy[3].SetSpeciesType(3);
            enemy[3].SetName("Alfynn");
            enemy[3].WeaponChange(2);

            
        }
        public Enemy LocateEnemy(int x, int y)
        {
            Enemy enemyTarget = null;
            for (int z = 1; z < EnemyAmount; z++)
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
            for (int z = 1; z < EnemyLimit; z++)
            {
                if (enemy[z].Alive == true)
                {
                    enemy[z].EnemyTurn();
                }
            }
        }

        public void Draw()
        {
            for (int z = 1; z < EnemyLimit; z++)
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
