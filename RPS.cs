﻿using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;// helping with scoreboard

namespace Rock_Paper_Scissors
{
    static class RPS
    {
        private static string name { get; set; }
        private static int playerScore { get; set; } = 0;
        private static int cpuScore { get; set; } = 0;

        private static void PlayOrHelp()
        {
            string playOrHelp;

            do
            {
                Console.Write("Play [p] \nHow to play? [h] \n> ");
                playOrHelp = Console.ReadLine().ToLower();
                Console.Clear();

                if (playOrHelp == "p")
                {
                    break;
                }
                if (playOrHelp == "h")
                {
                    Console.Write("Choose rock, paper or scissors. \n" +
                        "rock > scissors > paper > rock\n> ");
                    Console.ReadKey(true);
                    Console.Clear();
                    break;
                }
            } while (playOrHelp != "p" && playOrHelp != "h");
        }

        private static string PlayerChoice()
        {
            string playerChoice;// creatng the player's input

            do// with this statement we will validate the input
            {
                Console.Write("Let's play ROCK, PAPER, SCISSORS! \n> ");
                playerChoice = Console.ReadLine().ToLower().Trim();
                Console.Clear();
                // input will be entered over and over again, unless it's valid
            } while (playerChoice != "rock" &&
                playerChoice != "paper" && playerChoice != "scissors");
            // valid input = "rock" || "paper" || "scissors"
            return playerChoice;
        }

        private static void Round()
        {
            int cpuChoice;// creation of AI's choice

            Random rand = new Random();// it will be chosen randomly
            cpuChoice = rand.Next(1, 4);// the variation is from 1 to 3
                                        // 1 = rock, 2 = paper, 3 = scissors
            string plrCh = PlayerChoice();

            switch (cpuChoice)// look through AI's choice
            {
                case 1:// rock
                    {
                        Console.WriteLine("CPU chose Rock! *beep*");
                        if (plrCh == "rock")// rock = rock
                        {
                            Console.Write("------------ \nIt's a draw!");
                        }
                        else
                        {
                            if (plrCh == "paper")// paper > rock
                            {
                                Console.Write("------------ \nYou won!");
                                playerScore++;
                            }
                            if (plrCh == "scissors")// scissors < rock
                            {
                                Console.Write("------------ \nThe CPU won!");
                                cpuScore++;
                            }
                        }
                        break;
                    }
                case 2:// paper
                    {
                        Console.WriteLine("CPU chose Paper! *beep*");
                        if (plrCh == "paper")// paper = paper
                        {
                            Console.Write("------------ \nIt's a draw!");
                        }
                        else
                        {
                            if (plrCh == "scissors")// scissors > paper
                            {
                                Console.Write("------------ \nYou won!");
                                playerScore++;
                            }
                            if (plrCh == "rock")// rock < paper
                            {
                                Console.Write("------------ \nThe CPU won!");
                                cpuScore++;
                            }
                        }
                        break;
                    }
                case 3:// scissors
                    {

                        Console.WriteLine("CPU chose Scissors! *beep*");
                        if (plrCh == "scissors")// scissors = scissors
                        {
                            Console.Write("------------ \nIt's a draw!");
                        }
                        else
                        {
                            if (plrCh == "rock")// rock > scissors
                            {
                                Console.Write("------------ \nYou won!");
                                playerScore++;
                            }
                            if (plrCh == "paper")// paper < scissors
                            {
                                Console.Write("------------ \nThe CPU won!");
                                cpuScore++;
                            }
                        }
                        break;
                    }
            }
            Console.ReadKey(true);
            Console.Clear();
        }

        private static void PlayAgainAndScoreForTheRound()
        {
            //char CharChoiceYesOrNo = ' ';
            // this is the "play_again_variable" creation ^

            string StringChoiceYesOrNo;// it is actually better to use string; i will explain later
                                       // we will use this character later...

            // the next do-while statement will be used to play the game once
            // then if the player chooses to play again, it will play again

            PlayOrHelp();// 1)

            do// cycling once before asking for another try
            {
                Round();// 2)                

                do// Play Again
                {
                    // here we actually validate the play_again_variable
                    Console.Write("Try again? [y/n] \nScore? [s] \n> ");
                    StringChoiceYesOrNo = Console.ReadLine()
                        .ToLower();// input: y = yes / n = no
                    Console.Clear();

                    if (StringChoiceYesOrNo == "s")// SCORE
                    {
                        Console.Write("CPU -> {0} \nPlayer -> {1}",
                            cpuScore, playerScore);// printing the score
                        Console.ReadKey(true);
                        Console.Clear();
                        continue;// returning to the beginnig of the loop
                    }
                } while (StringChoiceYesOrNo != "y" &&
                StringChoiceYesOrNo != "n"
                /*StringChoiceYesOrNo.ToLower() != "score"*/);
                // string - can enter more than 2 symbols / char - only 1
                //assuming someone will enter 2 symbols to crash our program

            } while (StringChoiceYesOrNo == "y");// after choosing 'y', play again
            //Play Again ^
        }

