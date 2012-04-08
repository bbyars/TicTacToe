using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using TechTalk.SpecFlow;

namespace TicTacToe.Tests.Features
{
    [Binding]
    public class StepDefinitions
    {
        private Game game;

        [Given(@"a new game")]
        public void GivenANewGame()
        {
            game = new Game();
        }

        [Given(@"a new game that looks like")]
        public void GivenANewGameThatLooksLike(Table table)
        {
            game = new Game();
        }

        [Given(@"I am the ([XO]) player")]
        public void GivenIAmPlayer(string player)
        {
        }

        [Given(@"we have the following sequence of moves")]
        public void GivenWeHaveTheFollowingSequenceOfMoves(Table table)
        {
            WhenWeHaveTheFollowingSequenceOfMoves(table);
        }

        [When(@"we have the following sequence of moves")]
        public void WhenWeHaveTheFollowingSequenceOfMoves(Table table)
        {
            foreach (var row in table.Rows)
            {
                game.MakeMove(row[0]);
                game.MakeMove(row[1]);
            }
        }

        [When(@"I am prompted to make my move")]
        public void WhenIAmPromptedToMakeMyMove()
        {
        }

        [Then(@"player ([XO]) is declared the winner")]
        public void ThenPlayerXIsDeclaredTheWinner(string player)
        {
            Assert.That(game.Winner, Is.EqualTo(player));
        }
        
        [Then(@"a draw is declared")]
        public void ThenADrawIsDeclared()
        {
            Assert.That(game.IsDraw(), Is.True);
        }

        [Then(@"the board should look like")]
        public void ThenTheBoardShouldLookLike(Table table)
        {
            var input = new StubTextReader();
            var output = new StringWriter();
            var player = new HumanPlayer(game, input, output);
            input.WriteLine(game.AvailableMoves[0]);
            player.GetNextMove();

            Assert.That(output.ToString(), Text.Contains(GetBoardRepresentation(table)));
        }

        private static string GetBoardRepresentation(Table table)
        {
            var headers = new List<string>(table.Header);
            return string.Format(@"
| {0} | {1} | {2} |
| {3} | {4} | {5} |
| {6} | {7} | {8} |".Trim(), headers[0], headers[1], headers[2],
                    table.Rows[0][0], table.Rows[0][1], table.Rows[0][2],
                    table.Rows[1][0], table.Rows[1][1], table.Rows[1][2]);
        }
    }
}
