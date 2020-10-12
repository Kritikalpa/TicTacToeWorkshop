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
            game.currentPlayer = firstPlayer;
            if (game.currentPlayer.Equals("player"))
            {
                game.playerMove();
                game.showBoard();
                game.gameStatus(game.player);
            }
        }
    }
}
