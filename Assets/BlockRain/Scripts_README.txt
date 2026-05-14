Scripts Overview
================

Core/GameManager.cs
- Handles score, game over state, restart, and UI references.

Player/PlayerController.cs
- Handles left and right movement.
- Clamps player inside camera view.
- Detects obstacle trigger collision.

Obstacles/Obstacle.cs
- Moves obstacle downward.
- Destroys obstacle when it leaves the screen.

Obstacles/ObstacleSpawner.cs
- Spawns obstacles randomly across the top of the screen.
- Increases difficulty over time.
