using System;

namespace TicTacToe
{
    public class ComputerPlayer
    {
        private readonly Game game;

        public ComputerPlayer(Game game)
        {
            this.game = game;
        }

        public virtual string GetNextMove()
        {
            var random = new Random();
            var moveIndex = random.Next(0, game.AvailableMoves.Length);
            return game.AvailableMoves[moveIndex];
        }
    }
}