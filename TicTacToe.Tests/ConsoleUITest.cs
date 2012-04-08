using System.IO;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class ConsoleUITest
    {
        [Test]
        public void ShouldPromptForPlayer()
        {
            var output = new StringWriter();
            var ui = new ConsoleUI(output);

            ui.Run();

            Assert.That(output.ToString(), Text.StartsWith("Select player (X or O): "));
        }
    }
}