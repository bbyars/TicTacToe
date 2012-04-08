Feature: Tic Tac Toe
	As a tic tac toe player
    I want to see the results of the game
    So that I can know who won

Scenario: Three in a row
	Given a new game that looks like
        | 1 | 2 | 3 |
        | 4 | 5 | 6 |
        | 7 | 8 | 9 |
    When we have the following sequence of moves
        | X | O |
        | 1 | 7 |
        | 2 | 8 |
        | 3 |   |
    Then player X is declared the winner

Scenario: Three in a column
	Given a new game that looks like
        | 1 | 2 | 3 |
        | 4 | 5 | 6 |
        | 7 | 8 | 9 |
    When we have the following sequence of moves
        | X | O |
        | 1 | 3 |
        | 2 | 6 |
        | 4 | 9 |
    Then player O is declared the winner

Scenario: Three in a diagonal
	Given a new game that looks like
        | 1 | 2 | 3 |
        | 4 | 5 | 6 |
        | 7 | 8 | 9 |
    When we have the following sequence of moves
        | X | O |
        | 1 | 3 |
        | 5 | 6 |
        | 9 |   |
    Then player X is declared the winner

Scenario: Draw
    Given a new game that looks like
        | 1 | 2 | 3 |
        | 4 | 5 | 6 |
        | 7 | 8 | 9 |
    When we have the following sequence of moves
        | X | O |
        | 1 | 2 |
        | 3 | 4 |
        | 5 | 7 |
        | 6 | 9 |
        | 8 |   |
    Then a draw is declared