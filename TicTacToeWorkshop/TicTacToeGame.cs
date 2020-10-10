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
            for (int index = 0; index < 10; index++)
            {
                board[index] = ' ';
            }
            Console.WriteLine("Board Created");
        }
    }
}
