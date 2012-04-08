using System;
using System.IO;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class HumanPlayerTest
    {
        private Game game;
        private StubTextReader input;
        private StringWriter output;
        private HumanPlayer player;

        [SetUp]
        public void CreatePlayer()
        {
            game = new Game();
            input = new StubTextReader();
            output = new StringWriter();
            player = new HumanPlayer(game, input, output);
        }

        [Test]
        public void GetNextMoveShouldAllOptions()
        {
            input.WriteLine("1");
            player.GetNextMove();

            Assert.That(output.ToString(), Text.Contains(@"
| 1 | 2 | 3 |
| 4 | 5 | 6 |
| 7 | 8 | 9 |".Trim()));
        }

        [Test]
        public void GetNextMoveShouldShowAllPriorMoves()
        {
            game.MakeMoves("X1", "O2", "X3", "O4", "X5", "O6");
            input.WriteLine("7");
            player.GetNextMove();

            Assert.That(output.ToString(), Text.Contains(@"
| X | O | X |
| O | X | O |
| 7 | 8 | 9 |".Trim()));
        }

        [Test]
        public void GetNextMoveShouldPromptForMove()
        {
            input.WriteLine("1");
            player.GetNextMove();
            Assert.That(output.ToString(), Text.Contains("Select your move (1, 2, 3, 4, 5, 6, 7, 8, 9): "));
        }

        [Test]
        public void GetNextMoveShouldOnlyShowAvailableMoves()
        {
            input.WriteLine("8");
            game.MakeMoves("X1", "O2", "X3", "O4", "X5", "O6");
            player.GetNextMove();
            Assert.That(output.ToString(), Text.Contains("Select your move (7, 8, 9): "));
        }

        [Test]
        public void GetNextMoveShouldReturnValueFromInput()
        {
            input.WriteLine("5");
            Assert.That(player.GetNextMove(), Is.EqualTo("5"));
        }

        [Test]
        public void ShouldContinuePromptingOnInvalidInput()
        {
            input.WriteLine("INVALID");
            input.WriteLine("1");

            var result = player.GetNextMove();

            var prompt = "Select your move (1, 2, 3, 4, 5, 6, 7, 8, 9): " + Environment.NewLine;
            Assert.That(output.ToString(), Text.Contains(prompt + prompt));
            Assert.That(result, Is.EqualTo("1"));
        }
    }
}
