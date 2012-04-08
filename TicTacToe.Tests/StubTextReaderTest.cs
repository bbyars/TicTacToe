using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class StubTextReaderTest
    {
        [Test]
        public void ReadLineReturnsEmptyStringIfNothingWritten()
        {
            var reader = new StubTextReader();
            Assert.That(reader.ReadLine(), Is.EqualTo(""));
        }

        [Test]
        public void ReadLineReturnsFirstLineOfWhatWasWritten()
        {
            var reader = new StubTextReader();
            reader.WriteLine("First Line");
            reader.WriteLine("Second Line");

            Assert.That(reader.ReadLine(), Is.EqualTo("First Line"));
        }

        [Test]
        public void ReadLineRemembersWhatWasAlreadyRead()
        {
            var reader = new StubTextReader();
            reader.WriteLine("First Line");
            reader.WriteLine("Second Line");
            reader.ReadLine();

            Assert.That(reader.ReadLine(), Is.EqualTo("Second Line"));
        }
    }
}
