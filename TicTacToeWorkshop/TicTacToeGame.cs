using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeWorkshop
{
    class TicTacToeGame
    { 
        public char[] board;

        public void createBoard()
        {
            board = new char[10];
            Console.WriteLine("Board Created");
        }
    }
}
