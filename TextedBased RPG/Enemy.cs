using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class Enemy : Characters
    {
        private static Random AiRandomizer = new Random();
        private static int AiChoice;
        public bool EnemySeen = false;

        private Player user;

        public string Avatar;
        private EnemyManager enemyManager;



        public Enemy(EnemyManager enemies)
        {
            enemyManager = enemies;
            maxHealth = 25;
            health = 25;
            Alive = true;
            name = "Your Foe";
            attack = 5;
            Avatar = "E";
        }

        public void GetPlayerTarget(Player userTarget)
        {
            user = userTarget;
        }

        public void Draw()
        {
            if (health <= 0)
            {

            }
            else
            {
                Renderer.RenderData[CharacterY, CharacterX] = Avatar;
            }
        }



        public void EnemyTurn()
        {
            if (CharacterX == user.CharacterX)
            {
                if (CharacterY == user.CharacterY - 1)
                {
                    user.TakeDamage(attack);
                    AttackMessage = name + " attacked " + user.GetName() + " for " + attack + " points of damage!";
                }
                else if (CharacterY == user.CharacterY + 1)
                {
                    user.TakeDamage(attack);
                    AttackMessage = name + " attacked " + user.GetName() + " for " + attack + " points of damage!";
                }
            }
            else if (CharacterY == user.CharacterY)
            {
                if (CharacterX == user.CharacterX - 1)
                {
                    user.TakeDamage(attack);
                    AttackMessage = name + " attacked " + user.GetName() + " for " + attack + " points of damage!";
                }
                else if (CharacterX == user.CharacterX + 1)
                {
                    user.TakeDamage(attack);
                    AttackMessage = name + " attacked " + user.GetName() + " for " + attack + " points of damage!";
                }
            }
            else
            {
                AiChoice = AiRandomizer.Next(0, 3); // 0 up 1 right 2 down 3 left
                int xModified = CharacterX;
                int yModified = CharacterY;
                if(AiChoice == 0)
                {
                    yModified = CharacterY - 1;
                } else if (AiChoice == 1)
                {
                    xModified = CharacterX + 1;
                }
                else if (AiChoice == 2)
                {
                    yModified = CharacterY + 1;
                }
                else if (AiChoice == 3)
                {
                    xModified = CharacterX - 1;
                }

                if(xModified == 0 || xModified == 30)
                {
                    xModified = CharacterX;
                }

                if (yModified == 0 || yModified == 30)
                {
                    yModified = CharacterY;
                }
                Enemy targetFoe = enemyManager.LocateEnemy(xModified, yModified);
                if (targetFoe != null)
                {
                    return;
                }
                else
                {
                    string tile = Map.GetTile(yModified, xModified);
                    if (tile == "~")
                    {
                        
                        
                    }
                    else if (tile == "^")
                    {


                    }
                    else if (tile == "F")
                    {


                    }
                    else if (tile == "T")
                    {


                    }
                    else if (tile == "C")
                    {


                    }
                    else
                    {
                        Renderer.RenderData[CharacterY, CharacterX] = Map.mapData[CharacterY, CharacterX];
                        CharacterX = xModified;
                        CharacterY = yModified;
                    }
                }


            }
        }
    }
}