        private static Boolean SaveScoreOrNot()
        {
            string choiceSaveOrNah;

            do
            {
                Console.Write("Save your score? [y/n] \n> ");
                choiceSaveOrNah = Console.ReadLine();
                Console.Clear();

                if (choiceSaveOrNah == "y")
                {
                    return true;
                }
                else if (choiceSaveOrNah == "n")
                {
                    return false;
                }
            } while (choiceSaveOrNah != "y" || choiceSaveOrNah != "n");
            return true;
        }

        private static string ScoreName()
        {
            if (SaveScoreOrNot())
            {
                do// validating the name which will save the highscore
                {
                    Console.Write("Enter a name please: \n*length from 3 up to 10 symbols*" +
                        " \n> ");
                    name = Console.ReadLine();
                    Console.Clear();
                } while (name.Length < 3 || name.Length > 10);
                return name;
            }
            else
            {
                return null;
            }
        }

        private static void SetScore()
        {
            if (ScoreName() != null)
            {
                string score = name + " -> " + playerScore.ToString();
                FileStream fs = new FileStream("score.txt", FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine(score);

                sw.Close();
                fs.Close();
            }
        }

        private static void PrintScore()
        {
            Console.SetWindowSize(35, 13);

            int count = 1;

            Console.WriteLine("\t   *SCOREBOARD*");

            FileStream fs = new FileStream("score.txt", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            Console.WriteLine();

            while (count <= 10)
            {
                string score = sr.ReadLine();
                Console.WriteLine("\t   {0}", score);
                count++;
            }
            for (int i = count; i <= 10; i++)
            {
                Console.WriteLine();
            }
            sr.Close();
            fs.Close();

            Console.Write("  [PLEASE PRESS A KEY TO PROCEED]");
            Console.ReadKey(true);
            Console.Clear();

            Console.SetWindowSize(35, 3);
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;

            ResetHighScores();
        }

        private static void HighSocresAndExit()
        {
            string ScoreBoardOrExit;

            do// HighScore or Exit menu
            {
                Console.Write("View highscores [h] \nExit [x] \n> ");
                ScoreBoardOrExit = Console.ReadLine().ToLower();
                Console.Clear();

                if (ScoreBoardOrExit == "h")
                {
                    PrintScore();
                }
            } while (ScoreBoardOrExit != "h" && ScoreBoardOrExit != "x");
        }

        private static void DrawScoreBoard()
        {
            Console.SetWindowSize(35, 13);

            int count = 1;

            Console.WriteLine("\t   *SCOREBOARD*");

            FileStream fs = new FileStream("score.txt", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);

            Console.WriteLine();

            while (count <= 10)
            {
                string score = sr.ReadLine();
                Console.WriteLine("\t   {0}", score);
                count++;
            }
            for (int i = count; i <= 10; i++)
            {
                Console.WriteLine();
            }
            sr.Close();
            fs.Close();

            Console.Write("  [PLEASE PRESS A KEY TO PROCEED]");
            Console.ReadKey(true);
            Console.Clear();

            Console.SetWindowSize(35, 3);
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }

        private static void ResetHighScores()
        {
            string resOrExit;

            do
            {
                Console.Write("Refresh [r] \nExit [x] \n> ");
                resOrExit = Console.ReadLine().ToLower();
                Console.Clear();

                if (resOrExit == "r")
                {
                    File.Delete("score.txt");

                    do
                    {
                        Console.Write("Exit [x] \n> ");
                        resOrExit = Console.ReadLine().ToLower();
                        Console.Clear();
                        if (resOrExit == "x")
                        {
                            break;
                        }
                    } while (resOrExit != "x");
                }
            } while (resOrExit != "r" && resOrExit != "x");
        }

        public static void RockPaperScissors()// body of the game
        {
            PlayAgainAndScoreForTheRound();// Contains PlayOrHelp and Round
            SetScore();
            HighSocresAndExit();

            Console.WriteLine("Bye!");// 'n' = exit
            Console.ReadKey(true);
        }
    }
}
