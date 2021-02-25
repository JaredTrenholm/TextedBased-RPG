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
        private GameManager GM;

       public string Avatar;

        


        public Enemy(GameManager GMTarget)
        {
            GM = GMTarget;
            
            maxHealth = 25;
            health = 25;
            Alive = true;
            name = "Your Foe";
            CharacterX = 10;
            CharacterY = 4;
            attack = 5;
            Avatar = "E";
        }

        public void GetPlayerTarget(Player userTarget)
        {
            user = userTarget;
        }

        public void DrawEnemy()
        {
            if(health <= 0)
            {

            }
            else
            {
            Map.RenderData[CharacterY, CharacterX] = Avatar;
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

                
                if (movementType == 0)
                {
                    Map.RenderData[CharacterY, CharacterX] = Map.mapData[CharacterY, CharacterX];
                    AttackMessage = name + " ";
                    for (int x = 0; x < 1;)
                    {
                        AiChoice = AiRandomizer.Next(0, 4);


                        if (AiChoice == 0)
                        {
                            if (CharacterX == 1)
                            {

                            }
                            else
                            {
                                if (Map.RenderData[CharacterY, CharacterX - 1] == "E")
                                {
                                    x++;
                                    AttackMessage = "";
                                } else if (Map.RenderData[CharacterY, CharacterX - 1] == "D")
                                {
                                    x++;
                                    AttackMessage = "";
                                } else if (Map.RenderData[CharacterY, CharacterX - 1] == "B")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY, CharacterX - 1] == "~")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY, CharacterX - 1] == "C")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY, CharacterX - 1] == "F")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY, CharacterX - 1] == "^")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else
                                {
                                    CharacterX = CharacterX - 1;
                                    x++;
                                    AttackMessage = "";
                                }

                            }
                        }
                        else if (AiChoice == 1)
                        {
                            if (CharacterX == 29)
                            {

                            }
                            else
                            {
                                if (Map.RenderData[CharacterY, CharacterX + 1] == "E")
                                {
                                    x++;
                                    AttackMessage = "";
                                } else if (Map.RenderData[CharacterY, CharacterX + 1] == "D")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY, CharacterX + 1] == "B")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY, CharacterX + 1] == "~")
                                {
                                    x++;
                                   AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY, CharacterX + 1] == "C")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY, CharacterX + 1] == "F")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY, CharacterX + 1] == "^")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else
                                {
                                    CharacterX = CharacterX + 1;
                                    x++;
                                    AttackMessage = "";
                                }
                            }
                        }
                        else if (AiChoice == 2)
                        {
                            if (CharacterY == 29)
                            {

                            }
                            else
                            {
                                if (Map.RenderData[CharacterY + 1, CharacterX] == "E")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY + 1, CharacterX] == "B")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY + 1, CharacterX] == "D")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY + 1, CharacterX] == "~")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY + 1, CharacterX] == "C")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY + 1, CharacterX] == "F")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY + 1, CharacterX] == "^")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else
                                {
                                    CharacterY = CharacterY + 1;
                                    x++;
                                    AttackMessage = "";
                                }
                            }
                        }
                        else if (AiChoice == 3)
                        {
                            if (CharacterY == 1)
                            {

                            }
                            else
                            {
                                if (Map.RenderData[CharacterY - 1, CharacterX] == "E")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY - 1, CharacterX] == "D")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY - 1, CharacterX] == "B")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY - 1, CharacterX] == "~")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY - 1, CharacterX] == "C")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY - 1, CharacterX] == "F")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY - 1, CharacterX] == "^")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else
                                {
                                    CharacterY = CharacterY - 1;
                                    x++;
                                    AttackMessage = "";
                                }
                            }
                        }
                        else
                        {

                        }
                    }

                } else if (movementType == 1){
                    Map.RenderData[CharacterY, CharacterX] = Map.mapData[CharacterY, CharacterX];
                    for (int x = 0; x < 1;)
                    {
                        AiChoice = AiRandomizer.Next(0, 4);


                        if (AiChoice == 1)
                        {
                            if (CharacterX == 1)
                            {

                            }
                            else
                            {
                                if (Map.RenderData[CharacterY, CharacterX - 1] == "E")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY, CharacterX - 1] == "B")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY, CharacterX - 1] == "D")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY, CharacterX - 1] == "@")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY, CharacterX - 1] == "C")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY, CharacterX - 1] == "F")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY, CharacterX - 1] == "^")
                                {
                                    x++;
                                   AttackMessage = "";
                                }
                                else
                                {
                                    CharacterX = CharacterX - 1;
                                    x++;
                                    AttackMessage = "";
                                }

                            }
                        }
                        else if (AiChoice == 1)
                        {
                            if (CharacterX == 29)
                            {

                            }
                            else
                            {
                                if (Map.RenderData[CharacterY, CharacterX + 1] == "E")
                                {
                                    x++;
                                    AttackMessage = "";
                                } else if (Map.RenderData[CharacterY, CharacterX + 1] == "D")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY, CharacterX + 1] == "B")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY, CharacterX - 1] == "@")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY, CharacterX + 1] == "C")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY, CharacterX + 1] == "F")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY, CharacterX + 1] == "^")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else
                                {
                                    CharacterX = CharacterX + 1;
                                    x++;
                                    AttackMessage = "";
                                }
                            }
                        }
                        else if (AiChoice == 2)
                        {
                            if (CharacterY == 29)
                            {

                            }
                            else
                            {
                                if (Map.RenderData[CharacterY + 1, CharacterX] == "E")
                                {
                                    x++;
                                    AttackMessage = "";
                                } else if (Map.RenderData[CharacterY + 1, CharacterX] == "D")
                                    {
                                        x++;
                                        AttackMessage = "";
                                    }
                                 else if (Map.RenderData[CharacterY + 1, CharacterX] == "B")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY, CharacterX - 1] == "@")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY + 1, CharacterX] == "C")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY + 1, CharacterX] == "F")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY + 1, CharacterX] == "^")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else
                                {
                                    CharacterY = CharacterY + 1;
                                    x++;
                                    AttackMessage = "";
                                }
                            }
                        }
                        else if (AiChoice == 3)
                        {
                            if (CharacterY == 1)
                            {

                            }
                            else
                            {
                                if (Map.RenderData[CharacterY - 1, CharacterX] == "E")
                                {
                                    x++;
                                    AttackMessage = "";
                                } else if (Map.RenderData[CharacterY - 1, CharacterX] == "D")
                                {
                                    x++;
                                    AttackMessage = "";
                                } else if (Map.RenderData[CharacterY - 1, CharacterX] == "B")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY, CharacterX - 1] == "@")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY - 1, CharacterX] == "C")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY - 1, CharacterX] == "F")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY - 1, CharacterX] == "^")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else
                                {
                                    CharacterY = CharacterY - 1;
                                    x++;
                                    AttackMessage = "";
                                }
                            }
                        }
                        else
                        {

                        }
                    }

                }
                else if (movementType == 2)
                {
                    Map.RenderData[CharacterY, CharacterX] = Map.mapData[CharacterY, CharacterX];
                    AttackMessage = name + " ";
                    for (int x = 0; x < 1;)
                    {
                        AiChoice = AiRandomizer.Next(0, 4);


                        if (AiChoice == 0)
                        {
                            if (CharacterX == 1)
                            {

                            }
                            else
                            {
                                if (Map.RenderData[CharacterY, CharacterX - 1] == "E")
                                {
                                    x++;
                                    AttackMessage = "";
                                } else if (Map.RenderData[CharacterY, CharacterX - 1] == "B")
                                {
                                    x++;
                                    AttackMessage = "";
                                } else if (Map.RenderData[CharacterY, CharacterX - 1] == "D")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY, CharacterX - 1] == "@")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY, CharacterX - 1] == "~")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY, CharacterX - 1] == "C")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY, CharacterX - 1] == "F")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else
                                {
                                    CharacterX = CharacterX - 1;
                                    x++;
                                    AttackMessage = "";
                                }

                            }
                        }
                        else if (AiChoice == 1)
                        {
                            if (CharacterX == 29)
                            {

                            }
                            else
                            {
                                if (Map.RenderData[CharacterY, CharacterX + 1] == "E")
                                {
                                    x++;
                                    AttackMessage = "";
                                } else if (Map.RenderData[CharacterY, CharacterX + 1] == "B")
                                {
                                    x++;
                                    AttackMessage = "";
                                } else if (Map.RenderData[CharacterY, CharacterX + 1] == "D")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY, CharacterX + 1] == "@")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY, CharacterX + 1] == "~")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY, CharacterX + 1] == "C")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY, CharacterX + 1] == "F")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else
                                {
                                    CharacterX = CharacterX + 1;
                                    x++;
                                    AttackMessage = "";
                                }
                            }
                        }
                        else if (AiChoice == 2)
                        {
                            if (CharacterY == 29)
                            {

                            }
                            else
                            {
                                if (Map.RenderData[CharacterY + 1, CharacterX] == "E")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY + 1, CharacterX] == "D")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY + 1, CharacterX] == "B")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY+1, CharacterX] == "@")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY + 1, CharacterX] == "~")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY + 1, CharacterX] == "C")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY + 1, CharacterX] == "F")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else
                                {
                                    CharacterY = CharacterY + 1;
                                    x++;
                                    AttackMessage = "";
                                }
                            }
                        }
                        else if (AiChoice == 3)
                        {
                            if (CharacterY == 1)
                            {

                            }
                            else
                            {
                                if (Map.RenderData[CharacterY - 1, CharacterX] == "E")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY - 1, CharacterX] == "D")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY - 1, CharacterX] == "B")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY, CharacterX - 1] == "@")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY - 1, CharacterX] == "~")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY - 1, CharacterX] == "C")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY - 1, CharacterX] == "F")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else
                                {
                                    CharacterY = CharacterY - 1;
                                    x++;
                                    AttackMessage = "";
                                }
                            }
                        }
                        else
                        {

                        }
                    }

                }
                else if (movementType == 3)
                {
                    Map.RenderData[CharacterY, CharacterX] = Map.mapData[CharacterY, CharacterX];
                    AttackMessage = name + " ";
                    for (int x = 0; x < 1;)
                    {
                        AiChoice = AiRandomizer.Next(0, 4);


                        if (AiChoice == 1)
                        {
                            if (CharacterX <= 1)
                            {

                            }
                            else
                            {
                                if (Map.RenderData[CharacterY, CharacterX - 1] == "E")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY, CharacterX - 1] == "D")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY, CharacterX - 1] == "B")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY, CharacterX - 1] == "@")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY, CharacterX - 1] == "C")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY, CharacterX - 1] == "F")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else
                                {
                                    CharacterX = CharacterX - 1;
                                    x++;
                                    AttackMessage = "";
                                }

                            }
                        }
                        else if (AiChoice == 1)
                        {
                            if (CharacterX == 29)
                            {

                            }
                            else
                            {
                                if (Map.RenderData[CharacterY, CharacterX + 1] == "E")
                                {
                                    x++;
                                    AttackMessage = "";
                                } else if (Map.RenderData[CharacterY, CharacterX + 1] == "D")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY, CharacterX + 1] == "B")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY, CharacterX + 1] == "@")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY, CharacterX + 1] == "C")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY, CharacterX + 1] == "F")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else
                                {
                                    CharacterX = CharacterX + 1;
                                    x++;
                                    AttackMessage = "";
                                }
                            }
                        }
                        else if (AiChoice == 2)
                        {
                            if (CharacterY == 29)
                            {

                            }
                            else
                            {
                                if (Map.RenderData[CharacterY + 1, CharacterX] == "E")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY + 1, CharacterX] == "D")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY + 1, CharacterX] == "B")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY + 1, CharacterX] == "@")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY + 1, CharacterX] == "C")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY + 1, CharacterX] == "F")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else
                                {
                                    CharacterY = CharacterY + 1;
                                    x++;
                                    AttackMessage = "";
                                }
                            }
                        }
                        else if (AiChoice == 3)
                        {
                            if (CharacterY == 1)
                            {

                            }
                            else
                            {
                                if (Map.RenderData[CharacterY - 1, CharacterX] == "E")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY - 1, CharacterX] == "D")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY - 1, CharacterX] == "B")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY - 1, CharacterX] == "@")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY - 1, CharacterX] == "C")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.RenderData[CharacterY - 1, CharacterX] == "F")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else
                                {
                                    CharacterY = CharacterY - 1;
                                    x++;
                                    AttackMessage = "";
                                }
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

        
}

