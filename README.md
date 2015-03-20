# 0hn0 Solver

## Challenge
This is an Algorithm Challenge: to design a solver for the game [0hn0](http://0hn0.com/).  The solver should accept a string representation of a board of varying dimensions and return a solution.  Each solution will be timed.  The format of the board is defined in the following sections


## Puzzle Format
Example Board: `3,3|1,-,-,-,2,r,-,4,-`

The first segment before the `|` specifies the board's dimensions:
  * Number of Columns
  * Number of Rows

The second segment specifies the values from left to right, top to bottom.
  * A number (`n`) indicates that the cell is **blue** and can see `n` other blue cells.
  * The character `r` indicates that the cell is **red**.
  * The character `-` indicates that the cell is **blank**.

## Solution Format
Example Board (solution): `3,3|1,3,r,r,2,r,2,4,2`

The same formatting rules apply to the solution.  *Obviously, the goal is to replace all the `-` characters, so those are not expected to be part of the solution.*
