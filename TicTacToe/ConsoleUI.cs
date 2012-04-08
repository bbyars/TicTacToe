using System.IO;

namespace TicTacToe
{
    public class ConsoleUI
    {
        private readonly TextWriter output;

        public ConsoleUI(TextWriter output)
        {
            this.output = output;
        }

        public virtual void Run()
        {
            output.Write("Select player (X or O): ");
        }
    }
}