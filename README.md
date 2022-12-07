# INFR3110U - Repo for Final Exam Practical Part
## Jeffrey Li - 100712344

## Q&A:
- 1. Object Pooling
  - The Object Pooling system can load the enemies when the game starts. So the enemies are preloaded which they are not loading during the gameplay, in order to save the performance. I am using an EnemySpawner to randomly activate certain amount of enemies on the two platforms. In my game "Duck Hunt", this system can be used to create any enemies in the scene.

- 2. Command
  - The command system has changed the sword as a command invoker. If the player attacks and does not hit anything, the command invoker would add one missing command to its list, and if the list count is greater than 2, the character controller would inverse the up and down aiming movement. This could be used as a punishment system in "Duck Hunt".

- 3. Score management system
  - The score management system is built by Singleton which every other systems can get and use. It has a method to add or remove score. It also has a win condition, which if the player kills certain amount of enemies (I've set 2), the player wins.
