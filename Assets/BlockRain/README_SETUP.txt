Block Rain - Unity Setup Guide
==============================

This folder is ready to drag into your Unity project's Assets folder.

Recommended folder path after import:
Assets/BlockRain

Included folders:
- Scripts/Core
- Scripts/Player
- Scripts/Obstacles
- Art/Sprites
- Prefabs
- Scenes

Important:
This package includes scripts and simple placeholder sprite images.
Unity prefab and scene files are not included because they are easier and safer to create inside your Unity version.

Required Unity setup:
1. Create a new 2D scene.
2. Set Main Camera:
   - Projection: Orthographic
   - Size: 5
   - Position: 0, 0, -10
   - Background: dark gray

Player setup:
1. Create 2D Object > Sprite > Square.
2. Rename it to Player.
3. Position: 0, -3.8, 0.
4. Scale: 0.7, 0.7, 1.
5. Add BoxCollider2D.
6. Enable Is Trigger on BoxCollider2D.
7. Add Rigidbody2D.
8. Set Rigidbody2D Body Type to Kinematic.
9. Set Gravity Scale to 0.
10. Add PlayerController.cs.
11. Optional: assign Art/Sprites/player_square.png to the SpriteRenderer.

Obstacle prefab setup:
1. Create 2D Object > Sprite > Square.
2. Rename it to Obstacle.
3. Position: 0, 6, 0.
4. Scale: 0.8, 0.8, 1.
5. Add BoxCollider2D.
6. Enable Is Trigger on BoxCollider2D.
7. Add Rigidbody2D.
8. Set Rigidbody2D Body Type to Kinematic.
9. Set Gravity Scale to 0.
10. Add Obstacle.cs.
11. Create a tag named Obstacle.
12. Assign the Obstacle tag to this object.
13. Optional: assign Art/Sprites/obstacle_block.png to the SpriteRenderer.
14. Drag the Obstacle object into Assets/BlockRain/Prefabs.
15. Delete the Obstacle object from the scene after creating the prefab.

GameManager setup:
1. Create an empty GameObject.
2. Rename it to GameManager.
3. Add GameManager.cs.
4. Add ObstacleSpawner.cs.
5. Drag the Obstacle prefab into the Obstacle Prefab field on ObstacleSpawner.

UI setup:
1. Create UI > Canvas.
2. Create TextMeshPro text under the Canvas.
3. Rename it to ScoreText.
4. Set text to Score: 0.
5. Place it at the top center.
6. Create UI > Panel under the Canvas.
7. Rename it to GameOverPanel.
8. Add TextMeshPro text inside it saying GAME OVER.
9. Add a Button inside it saying Restart.
10. Disable GameOverPanel by default.
11. Assign ScoreText and GameOverPanel to the GameManager script.
12. On Restart button OnClick, drag GameManager and select GameManager.RestartGame().

Controls:
- A or Left Arrow: move left
- D or Right Arrow: move right

Input system note:
- The PlayerController supports both the old Input Manager and the New Input System.
- If your project uses the New Input System, it reads Keyboard.current.
- If your project uses the old Input Manager, it uses Input.GetAxisRaw("Horizontal").

Testing checklist:
- Player collider Is Trigger is enabled.
- Obstacle prefab collider Is Trigger is enabled.
- Obstacle prefab tag is Obstacle.
- Obstacle prefab is assigned to ObstacleSpawner.
- ScoreText is assigned to GameManager.
- GameOverPanel is assigned to GameManager.
- Restart button calls GameManager.RestartGame().

