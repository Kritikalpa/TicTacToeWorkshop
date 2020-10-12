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
            Console.WriteLine("Player choose the X or O: ");
            this.player = Console.ReadLine()[0];
            while (!Regex.IsMatch(this.player.ToString(), @"^[XO]$"))
            {
                Console.WriteLine("Enter X or O: ");
                this.player = Console.ReadLine()[0];
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
        public void showBoard()
        {
            Console.WriteLine("\t" + board[1] + "│" + board[2] + " │" + board[3]);
            Console.WriteLine("     ────────────");
            Console.WriteLine("\t" + board[4] + "│" + board[5] + " │" + board[6]);
            Console.WriteLine("     ────────────");
            Console.WriteLine("\t" + board[7] + "│" + board[8] + " │" + board[9]);
        }

        public void playerMove()
        {
            Console.WriteLine("Enter the board position to play " + this.player);
            string boardIndex = Console.ReadLine();
            while (!Regex.IsMatch(boardIndex, @"^[1-9]$"))
            {
                Console.WriteLine("Enter board position between 0-9");
                boardIndex = Console.ReadLine();
            }
            if (isSpaceFree(boardIndex))
            {
                this.board[Int32.Parse(boardIndex)] = this.player;
            }
        }

        public bool isSpaceFree(string boardIndex)
        {
            return this.board[Int32.Parse(boardIndex)] == ' ';
        }

        public string getWhoStartsFirst()
        {
            Random random = new Random();
            int choice = random.Next(0,2);
            Console.WriteLine(choice);
            return (choice == 0) ? "player" : "computer"; 
        }

        public bool isWinner(char symbol)
        {
            return ((this.board[1] == symbol && this.board[2] == symbol && this.board[3] == symbol) ||
                (this.board[4] == symbol && this.board[5] == symbol && this.board[6] == symbol) ||
                (this.board[7] == symbol && this.board[8] == symbol && this.board[9] == symbol) ||
                (this.board[1] == symbol && this.board[4] == symbol && this.board[7] == symbol) ||
                (this.board[2] == symbol && this.board[5] == symbol && this.board[8] == symbol) ||
                (this.board[3] == symbol && this.board[6] == symbol && this.board[9] == symbol) ||
                (this.board[1] == symbol && this.board[5] == symbol && this.board[9] == symbol) ||
                (this.board[3] == symbol && this.board[5] == symbol && this.board[7] == symbol));
        }
    }
}
