using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace TicTacToe.Tests
{
    public static class GameExtensions
    {
        public static void MakeMoves(this Game game, params string[] moves)
        {
            foreach (var move in moves)
            {
                var player = move.Substring(0, 1);
                var square = move.Substring(1);
                Assert.That(player, Is.EqualTo(game.CurrentPlayer));
                game.MakeMove(square);
            }
        }
    }
}