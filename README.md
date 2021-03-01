# The-D5V-2-Massacre - A ScreamFM Jam Entry


## How To Play The Game

### Download Externally
-Go to https://mzatlin.itch.io/the-d5v-2-massacre <br />
-Find and click the "download" button <br />
-Extract the folder and run the .exe file <br />

### Download From Project
-Fork/download the code <br />
-Open any scene .unity file (make sure you have Unity version 2020.1.16f1 or higher installed) <br />
-In the project, go to "File"->"Build Settings" <br />
-Select the "Build" button and choose where in your computer you want to save the build folder <br />
-Run the .exe file in the newly created build folder <br />


##Screenshots
![alt text](https://github.com/Mzatlin/The-D5V-2-Massacre/blob/main/GameScreenshots/1.png)


## Features 
  -Vertical and Horizontal Movement <br />
    -The Player can walk horizontally as well as climb up/down a ladder to different floors <br />
  
  -Sprint Bar <br />
    -The Player can run and climb at a faster rate when holding the Shift Key, which depletes a UI sprint bar <br />
    -When the sprint bar is completely depleted, the player can no longer move at a faster rate and must wait 2 seconds before the bar replenishes again <br />
    -If the Player stops sprinting before the sprint bar fully is depleted, it will slowly replenish until it reaches the maximum sprint amount or if the player sprints again <br />
   
   -Interaction <br />
    -If the Player is near an interactable object, text will appear above the player's head signifying what will happen if they interact with the object <br />
    -If the Player interacts with the object by pressing E, a certain event will occur depending on the object: <br />
      -(collecting an item, triggering a minigame, starting a dialogue, or finishing the game) <br />
      
   -Enemy AI <br />
    -The Player will be hunted by a single AI entity for most of the game <br />
    -If the Player touches this enemy, they will lose the game <br />
    -The Enemy has 4 different states: <br />
      -Patrol: The enemy will A* path to specific waypoints listed to them. When reached, the enemy will continue to the next point on loop <br />
      -Chase: The enemy will path to the player at a faster speed <br />
      -Investigate: The enemy will path to a specified point at a faster speed. When reached, it will wait for 3-5 seconds before reverting to Patrol State <br />
      -ScriptedStop: The enemy will path to a specified point and will wait indefinitely until a certain event is triggered.  <br />
   
   -Hide <br />
    -The Player can hide in certain storage lockers, making them undetectable by the enemy AI <br />
    -If the Player hides while a chasing AI is pursuing them, the AI will go into an investigation state where they visit where they last saw the player before hiding <br />
    -If 3-5 seconds pass and the Player has not left the hiding spot, the AI will revert to the patrolling state and leave to their next patrol point <br />
   
   -Radio Minigame <br />
    -If the Player interacts with a radio that hasn't been completed, a UI panel appears and the Player is locked from movement <br />
    -The Player can only leave this minigame if they exit the mini-game themselves, finishing the mini-game, or getting killed by the AI enemy <br />
    -Two Sine-Wave patterns are generated at the top of the screen. One's frequency is set at random, while the other's frequency always starts in the middle <br />
    -The Player moves the dial, which either increases or decreases the bottom frequency <br />
    -If the pattern is close to matching the top pattern, the Sine-Wave will change to have higher peaks and valleys  <br />
    -If the bottom pattern is matching the top pattern frequency, the peaks and valleys will increase even higher <br />
    -If the Player validates this match, they will finish the minigame with the radio marked as complete <br />
    -When the radio is marked as complete, the enemy AI will stop what it's currently doing and investigate the completed radio unless it's currently chasing the Player <br />
    
   -Dialogue <br />
    -If the Player meets certain criteria (entering a specific zone or interacting with a certain object) a dialogue box will appear, locking the player until completion <br />
    -Text will type out one key at a time from the top left-hand side of the box until the full line is typed out. <br />
    -If the Player presses the Space Bar, all of the text in the box will be instantly typed out without delay. <br />
    -If the Player presses the "continue" UI button or presses the Space bar again, the dialogue box will close out, allowing the player to be controlled again <br />
    
   -Finishing the Game <br />
    -If the Player reaches a certain radio, and has completed all 5 minigames, a completion event will fire off <br />
    -After 5 seconds, the player will be taken to a completion screen, where they can either replay the game, or exit the application <br />
    
    
