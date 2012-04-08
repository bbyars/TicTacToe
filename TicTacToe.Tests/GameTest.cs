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
            game.MakeMove("1");
            game.MakeMove("7");
            game.MakeMove("2");
            game.MakeMove("8");
            game.MakeMove("3");

            Assert.That(game.IsOver(), Is.True);
        }

        [Test]
        public void XPlayerWinsIfGetsThreeInARow()
        {
            game.MakeMove("1");
            game.MakeMove("7");
            game.MakeMove("2");
            game.MakeMove("8");
            game.MakeMove("3");

            Assert.That(game.Winner, Is.EqualTo("X"));
        }
    }
}