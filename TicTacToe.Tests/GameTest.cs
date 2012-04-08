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
            game.MakeMoves("X1", "O7", "X2", "O8", "X3");
            Assert.That(game.IsOver(), Is.True);
        }

        [Test]
        public void WinnerIfXGets123()
        {
            game.MakeMoves("X1", "O7", "X2", "O8", "X3");
            Assert.That(game.Winner, Is.EqualTo("X"));
        }

        [Test]
        public void WinnerIfOGets456()
        {
            game.MakeMoves("X1", "O4", "X2", "O5", "X9", "O6");
            Assert.That(game.Winner, Is.EqualTo("O"));
        }

        [Test]
        public void WinnerIfXGets789()
        {
            game.MakeMoves("X7", "O1", "X8", "O2", "X9");
            Assert.That(game.Winner, Is.EqualTo("X"));
        }

        [Test]
        public void WinnerIfOGets147()
        {
            game.MakeMoves("X3", "O1", "X2", "O4", "X9", "O7");
            Assert.That(game.Winner, Is.EqualTo("O"));
        }

        [Test]
        public void WinnerIfXGets258()
        {
            game.MakeMoves("X2", "O1", "X5", "O4", "X8");
            Assert.That(game.Winner, Is.EqualTo("X"));
        }

        [Test]
        public void WinnerIfOGets369()
        {
            game.MakeMoves("X1", "O3", "X2", "O6", "X8", "O9");
            Assert.That(game.Winner, Is.EqualTo("O"));
        }

        [Test]
        public void WinnerIfXGets159()
        {
            game.MakeMoves("X1", "O2", "X5", "O4", "X9");
            Assert.That(game.Winner, Is.EqualTo("X"));
        }

        [Test]
        public void WinnerIfOGets357()
        {
            game.MakeMoves("X1", "O3", "X2", "O5", "X9", "O7");
            Assert.That(game.Winner, Is.EqualTo("O"));
        }

        [Test]
        public void MovesForShouldShowHistoryOfMoves()
        {
            game.MakeMoves("X1", "O3", "X2", "O5", "X9");
            Assert.That(game.MovesFor("X"), Is.EqualTo(new[] { "1", "2", "9" }));
            Assert.That(game.MovesFor("O"), Is.EqualTo(new[] { "3", "5" }));
        }

        [Test]
        public void AvailableMovesShouldShowAvailableMoves()
        {
            game.MakeMoves("X1", "O3", "X2", "O5", "X9");
            Assert.That(game.AvailableMoves, Is.EqualTo(new[] {"4", "6", "7", "8"}));
        }

        [Test]
        public void ValidMovesAreAllowed()
        {
            Assert.That(game.IsAllowedMove("1"));
        }

        [Test]
        public void MovesAlreadyTakenAreNotAllowed()
        {
            game.MakeMoves("X1", "O3", "X2", "O5", "X9");
            Assert.That(game.IsAllowedMove("1"), Is.False);
        }

        [Test]
        public void InvalidInputIsNotAllowed()
        {
            Assert.That(game.IsAllowedMove("INVALID"), Is.False);
            Assert.That(game.IsAllowedMove("12"), Is.False);
        }

        [Test]
        public void NewGameIsNotADraw()
        {
            Assert.That(game.IsDraw(), Is.False);
        }

        [Test]
        public void DrawIfNoWinnerAndNoAvailableMoves()
        {
            game.MakeMoves("X1", "O2", "X3", "O4", "X5", "O7", "X6", "O9", "X8");
            Assert.That(game.IsDraw(), Is.True);
        }

        [Test]
        public void IsOverIfDraw()
        {
            game.MakeMoves("X1", "O2", "X3", "O4", "X5", "O7", "X6", "O9", "X8");
            Assert.That(game.IsOver());
        }
    }
}
