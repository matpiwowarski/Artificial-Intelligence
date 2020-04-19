# Tic-Tac-Toe

![Screen](https://github.com/matpiwowarski/Local-Search-Algorithms/blob/master/Screenshots/tictactoe.png?raw=true)

## General information

Tic-tac-toe is a game for two players (you as `X` and computer as `O`). You take turns marking the spaces in a 3×3 grid. The player who succeeds in placing three of their marks in a horizontal, vertical, or diagonal row wins the game. Each game the player starts in exchange: this time user starts, next time bot starts. Score for user, bot and tie are saved and there's no limit.
You have a choice of levels 1 - 9. There's no way to win a game on the level 9. Level number represents how many moves bot can predict. Program uses `Alpha–beta pruning` algorithm to find best possible moves for the computer.
**Have fun!**


## Main Classes:

- **TicTacToe**

Class which contains information about `GameStatus`, tic-tac-toe board state, which player is starting, level of the game, user score, bot score and tie score.

- **TicTacToeBot**

Representation of the computer player in the game. He plays as `Circle` symbol in the tic-tac-toe game.

- **TicTacToeUser**

Representation of the user in the game. He plays as `Cross` symbol in the tic-tac-toe game.

- **TicTacToeChecker**

Checks states of the tic-tac-toe board and return the information about it.

Examples:
- Check game status
- Check if game ended
- Check if symbol won

- **TicTacToeSymbol**

Enum class which represents tile of the tic-tac-toe board: `Empty`, `Circle`, `Cross`.

- **GameStatus**

Enum class which represents game status: `InProgress`, `Tie`, `UserWon`, `BotWon`.

## Algorithms:
### 1. Minimax algorithm

This tutorial helped me to understand Minimax algorithm and implement it:

https://youtu.be/trKjYdBASyQ

### 2. Alpha–beta pruning

It's just improved version of `Minimax algorithm`.

Useful video:

https://youtu.be/l-hh51ncgDI

