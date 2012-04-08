Feature: UI
    As a tic tac toe player
    I would like to see the state of the board
    So that I can decide which move to make


Scenario: New game
	Given a new game
	And I am the X player
	When I am prompted to make my move
	Then the board should look like
        | 1 | 2 | 3 |
        | 4 | 5 | 6 |
        | 7 | 8 | 9 |
