# BrickBreaker

We made a BrickBreaker game with 4 levels. Each level has player pad, ball, boundries and bricks. the different in each level is:  
1. 3 rows of 1 hit bricks.  
2. 2 rows of 1 hit bricks and 1 row of 2 hit bricks.  
3. 1 row of 1 hit bricks, 1 row of 2 hit bricks of 1 hit bricks and 1 row of 3 hit bricks.  
4. 2 rows of 2 hit bricks, 1 row of 3 hit bricks and smaller paddle.

For game objects we have 3 walls (left, right and top) with box collider to set boundries for the ball and the player.
ground which is similar to the walls but it is a trigger and tagged as ground. When the ball hit the ground, the trigger resets the ball
position to the paddle, set its velocity to zero and decrease 1 life point.  The [ball](/Assets/Scripts/BallScript.cs) has circle collider and a rigidbody. We added Phisics material to make it bouncy and set gravity to zero.  
The player's [paddle](/Assets/Scripts/PadMovement.cs) has rigid body and box collider and gravity set to zero.  
Of course there are bricks. They are prefabs.  Last but not least we have [game manager](/Assets/Scripts/GameManager.cs) to manage the UI and the game progress.  

At the start of each level and every time the ball hits the ground, the ball's position is set to be as the player's position plus an offset. 
Left mouse click will add force to the ball. colliding a brick will take 1 hitpoint to the brick. if it hitpoint equals to zero, it will be destroyed and the number of bricks will decrease, and number of points the brick worth will be added. We designed it so its easy to edit a brick and there is no need to enter the code for that. If the ball hits the ground and the players lives become zero, Game over panel will pop up for some pre defined delay time and restart the level.  
The player's movement was the trickiest part. If you move the mouse too fast, it skips the collision with the walls and goes out of boundries. Changing the collision detection to continous and freezing the Y position and Z rotation fixed it.  
The paddle with a box collider did not work well with the gameplay we wanted. The physics was real, but not playable. To overcome this, we calculated the vector from the paddle (center of the game object) to the collision and set this vector, after normalizing it and multiplying it by the ball's speed, it was exactly as we wanted so when u hit the right part of the paddle, the ball goes right and the same happens for left side.
