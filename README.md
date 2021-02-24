# The-D5V-2-Massacre - A ScreamFM Jam Entry

## How To Play The Game

### Download Externally
-Go to https://mzatlin.itch.io/the-d5v-2-massacre 
-Find and click the "download" button
-Extract the folder and run the .exe file

### Download From Project
-Fork/download the code
-Open any scene .unity file (make sure you have Unity version 2020.1.16f1 or higher installed)
-In the project, go to "File"->"Build Settings"
-Select the "Build" button and choose where in your computer you want to save the build folder
-Run the .exe file in the newly created build folder

## Features 
  -Vertical and Horizontal Movement
    -The Player can walk horizontally as well as climb up/down a ladder to different floors
  
  -Sprint Bar 
    -The Player can run and climb at a faster rate when holding the Shift Key, which depletes a UI sprint bar
    -When the sprint bar is completely depleted, the player can no longer move at a faster rate and must wait 2 seconds before the bar replenishes again
    -If the Player stops sprinting before the sprint bar fully is depleted, it will slowly replenish until it reaches the maximum sprint amount or if the player sprints again
   
   -Interaction
    -If the Player is near an interactable object, text will appear above the player's head signifying what will happen if they interact with the object
    -If the Player interacts with the object by pressing E, a certain event will occur depending on the object: 
      -(collecting an item, triggering a minigame, starting a dialogue, or finishing the game)
      
   -Enemy AI
    -The Player will be hunted by a single AI entity for most of the game
    -If the Player touches this enemy, they will lose the game
    -The Enemy has 4 different states:
      -Patrol: The enemy will A* path to specific waypoints listed to them. When reached, the enemy will continue to the next point on loop
      -Chase: The enemy will path to the player at a faster speed
      -Investigate: The enemy will path to a specified point at a faster speed. When reached, it will wait for 3-5 seconds before reverting to Patrol State
      -ScriptedStop: The enemy will path to a specified point and will wait indefinitely until a certain event is triggered. 
   
   -Hide
    -The Player can hide in certain storage lockers, making them undetectable by the enemy AI
    -If the Player hides while a chasing AI is pursuing them, the AI will go into an investigation state where they visit where they last saw the player before hiding
    -If 3-5 seconds pass and the Player has not left the hiding spot, the AI will revert to the patrolling state and leave to their next patrol point
   
   -Radio Minigame
    -If the Player interacts with a radio that hasn't been completed, a UI panel appears and the Player is locked from movement
    -The Player can only leave this minigame if they exit the mini-game themselves, finishing the mini-game, or getting killed by the AI enemy
    -Two Sine-Wave patterns are generated at the top of the screen. One's frequency is set at random, while the other's frequency always starts in the middle
    -The Player moves the dial, which either increases or decreases the bottom frequency
    -If the pattern is close to matching the top pattern, the Sine-Wave will change to have higher peaks and valleys 
    -If the bottom pattern is matching the top pattern frequency, the peaks and valleys will increase even higher
    -If the Player validates this match, they will finish the minigame with the radio marked as complete
    -When the radio is marked as complete, the enemy AI will stop what it's currently doing and investigate the completed radio unless it's currently chasing the Player
    
   -Dialogue 
    -If the Player meets certain criteria (entering a specific zone or interacting with a certain object) a dialogue box will appear, locking the player until completion
    -Text will type out one key at a time from the top left-hand side of the box until the full line is typed out.
    -If the Player presses the Space Bar, all of the text in the box will be instantly typed out without delay.
    -If the Player presses the "continue" UI button or presses the Space bar again, the dialogue box will close out, allowing the player to be controlled again
    
   -Finishing the Game
    -If the Player reaches a certain radio, and has completed all 5 minigames, a completion event will fire off
    -After 5 seconds, the player will be taken to a completion screen, where they can either replay the game, or exit the application
    
    
