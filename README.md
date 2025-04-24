A template project for a card game with a logic of moving cards on a board between multiple stacks.

Architecture is built using the MVP architecture.
TODO: Add an assembly to the project to avoid unnecessary references, thus breaking the MVP approach

There is no DI integration, but it is designed to follow its principles, where an entry point for a game logic is located under the installer.

[GameInstaller](Assets/CardGame/Installers/GameInstaller.cs)
It contains logic that initializes a board of 5 stacks. Where the last stack is empty.
Use this class as an entry point to the game logic and initialization.
Extract initialization logic to a separate layer, which will allow you to provide a starting-level config from a server, etc. 

[IBoard](Assets/CardGame/Models/IBoard.cs)
It is a model class representing the core logic of a card game that allows for moving cards freely between stacks.
Extend it with move rules for implementing different game modes that will check if the move is valid or can be executed.

Right now, there is a mocked logic to make a random move,

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

AI tools used:
* Grammarly AI to fix typos in readme file)
* Rider AI Assist to generate a method body for simple operations (swap cards, make random moves, etc)

How to play:
1. Clone a repo
2. Open in unity a scene (Assets/Scenes/SampleScene.unity) ![image](https://github.com/user-attachments/assets/b4ab4b26-9814-4ff9-a507-7007c756fe7a)
3. Enter a play mode in a 16:9 aspect ratio. The UI is mocked and is not designed to be adaptive

![image](https://github.com/user-attachments/assets/e8891676-8ac0-4427-ae74-473d3b0396e3)

