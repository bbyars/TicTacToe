using System;
using System.IO;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class ConsoleUITest
    {
        private StubTextReader input;
        private StringWriter output;
        private ConsoleUI ui;

        [SetUp]
        public void CreateUI()
        {
            input = new StubTextReader();
            output = new StringWriter();
            ui = new ConsoleUI(input, output);
        }

        [Test]
        public void ShouldPromptForPlayer()
        {
            input.WriteLine("X");
            
            ui.SelectPlayers(null); 
            
            Assert.That(output.ToString(), Text.StartsWith("Select player (X or O): "));
        }

        [Test]
        public void ShouldContinuePromptingForPlayerUntilValidInput()
        {
            input.WriteLine("INVALID");
            input.WriteLine("X");

            ui.SelectPlayers(null);

            var prompt = "Select player (X or O): " + Environment.NewLine;
            Assert.That(output.ToString(), Text.StartsWith(prompt + prompt));
        }

        [Test]
        public void SelectingPlayerXShouldMakeComputerPlayerO()
        {
            input.WriteLine("X");

            ui.SelectPlayers(null);

            Assert.That(ui.Player("X"), Is.TypeOf(typeof(HumanPlayer)));
            Assert.That(ui.Player("O"), Is.TypeOf(typeof(ComputerPlayer)));
        }

        [Test]
        public void SelectingPlayerOShouldMakeComputerPlayerX()
        {
            input.WriteLine("O");

            ui.SelectPlayers(null);

            Assert.That(ui.Player("O"), Is.TypeOf(typeof(HumanPlayer)));
            Assert.That(ui.Player("X"), Is.TypeOf(typeof(ComputerPlayer)));
        }

        [Test]
        public void ShouldAllowCaseInsensitivePlayerSelection()
        {
            input.WriteLine("x");

            ui.SelectPlayers(null);

            Assert.That(ui.Player("X"), Is.TypeOf(typeof(HumanPlayer)));
        }

        [Test]
        public void PlayShouldUseMovesFromPlayerUntilGameIsOver()
        {
            var game = new Game();
            ui.SetPlayer("X", StubPlayer.FromMoves("1", "2", "3"));
            ui.SetPlayer("O", StubPlayer.FromMoves("4", "5"));

            ui.Play(game);

            Assert.That(game.IsOver());
            Assert.That(game.MovesFor("X"), Is.EqualTo(new[] { "1", "2", "3" }));
            Assert.That(game.MovesFor("O"), Is.EqualTo(new[] { "4", "5" }));
        }

        [Test]
        public void PrintResultShouldShowDraw()
        {
            var game = new Game();
            game.MakeMoves("X1", "O2", "X3", "O4", "X5", "O7", "X6", "O9", "X8");

            ui.PrintResult(game);

            Assert.That(output.ToString(), Is.EqualTo("Draw!" + Environment.NewLine));
        }

        [Test]
        public void PrintResultShouldShowWinner()
        {
            var game = new Game();
            game.MakeMoves("X1", "O3", "X2", "O5", "X9", "O7");

            ui.PrintResult(game);

            Assert.That(output.ToString(), Is.EqualTo("Player O Wins!" + Environment.NewLine));
        }

        public class StubPlayer : IPlayer
        {
            private int index = 0;
            private readonly string[] moves;

            public static StubPlayer FromMoves(params string[] moves)
            {
                return new StubPlayer(moves);
            }

            private StubPlayer(string[] moves)
            {
                this.moves = moves;
            }

            public virtual string GetNextMove()
            {
                var result = moves[index];
                index += 1;
                return result;
            }
        }
    }
}
