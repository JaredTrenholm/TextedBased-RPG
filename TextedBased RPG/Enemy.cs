using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextedBased_RPG
{
    class Enemy : CharacterSystem
    {
        private static Random AiRandomizer = new Random();
        private static int AiChoice;
        public bool EnemySeen = false;

        public int attack;

        public Enemy()
        {
            maxHealth = 25;
            health = 25;
            Alive = true;
            name = "Your Foe";
            CharacterX = 1;
            CharacterY = 1;
            attack = 25;
        }

        public void DrawEnemy()
        {
            if(health <= 0)
            {

            }
            else
            {
            Map.mapData[CharacterY, CharacterX] = "E";
            }
        }
        public void EnemyTurn()
        {
            if (CharacterX == Program.user.CharacterX - 1)
            {
                if (CharacterY == Program.user.CharacterY - 1)
                {
                    Program.user.TakeDamage(attack);
                    Program.GM.EnemyAttack = name + " attacked " + Program.user.name + " for " + attack + " points of damage!";
                }
                else if (CharacterY == Program.user.CharacterY + 1)
                {
                    Program.user.TakeDamage(attack);
                    Program.GM.EnemyAttack = name + " attacked " + Program.user.name + " for " + attack + " points of damage!";
                }
            }
            else if (CharacterX == Program.user.CharacterX + 1)
            {
                if (CharacterY == Program.user.CharacterY - 1)
                {
                    Program.user.TakeDamage(attack);
                    Program.GM.EnemyAttack = name + " attacked " + Program.user.name + " for " + attack + " points of damage!";
                }
                else if (CharacterY == Program.user.CharacterY + 1)
                {
                    Program.user.TakeDamage(attack);
                    Program.GM.EnemyAttack = name + " attacked " + Program.user.name + " for " + attack + " points of damage!";
                }
            }
            else
            {
                for (int x = 0; x < 1;)
                {
                    AiChoice = AiRandomizer.Next(0, 4);


                    if (AiChoice == 0)
                    {
                        if (CharacterX == 0)
                        {

                        }
                        else
                        {
                            CharacterX = CharacterX - 1;
                            x++;
                            Program.GM.EnemyAttack = "";
                        }
                    }
                    else if (AiChoice == 1)
                    {
                        if (CharacterX == 29)
                        {

                        }
                        else
                        {
                            CharacterX = CharacterX + 1;
                            x++;
                            Program.GM.EnemyAttack = "";
                        }
                    }
                    else if (AiChoice == 2)
                    {
                        if (CharacterY == 29)
                        {

                        }
                        else
                        {
                            CharacterY = CharacterY + 1;
                            x++;
                            Program.GM.EnemyAttack = "";
                        }
                    }
                    else if (AiChoice == 3)
                    {
                        if (CharacterY == 1)
                        {

                        }
                        else
                        {
                            CharacterY = CharacterY - 1;
                            x++;
                            Program.GM.EnemyAttack = "";
                        }
                    }
                    else
                    {

                    }
                }
            }


        }

        
    }
}
