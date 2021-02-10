﻿using System;
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
            maxHealth = 100;
            health = 100;
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
        public void EmergencyEnemyTurn()
        {
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

        public void EnemyTurn()
        {
            if (CharacterX == Program.GM.user.CharacterX)
            {
                if (CharacterY == Program.GM.user.CharacterY - 1)
                {
                    Program.GM.user.TakeDamage(attack);
                    Program.GM.EnemyAttack = name + " attacked " + Program.GM.user.name + " for " + attack + " points of damage!";
                }
                else if (CharacterY == Program.GM.user.CharacterY + 1)
                {
                    Program.GM.user.TakeDamage(attack);
                    Program.GM.EnemyAttack = name + " attacked " + Program.GM.user.name + " for " + attack + " points of damage!";
                }
            }
            else if (CharacterY == Program.GM.user.CharacterY)
            {
                if (CharacterX == Program.GM.user.CharacterX - 1)
                {
                    Program.GM.user.TakeDamage(attack);
                    Program.GM.EnemyAttack = name + " attacked " + Program.GM.user.name + " for " + attack + " points of damage!";
                }
                else if (CharacterX == Program.GM.user.CharacterX + 1)
                {
                    Program.GM.user.TakeDamage(attack);
                    Program.GM.EnemyAttack = name + " attacked " + Program.GM.user.name + " for " + attack + " points of damage!";
                }
            }
            else
            {
                Map.mapData[CharacterY, CharacterX] = Map.BaseMapData[CharacterY, CharacterX];
                Program.GM.EnemyAttack = name + " ";
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

