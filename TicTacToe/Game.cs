using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class Game
    {
        private static readonly string[] Board = new[] {"1", "2", "3", "4", "5", "6", "7", "8", "9"};
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

        private readonly IDictionary<string, IList<string>> moves = new Dictionary<string, IList<string>>();

        public Game()
        {
            CurrentPlayer = "X";
            moves["X"] = new List<string>();
            moves["O"] = new List<string>();
        }

        public virtual string CurrentPlayer { get; private set; }

        public virtual void MakeMove(string move)
        {
            RecordMoveFor(CurrentPlayer, move);
            ChangePlayers();
        }

        public virtual string[] MovesFor(string player)
        {
            return moves[player].ToArray();
        }

        public virtual string[] AvailableMoves
        {
            get { return Board.Except(MovesFor("X")).Except(MovesFor("O")).ToArray(); }
        }

        public bool IsAllowedMove(string move)
        {
            return AvailableMoves.Contains(move);
        }

        public virtual bool IsOver()
        {
            return IsDraw() || Winner != "";
        }

        public bool IsDraw()
        {
            return Winner == "" && !AvailableMoves.Any();
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
            moves[player].Add(move);
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
            return setOfMoves.All(move => MovesFor(player).Contains(move));
        }
    }
}
