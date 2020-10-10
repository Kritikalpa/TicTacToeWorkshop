using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TicTacToeWorkshop
{
    class TicTacToeGame
    { 
        public char[] board;
        public char player;
        public char computer;

        public void createBoard()
        {
            this.board = new char[10];
            for (int index = 0; index < 10; index++)
            {
                board[index] = ' ';
            }
            Console.WriteLine("Board Created");
        }

        public void selectLetter()
        {
            bool selected = false;
            while(selected == false)
            {
                Console.WriteLine("Player choose the X or O: ");
                this.player = Console.ReadLine()[0];
                while (!Regex.IsMatch(this.player.ToString(), @"^[XO]$"))
                {
                    Console.WriteLine("Enter X or O: ");
                    this.player = Console.ReadLine()[0];
                }
                selected = true;
            }
            if (this.player.Equals('X')){
                this.computer = 'O';
            }
            else
            {
                this.computer = 'X';
            }
            Console.WriteLine("Player: " + this.player + ", Computer: " + this.computer);
        }
    }
}
