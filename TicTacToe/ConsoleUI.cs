using System.Collections.Generic;
using System.IO;

namespace TicTacToe
{
    public class ConsoleUI
    {
        private readonly IDictionary<string, IPlayer> players = new Dictionary<string, IPlayer>();
        private readonly TextReader input;
        private readonly TextWriter output;

        public ConsoleUI(TextReader input, TextWriter output)
        {
            this.input = input;
            this.output = output;
        }

        public virtual IPlayer Player(string name)
        {
            return players[name];
        }

        public virtual void SetPlayer(string name, IPlayer player)
        {
            players[name] = player;
        }

        public virtual void Run()
        {
            var game = new Game();
            SelectPlayers(game);
            Play(game);
            PrintResult(game);
        }

        public virtual void SelectPlayers(Game game)
        {
            string choice;
            do
            {
                output.Write("Select player (X or O): ");
                choice = input.ReadLine().ToUpper();
                output.WriteLine();
            } while (!"XO".Contains(choice));

            var computer = "XO".Replace(choice, "");
            SetPlayer(choice, new HumanPlayer(game, input, output));
            SetPlayer(computer, new ComputerPlayer(game));
        }

        public virtual void Play(Game game)
        {
            while (!game.IsOver())
            {
                var move = Player(game.CurrentPlayer).GetNextMove();
                game.MakeMove(move);
            }
        }

        public virtual void PrintResult(Game game)
        {
            if (game.IsDraw())
                output.WriteLine("Draw!");
            else
                output.WriteLine("Player {0} Wins!", game.Winner);
        }
    }
}
