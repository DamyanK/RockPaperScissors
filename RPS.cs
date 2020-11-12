using System;
using System.Collections.Generic;
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
        private static int playOrHelpCount { get; set; } = 0;

        public static void PlayOrHelp()
        {
            string playOrHelp;

            do
            {
                if (playOrHelpCount != 0)
                {
                    break;
                }

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
                }
            } while (playOrHelp != "p" && playOrHelp != "h");
            playOrHelpCount++;
        }

        public static string PlayerChoice()
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

        public static void Round()
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

        public static void PlayAgainAndScoreForTheRound()
        {
            //char CharChoiceYesOrNo = ' ';
            // this is the "play_again_variable" creation ^

            string StringChoiceYesOrNo;// it is actually better to use string; i will explain later
            // we will use this character later...

            // the next do-while statement will be used to play the game once
            // then if the player chooses to play again, it will play again

            do// cycling once before asking for another try
            {
                PlayOrHelp();// 1)
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

        public static void SaveScoreOrNot()
        {
            string choiceSaveOrNah;

            do
            {
                Console.Write("Save your score? [y/n] \n> ");
                choiceSaveOrNah = Console.ReadLine();
                Console.Clear();

                if (choiceSaveOrNah == "y")
                {
                    ScoreName();
                    break;
                }
                else if (choiceSaveOrNah == "n")
                {
                    break;
                }
            } while (choiceSaveOrNah != "y" || choiceSaveOrNah != "n");
        }

        public static void ScoreName()
        {
            do// validating the name which will save the highscore
            {
                Console.Write("Enter a name please: \n*length from 3 up to 10 symbols*" +
                    " \n> ");
                name = Console.ReadLine();
                Console.Clear();
            } while (name.Length < 3 || name.Length > 10);
        }

        public static void SetScore()
        {
            string score = name + " -> " + playerScore.ToString();

            FileStream fs = new FileStream("score.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(score);

            sw.Close();
            fs.Close();
        }

        public static void PrintScore()
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

        public static void HighSocresAndExit()
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

        public static void DrawScoreBoard()
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

        public static void ResetHighScores()
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
                    DrawScoreBoard();

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
            SaveScoreOrNot();
            SetScore();
            HighSocresAndExit();

            Console.WriteLine("Bye!");// 'n' = exit
            Console.ReadKey(true);
            //Thread.Sleep(750);// slowing a bit instead of waiting ReadKey()
        }

        private static void todo()
        {
            // Check leaderboard not saving with names!
            // Sort point asscending
            // Check ToLower()
        }
    }
}
