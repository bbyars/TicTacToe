using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class Game
    {
        private static readonly string[][] WinningMoves = new[]
        {
            // rows
            new[] { "1", "2", "3" },
            new[] { "4", "5", "6" },
            new[] { "7", "8", "9" },
            // columns
            new[] { "1", "4", "7" },
            new[] { "2", "5", "8" },
            new[] { "3", "6", "9" },
            // diagonals
            new[] { "1", "5", "9" },
            new[] { "3", "5", "7" }
        };

        private readonly IDictionary<string, string> moves = new Dictionary<string, string>();

        public Game()
        {
            CurrentPlayer = "X";
            moves["X"] = "";
            moves["O"] = "";
        }

        public virtual string CurrentPlayer { get; private set; }

        public virtual void MakeMove(string move)
        {
            RecordMoveFor(CurrentPlayer, move);
            ChangePlayers();
        }

        public virtual bool IsOver()
        {
            return Winner != "";
        }

        public virtual string Winner
        {
            get
            {
                if (PlayerHasWon("X"))
                    return "X";
                if (PlayerHasWon("O"))
                    return "O";
                return "";
            }
        }

        private void RecordMoveFor(string player, string move)
        {
            moves[player] += move;
        }

        private void ChangePlayers()
        {
            CurrentPlayer = (CurrentPlayer == "X" ? "O" : "X");
        }

        private bool PlayerHasWon(string player)
        {
            return WinningMoves.Any(setOfMoves => HasAllMoves(player, setOfMoves));
        }

        private bool HasAllMoves(string player, IEnumerable<string> setOfMoves)
        {
            return setOfMoves.All(move => moves[player].Contains(move));
        }
    }
}