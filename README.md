# Tic Tac Toe TDD example

This was written to demonstrate test-driven development techniques by writing a console version of tic tac toe.  It also shows off some behavior driven development approaches with the SpecFlow features, which I wrote as initial acceptance tests before going into smaller-grained unit test cycles.

Since this was developed as a teaching example, I did not use any mocking library.  There were a couple of places where I felt mocks would have been more expressive - for instance, where MakeMoves is called in ConsoleUITest and HumanPlayerTest to simulate certain game results.

I practiced this a couple of times trying different strategies.  The first time, I tried a purely top-down strategy, and got stuck trying to drive the design through the UI.  The second time, I approached it more bottom-up, test-driving the rules of the game before incorporating the UI.  The basic sequence of events was

1. Write a game feature that describes a player winning a game.
2. Start the test-driven design by getting players alternating between X and O.
3. Started writing a test to verify 3 in a row wins.
4. Decided that was too big a step, and instead got it such that 3 in a row ends the game (no assignment of victory).
5. Sorted out winner
6. Iterated on the above with 3 in a row vertically and diagnoally until I got all win cases correct.
7. Wrote a feature describing draws.
8. Test-drove having the Game class understand draws.
9. Wrote initial feature describing the UI.
10. Started test-driving the UI.  Realized it was too big and would need Player colloborators.
11. Test-drove HumanPlayer and ComputerPlayer classes, delegating some of the UI to HumanPlayer.
12. Finished UI.  I had to expose much more of the UI than I typically would want to in order to test-drive it.  I also had to hand-craft a stub (PlayerStub) to verify Play behavior.
13. Wired up Console.In and Console.Out to the UI and played the game on the console.