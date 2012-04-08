# Tic Tac Toe TDD example

This was written to demonstrate test-driven development techniques by writing a console version of tic tac toe.  It also shows off some behavior driven development approaches with the SpecFlow features, which I wrote as initial acceptance tests before going into smaller-grained unit test cycles.

Since this was developed as a teaching example, I did not use any mocking library.  There were a couple of places where I felt mocks would have been more expressive - for instance, where MakeMoves is called in ConsoleUITest and HumanPlayerTest to simulate certain game results.

## Sequence

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

## Observations

### Testing the Boundaries of the System

The Program class has no tests.  Consequently, it is as thin as possible, simply delegating to the UI class with standard input and standard output.  This is one of those decisions that tests drive you to that has knock-on design benefits.  Keeping the boundaries of your code (UI, integration points) as thin as possible means that the core of your logic is reusable in other contexts.

### Testing the User Interface

Test-driving the UI is tricky.  A very common UI design would be to simply have it run an infinite loop, or at least run through an entire Game, before returning from the Run method.  The problem is that makes the tests very hard to write, as each test would have to cover an entire game.  There's a tradeoff between the API that you want the UI to expose and what the tests need to work at finer grained levels.  In many cases, when that tradeoff presents itself, it's indicative of a class that wants to be extracted.  I didn't see such a refactoring in this example, and decided that I would prefer having the tests rather than a bunch of private methods on the UI class.  I think this is common in UI scenarios - unlike domain classes, you aren't expected to expose the class interface to the rest of the system, so it isn't as important to be concerned around method visibility.

### Testing Random Behavior

Another interesting micro-study is the ComputerPlayer class, since it exhibits random behavior (it's not a smart computer player).  In this case, there's a single test for the class.  I already knew what I wanted ComputerPlayer to do, and it was quite small, so there was less design value in writing fine-grained unit tests than in most of the other test cases.  However, I saw a lot of value in having a robust test for QA purposes.  And indeed, I made the same boundary condition mistake that I always seem to make when dealing with random numbers, something my test told me quickly.  Making a mistake a lot helps you know what to look for...

### Test Scaffolding

One final point: there are three classes in the Tests project which are not tests of any production class: StubTextReader, StubPlayer, and GameExtensions. One of those, StubTextReader, I also wrote tests for.  It is very common to write scaffolding classes that are there simply to support the tests, and sometimes that scaffolding itself benefits from tests.  Treating test code as second-class code is a surefire way to get into trouble once the number of tests grows.  Test code is still code that you have to maintain, and therefore requires the same care you would take in production code.