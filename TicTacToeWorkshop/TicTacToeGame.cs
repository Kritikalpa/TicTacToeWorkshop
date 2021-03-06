﻿using System;
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
        public string currentPlayer;
        public bool gameOver = false;

        public void playGame()
        {
            this.createBoard();
            this.selectLetter();
            this.showBoard();
            this.currentPlayer = this.getWhoStartsFirst();
            while (!this.gameOver)
            {
                Console.WriteLine("\n" + this.currentPlayer + " playing his move.....\n");
                if (this.currentPlayer == "player")
                {
                    this.playerMove();
                }
                else
                {
                    int computerMove = this.computerMove();
                    this.board[computerMove] = this.computer;
                    this.gameStatus(this.computer);

                }
                this.showBoard();
            }
            if (this.newGame())
            {
                this.playGame();
            }
        }

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
            int index = Int32.Parse(boardIndex);
            if (isSpaceFree(index, this.board))
            {
                this.board[index] = this.player;
                this.gameStatus(this.player);
            }
            else
            {
                this.playerMove();
            }
        }

        public bool isSpaceFree(int boardIndex, char[] board)
        {
            return board[boardIndex] == ' ';
        }

        public string getWhoStartsFirst()
        {
            Random random = new Random();
            int choice = random.Next(0,2);
            return (choice == 0) ? "player" : "computer"; 
        }

        public void gameStatus(char symbol)
        {
            if (!this.isWinner(symbol, this.board))
            {
                if (isTie())
                {
                    this.gameOver = true;
                    Console.WriteLine("Game is tied");
                }
                else
                {
                    this.currentPlayer = (this.currentPlayer == "player") ? "computer" : "player";
                }
                
            }
            else
            {
                this.gameOver = true;
                Console.WriteLine(this.currentPlayer + " is the winner") ;
            }
        }

        public bool isWinner(char symbol, char[] board)
        {
            return ((board[1] == symbol && board[2] == symbol && board[3] == symbol) ||
                (board[4] == symbol && board[5] == symbol && board[6] == symbol) ||
                (board[7] == symbol && board[8] == symbol && board[9] == symbol) ||
                (board[1] == symbol && board[4] == symbol && board[7] == symbol) ||
                (board[2] == symbol && board[5] == symbol && board[8] == symbol) ||
                (board[3] == symbol && board[6] == symbol && board[9] == symbol) ||
                (board[1] == symbol && board[5] == symbol && board[9] == symbol) ||
                (board[3] == symbol && board[5] == symbol && board[7] == symbol));
        }

        public bool isTie()
        {
            bool tie = true;
            for (int index = 1; index < 10; index++)
            {
                if (this.board[index] == ' ')
                {
                    tie = false;
                    break;
                }
            }
            return tie;
        }

        public int computerMove()
        {
            
            int winningMove = this.getWinningMove(this.computer);
            if (winningMove != 0) return winningMove;
            int playerWinningMove = this.getWinningMove(this.player);
            if (playerWinningMove != 0) return playerWinningMove;
            int cornerIndexMove = getCornerPosition();
            if (cornerIndexMove != 0) return cornerIndexMove;
            if (isSpaceFree(5, this.board)) return 5;
            int otherIndexMove = getOtherPosition();
            if (otherIndexMove != 0) return otherIndexMove;
            return 0;
        }

        public int getWinningMove(char symbol)
        {
            char[] boardCopy = new char[10];
            Array.Copy(this.board, 0, boardCopy, 0, board.Length);
            for (int index = 1; index < 10; index++)
            {
                if (this.isSpaceFree(index, boardCopy))
                {
                    boardCopy[index] = symbol;
                    if (isWinner(symbol, boardCopy))
                    {
                        return index;
                    }
                    else
                    {
                        boardCopy[index] = ' ';
                    }
                }
            }
            
            return 0;
        }

        public int getCornerPosition()
        {
            int[] cornerIndex = { 1, 3, 7, 9 };
            foreach(int index in cornerIndex)
            {
                if(isSpaceFree(index, this.board))
                {
                    return index;
                }
            }
            return 0;
        }

        public int getOtherPosition()
        {
            int[] otherIndex = { 2, 4, 6, 8 };
            foreach (int index in otherIndex)
            {
                if (isSpaceFree(index, this.board))
                {
                    return index;
                }
            }
            return 0;
        }

        public bool newGame()
        {
            Console.WriteLine("\nDo you want to play a new game?");
            Console.Write("(Y/N) : ");
            char newLine = Console.ReadLine()[0];
            if (newLine.Equals('Y')) {
                this.gameOver = false;
                return true;
            }
            else return false;
        }
    }
}
