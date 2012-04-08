using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class GameTest
    {
        private Game game;

        [SetUp]
        public void CreateGame()
        {
            game = new Game();
        }

        [Test]
        public void XPlayerGoesFirst()
        {
            Assert.That(game.CurrentPlayer, Is.EqualTo("X"));
        }

        [Test]
        public void OPlayerGoesSecond()
        {
            game.MakeMove("1");
            Assert.That(game.CurrentPlayer, Is.EqualTo("O"));
        }

        [Test]
        public void NewGameIsNotOver()
        {
            Assert.That(game.IsOver(), Is.False);
        }

        [Test]
        public void GameIsOverWhenOnePlayerHasThreeInARow()
        {
            MakeMoves("X1", "O7", "X2", "O8", "X3");
            Assert.That(game.IsOver(), Is.True);
        }

        [Test]
        public void WinnerIfXGets123()
        {
            MakeMoves("X1", "O7", "X2", "O8", "X3");
            Assert.That(game.Winner, Is.EqualTo("X"));
        }

        [Test]
        public void WinnerIfOGets456()
        {
            MakeMoves("X1", "O4", "X2", "O5", "X9", "O6");
            Assert.That(game.Winner, Is.EqualTo("O"));
        }

        [Test]
        public void WinnerIfXGets789()
        {
            MakeMoves("X7", "O1", "X8", "O2", "X9");
            Assert.That(game.Winner, Is.EqualTo("X"));
        }

        [Test]
        public void WinnerIfOGets147()
        {
            MakeMoves("X3", "O1", "X2", "O4", "X9", "O7");
            Assert.That(game.Winner, Is.EqualTo("O"));
        }

        [Test]
        public void WinnerIfXGets258()
        {
            MakeMoves("X2", "O1", "X5", "O4", "X8");
            Assert.That(game.Winner, Is.EqualTo("X"));
        }

        [Test]
        public void WinnerIfOGets369()
        {
            MakeMoves("X1", "O3", "X2", "O6", "X8", "O9");
            Assert.That(game.Winner, Is.EqualTo("O"));
        }

        [Test]
        public void WinnerIfXGets159()
        {
            MakeMoves("X1", "O2", "X5", "O4", "X9");
            Assert.That(game.Winner, Is.EqualTo("X"));
        }

        [Test]
        public void WinnerIfOGets357()
        {
            MakeMoves("X1", "O3", "X2", "O5", "X9", "O7");
            Assert.That(game.Winner, Is.EqualTo("O"));
        }

        private void MakeMoves(params string[] moves)
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