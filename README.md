A template project for a card game with a logic of moving cards on a board between multiple stacks.

Architecture is build using MVP architecture.
TODO: Add an assembly to the project to avoid unecessery references, thus breaking the MVP approach

There is no DI integration, but it is designed to follow its pricinples where an entry point for a game logic is located under installer.

[GameInstaller](Assets/CardGame/Installers/GameInstaller.cs)
Contains a logic that initializes a board of 5 stacks. Where the last stack is empty.
Use this class as an entry point to the game logic and initialization.
Extract initialization logic to a separate layer, wich will alow you to provide a starting level config from a server, etc. 

[IBoard](Assets/CardGame/Models/IBoard.cs)
Is a model class representing the core logic of a card game that allows to move cards freely between stacks.
Extend it with move rules for implementing different gamemodes that will check if the move is valid, or can be executed.

Right now there is a mocked logic to make a random move,

```
        public void MakeRandomMove()
        {
            CardStack randomStackWithCards = board.CardStacks.GetRandomElement(s => s.Cards.Count > 0);
            Card cardToMove = randomStackWithCards.Cards.Last();
            while (true) {
                int stackIndex = Random.Range(0, board.CardStacks.Count);
                if (board.CardStacks[stackIndex].Cards.Contains(cardToMove)) {
                    continue;
                }
                board.MoveCard(cardToMove, stackIndex);
                return;
            }
        }
```
So consider making an input controller with a state machine to implement a drag and drop, or point and click mechanic for cards movement.
IBoard will return null if the move is invalid.
