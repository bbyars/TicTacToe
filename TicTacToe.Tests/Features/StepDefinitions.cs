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

        [When(@"we have the following sequence of moves")]
        public void WhenWeHaveTheFollowingSequenceOfMoves(Table table)
        {
            foreach (var row in table.Rows)
            {
                game.MakeMove(row[0]);
                game.MakeMove(row[1]);
            }
        }

        [Given(@"I am the X player")]
        public void GivenIAmTheXPlayer()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"player ([XO]) is declared the winner")]
        public void ThenPlayerXIsDeclaredTheWinner(string player)
        {
            Assert.That(game.Winner, Is.EqualTo(player));
        }

        [Then(@"the board should look like")]
        public void ThenTheBoardShouldLookLike(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
