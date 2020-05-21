# BrickBreaker

We made a BrickBreaker game with 4 levels. Each level has player pad, ball, boundries and bricks. the different in each level is:  
1. 3 rows of 1 hit bricks.  
2. 2 rows of 1 hit bricks and 1 row of 2 hit bricks.  
3. 1 row of 1 hit bricks, 1 row of 2 hit bricks of 1 hit bricks and 1 row of 3 hit bricks.  
4. 2 rows of 2 hit bricks, 1 row of 3 hit bricks and smaller paddle.

For game objects we have 3 walls (left, right and top) with box collider to set boundries for the ball and the player.
ground which is similar to the walls but it is a trigger and tagged as ground. When the ball hit the ground, the trigger resets the ball
position to the paddle, set its velocity to zero and decrease 1 life point.
