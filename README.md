# TicTacToe

This is a program designed to run one million games of Tic Tac Toe.
In these games the desired symbol is placed randomly on a 3x3 grid.

X is required to place its symbol first, followed by O.
Each symbol alternates in being placed, until the board is filled or there is a winner.
In order to win, there needs to be 3 of a symbol in a row, whether horizontal, vertical, or diagonal.

If X has 3 symbols in a row, X is declared the winner.
If O has 3 symbols in a row, O is declared the winner.
If the board is filled and neither X nor O has 3 symbols in a row, the game is declared a draw.

All symbols cannot replace already placed symbols, and can only be placed in an empty space.

In this scenario, the expected values are:
    X is the winner approximately 58% of the time.
    O is the winner approximately 28% of the time.
    A draw occurs approximately 14% of the time.
