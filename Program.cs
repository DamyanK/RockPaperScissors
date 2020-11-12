using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Threading;// with this we can slow the program a bit later

namespace Rock_Paper_Scissors// Project planned and coded by Damyan Kushev
{
    class Program
    {
        //Here we are setting different parameters for the console, so it will look better        
        static void SetConsole()
        {
            Console.SetWindowSize(35, 3);// these are the dimensions
            Console.BufferHeight = Console.WindowHeight;// removing side scrollbar
            Console.BufferWidth = Console.WindowWidth;// removing down scrollbar
            Console.CursorVisible = false;// removing the cursor
            Console.Title = "ROCK, PAPER, SCISSORS";// changes title
        }

        static void Main(string[] args)
        {
            //DON'T CODE UP HERE MATE!
            SetConsole();
            //WRITE FROM NOW ON! 

            //RockPaperScissors();
            RPS.RockPaperScissors();
        }
    }
}
