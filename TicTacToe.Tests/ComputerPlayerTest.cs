using System;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class ComputerPlayerTest
    {
        [Test]
        public void GetNextMoveIsRandomWithinAllowedMoves()
        {
            var selectedFirstAllowedMove = false;
            var selectedLastAllowedMove = false;

            for (var i = 0; i < 10000; i++)
            {
                var game = CreateRandomGame();
                var player = new ComputerPlayer(game);
                var allowedMoves = game.AvailableMoves;

                var move = player.GetNextMove();

                Assert.That(allowedMoves.Contains(move));
                if (move == allowedMoves.First())
                    selectedFirstAllowedMove = true;
                if (move == allowedMoves.Last())
                    selectedLastAllowedMove = true;
            }

            Assert.That(selectedFirstAllowedMove, Is.True, "Never selected first allowed move; possible boundary failure");
            Assert.That(selectedLastAllowedMove, Is.True, "Never selected last allowed move; possible boundary failure");
        }

        private static Game CreateRandomGame()
        {
            var game = new Game();
            var random = new Random();
            var numberOfMoves = random.Next(1, 5);

            for (var i = 0; i < numberOfMoves; i++)
            {
                var moveIndex = random.Next(0, game.AvailableMoves.Length);
                var move = game.AvailableMoves[moveIndex];
                game.MakeMove(move);
            }
            
            return game;
        }
    }
}