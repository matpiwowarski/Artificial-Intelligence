# N Queens problem - Local Search Algorithms

## Main Classes:
- **NQueensProblem**

manages the `chessboard` and `algorithm`.
- **Parameters**

stores the parameters selected by the user.

- **Chessboard**

stores `size of chessboard`, `actual state of the chessboard` (two dimensional array), `information if state is solved`, `steps taken` in algorithm, `heuristic result` of actual state and parameters.

- **Algorithm**

has the necessary functions that will be used by inheriting classes, for example: `heuristic` function.

## Algorithms:
### 1. Hill Climbing Algorithm - Hill Climbing with random restart

Solves problem with defualt parameters for: `4x4`, `5x5`, `6x6`, `7x7`, `8x8`, `9x9`

Parameters: `MaximumNumberOfSteps` (maximum number of steps) - default: `50`

**How does this work?**

1. Move queen vertically (from top to bottom) in every column (from left to right):
  queen stays on place where heuristic result is the lowest.
2. If heuristic result after move is 0: return solved board
3. If board is blocked (we didn't move any queen in 1st step) new board will be generated.
4. Repeat steps 1, 2 and 3 until maximum number of steps is reached

### 2. Simulated Annealing Algorithm
### 3. Local Beam Search Algorithm
### 4. Genetic Algorithm
