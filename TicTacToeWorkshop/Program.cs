using System;

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
            string firstPlayer = game.getWhoStartsFirst();
            if (firstPlayer == "player")
            {
                game.playerMove();
                game.showBoard();
                bool isWinner = game.isWinner(game.player);
                if (isWinner)
                {
                    Console.WriteLine("Player is the winner");
                }
            } 
        }
    }
}
