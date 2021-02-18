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

        private Player user;
        private GameManager GM;

        


        public Enemy(GameManager GMTarget)
        {
            GM = GMTarget;
            
            maxHealth = 100;
            health = 50;
            Alive = true;
            name = "Your Foe";
            CharacterX = 10;
            CharacterY = 4;
            attack = 5;
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
            Map.mapData[CharacterY, CharacterX] = "E";
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
                    Map.mapData[CharacterY, CharacterX] = Map.BaseMapData[CharacterY, CharacterX];
                    AttackMessage = name + " ";
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
                                if (Map.mapData[CharacterY, CharacterX - 1] == "E")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY, CharacterX - 1] == "~")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY, CharacterX - 1] == "C")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY, CharacterX - 1] == "F")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY, CharacterX - 1] == "^")
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
                                if (Map.mapData[CharacterY, CharacterX + 1] == "E")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY, CharacterX + 1] == "~")
                                {
                                    x++;
                                   AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY, CharacterX + 1] == "C")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY, CharacterX + 1] == "F")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY, CharacterX + 1] == "^")
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
                                if (Map.mapData[CharacterY + 1, CharacterX] == "E")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY + 1, CharacterX] == "~")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY + 1, CharacterX] == "C")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY + 1, CharacterX] == "F")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY + 1, CharacterX] == "^")
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
                                if (Map.mapData[CharacterY - 1, CharacterX] == "E")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY - 1, CharacterX] == "~")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY - 1, CharacterX] == "C")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY - 1, CharacterX] == "F")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY - 1, CharacterX] == "^")
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
                    Map.mapData[CharacterY, CharacterX] = Map.BaseMapData[CharacterY, CharacterX];
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
                                if (Map.mapData[CharacterY, CharacterX - 1] == "E")
                                {
                                    x++;
                                    AttackMessage = "";
                                } else if (Map.mapData[CharacterY, CharacterX - 1] == "@")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY, CharacterX - 1] == "C")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY, CharacterX - 1] == "F")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY, CharacterX - 1] == "^")
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
                                if (Map.mapData[CharacterY, CharacterX + 1] == "E")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY, CharacterX - 1] == "@")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY, CharacterX + 1] == "C")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY, CharacterX + 1] == "F")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY, CharacterX + 1] == "^")
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
                                if (Map.mapData[CharacterY + 1, CharacterX] == "E")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY, CharacterX - 1] == "@")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY + 1, CharacterX] == "C")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY + 1, CharacterX] == "F")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY + 1, CharacterX] == "^")
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
                                if (Map.mapData[CharacterY - 1, CharacterX] == "E")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY, CharacterX - 1] == "@")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY - 1, CharacterX] == "C")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY - 1, CharacterX] == "F")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY - 1, CharacterX] == "^")
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
                    Map.mapData[CharacterY, CharacterX] = Map.BaseMapData[CharacterY, CharacterX];
                    AttackMessage = name + " ";
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
                                if (Map.mapData[CharacterY, CharacterX - 1] == "E")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY, CharacterX - 1] == "@")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY, CharacterX - 1] == "~")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY, CharacterX - 1] == "C")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY, CharacterX - 1] == "F")
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
                                if (Map.mapData[CharacterY, CharacterX + 1] == "E")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY, CharacterX - 1] == "@")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY, CharacterX + 1] == "~")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY, CharacterX + 1] == "C")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY, CharacterX + 1] == "F")
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
                                if (Map.mapData[CharacterY + 1, CharacterX] == "E")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY, CharacterX - 1] == "@")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY + 1, CharacterX] == "~")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY + 1, CharacterX] == "C")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY + 1, CharacterX] == "F")
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
                                if (Map.mapData[CharacterY - 1, CharacterX] == "E")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY, CharacterX - 1] == "@")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY - 1, CharacterX] == "~")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY - 1, CharacterX] == "C")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY - 1, CharacterX] == "F")
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
                    Map.mapData[CharacterY, CharacterX] = Map.BaseMapData[CharacterY, CharacterX];
                    AttackMessage = name + " ";
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
                                if (Map.mapData[CharacterY, CharacterX - 1] == "E")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY, CharacterX - 1] == "@")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY, CharacterX - 1] == "C")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY, CharacterX - 1] == "F")
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
                                if (Map.mapData[CharacterY, CharacterX + 1] == "E")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY, CharacterX - 1] == "@")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY, CharacterX + 1] == "C")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY, CharacterX + 1] == "F")
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
                                if (Map.mapData[CharacterY + 1, CharacterX] == "E")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY, CharacterX - 1] == "@")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY + 1, CharacterX] == "C")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY + 1, CharacterX] == "F")
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
                                if (Map.mapData[CharacterY - 1, CharacterX] == "E")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY, CharacterX - 1] == "@")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY - 1, CharacterX] == "C")
                                {
                                    x++;
                                    AttackMessage = "";
                                }
                                else if (Map.mapData[CharacterY - 1, CharacterX] == "F")
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

