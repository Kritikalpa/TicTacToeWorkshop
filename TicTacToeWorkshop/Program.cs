﻿using System;

namespace TicTacToeWorkshop
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToeGame game = new TicTacToeGame();
            game.createBoard();
            game.selectLetter();
            game.showBoard();
            game.playerMove();
            game.showBoard();
        }
    }
}
