using System;

namespace TicTacToe
{
    public class Program
    {
        public static void Main()
        {
            var ui = new ConsoleUI(Console.In, Console.Out);
            ui.Run();
        }
    }
}
