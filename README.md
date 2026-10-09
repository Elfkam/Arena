# Arena Survival

**Arena Survival** is a 2D roguelike mobile game developed in Unity as part of my bachelor's thesis.

The game challenges players to survive in an arena for five minutes while fighting waves of enemies using elemental spells. Players can improve their abilities during each run and earn coins to upgrade their character between runs, gradually preparing for more challenging difficulties.

## Gameplay

You play as a ghost trapped in an arena surrounded by hostile creatures. Your goal is simple: survive for five minutes.

* **Survive the arena** – Fight off waves of enemies that spawn around you.
* **Cast elemental spells** – Use lightning, wind, fire, and frost to defeat enemies and apply different effects.
* **Choose and upgrade spells** – Improve your spells as you progress through each run.
* **Earn coins** – Receive rewards after a run and invest them in permanent ability upgrades.
* **Take on greater challenges** – Strengthen your character to overcome higher difficulty levels.

## Enemies

The game features four enemy variants with different attributes and behaviours:

* **Undead Skeleton** – A basic enemy that pursues the player.
* **Undead Zombie** – A tougher enemy with increased health and damage.
* **Undead Vampire** – An enemy capable of charging toward the player's position.
* **Undead Black Knight** – A heavily armoured enemy with high health and a powerful charge attack.

## Technologies

* **Unity** – Game engine used to develop the 2D mobile game.
* **C#** – Programming language used to implement gameplay systems and game logic.
* **Unity 2D Physics** – Collision detection and interactions between game objects.
* **Unity Animator** – Character animations and state transitions.
* **Unity Asset Store** – Third-party assets and tools used during development.

## Technical Features

The project implements several core systems required for the game:

* Player movement using an on-screen virtual joystick.
* Enemy AI with movement, attack, and charging behaviours.
* Timed enemy spawning around the player.
* Elemental spell effects and enemy debuffs.
* Player health, experience, and damage handling.
* In-game user interface, menus, and game-over handling.
* Persistent progression through a save system.
* Android build and Google Play publishing workflow.

## Getting Started

### Prerequisites

* [Unity Hub](https://unity.com/download)
* A compatible Unity Editor version
* Android Build Support if you intend to build the game for Android

### Opening the Project

1. Clone the repository:

   ```bash
   git clone https://github.com/Elfkam/Arena.git
   ```

2. Open Unity Hub.

3. Add the cloned repository as an existing Unity project.

4. Open it with a compatible version of the Unity Editor.

5. Open the game's scene and press **Play** to run it in the editor.

For an Android build, select Android as the target platform in Unity's build settings and ensure the required Android development modules are installed.

## Academic Background

This project was developed as part of the bachelor's thesis *Development of a 2D Game Application for Mobile Devices* at the Czech University of Life Sciences Prague, Faculty of Economics and Management, in 2024.

The thesis covers the fundamentals of game development with Unity, the implementation of the game's main systems, and the process of testing and publishing a mobile application on Google Play.

## Author

**Jan Doležal**

GitHub: [@Elfkam](https://github.com/Elfkam)

---

*Created as a bachelor's thesis project in 2024.*
