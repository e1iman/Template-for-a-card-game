﻿A template project for a card game with a logic of moving cards on a board between multiple stacks.

Architecture is built using the MVP architecture.

Entry point for the game logic is located under the installer.
[GameInstaller](Assets/CardGame/Installers/GameInstaller.cs)
It contains logic that initializes a board of 5 stacks. Where the last stack is empty.
Use this class as an entry point to the game logic and initialization.
Extract initialization logic to a separate layer, which will allow you to provide a starting-level config from a server, etc.

[IBoard](Assets/CardGame/Models/IBoard.cs)
It is a model class representing the core logic of a card game that allows for moving cards freely between stacks.
As typically a casual games right now often has a power up to move a card from inside a stack, the code for `IBoard` model allows you to set what Card you want to move and the index of a target stack.
If a game needs a custom check for what card is available to be moved, it is expected to be implemented via custom [IMoveValidation](Assets/CardGame/Models/IMoveValidation.cs)

Right now, there is a mocked logic to make a random move.
For fancy drag and drop / or point a click, a custom controller is required to be implemented.
It can use `IMoveValidation` to check if a move is valid to play a custom animation for invalid moves.
For the sake of saving time template now only contains mocked "make random move" logic.

Future improvements:
* Move to DI (Zenject / VContainer)
* Add assemblies to isolate Models / Presenters / Views
* Add controllers to trigger cards move animation.

AI tools used:
* Grammarly AI to fix typos in readme file)
* Rider AI Assist to generate a method body for simple operations (swap cards, make random moves, etc)

How to play:
1. Clone a repo
2. Open in unity a scene (Assets/Scenes/SampleScene.unity) ![image](https://github.com/user-attachments/assets/b4ab4b26-9814-4ff9-a507-7007c756fe7a)
3. Enter a play mode in a 16:9 aspect ratio. The UI is mocked and is not designed to be adaptive

![image](https://github.com/user-attachments/assets/e8891676-8ac0-4427-ae74-473d3b0396e3)

