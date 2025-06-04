# Drone in the resource zone
The app is developed as a test task. You can check video at https://drive.google.com/drive/u/1/folders/13AMYYCXf6CodILZd58rZOpf8mg-rW6gn.
The task itself: https://buildin.ai/mafia/share/72254fa3-dd92-4f0a-9f12-657bc13c7de8?code=D6WZ69

## Arcitecture overview
The game is built in a classic DI-Unity-agnostic-ish manner. Scripts are divided into Logic, Logic.Interfaces, UI, Data and Data.Intefaces.
Some features are located at dedicated subfolders. All project files are located at _Project folder.
The game starts from GameBootstrap. Most of dependencies and services are plain C#-based.
The code is located in an .asmdef to ensure faster build and compile time.

## Used instruments:
- Extenject
- UniTask
- Odin Inspector
- DraasGames.Core

## Finished
- Drones spawn system
- Resources spawn sytem
- Basic factions system
- Resource collection and adding it to faction resources

## What could be done better
- UnitFactory should be pure ID-based;
- Views exist in game right now, which is not much fine;
- Divide view and presenter;
- DroneBrain into pure state machine. Fine for prototype;
- DroneBehaviour. That's it. Saved some time at least.