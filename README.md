# Y-Zero-Pontus-Munkhammar
KarioMart - FG Assignment, 2023-10-11

Why Y-Zero? To continue the "Nintendo-RacingGame-Joke" and because of the movement long the Y-Axis.

My approach towards the game:
*   I wanted it to be in 3D, because of the fact that I haven't been working in 3D earlier.
Creates an opportunity to get more comfortable in the same workspace in Unity as Sebastian was showcasing all the lectures in.
*   The ideas of walls moving and include ramps to perform jumps to take shortcuts was another factor of why 3D was appealing, I pretty soon would found out the complications in physics behaviors was above my experience of handeling.
*   With inspiration from my childhood of games such as Ignition and Micro Machines, this was the kind of games that Influenced my take on the game.
This was also why I starved for the moving back and forth in a straight line, as well as two buttons rotate/steer the vehicle.
*   Like in F-zero, I embrace the fact that the powerups and slow downs are part the course's structures that you interact with by the skills of your driving.


To begin with, I made a list over the things that I knew I had to include, even though I didn't know how to, with the indented dots including newthings for me.

The List:

The foundation of a course/track.	

Set up the camera accordingly -> fixed topdown or isometric.

  *   Input System:
  *	  I can use the input manager, and address all the actions from there, and it’ll make for a decent input manager for a prototype.
  *	  However, I COULD try to learn how to address these via code & Scriptabl Objects, auto generate the new input system file, create a “Input Reader” and get my inputs from there to my game manager. -> takes some more time to learn.
  
  *   Movement:
    
RigidBody component. - This I have some understandings of how it works, not in a 3D environment, but I'm familiar with why to stick it to Objects.
  *	  A Vector3 for position and rotation(if used to change the movement)
  *	  If Multiplayer, each own value to checkpoint count, lap count and time - If possible

Events -> colliders, triggers, tags
Collisions
Action functions onCollision Enter and Exit:
Grass, 
  *   Boost, 
  *   Reversed, 
Walls,
  *   Other Cars,
  *	  Checkpoints & finishline -> register Laps
 
  *   SceneManagement:
  *   SceneManager -> initialstate, gamestate, pausestate 
  •	  Saving system to store placement of every court? "To big of a dive to address to this project for now."

  *   UI:
  •  	UI -> Scriptable Objects -> create a SO with data as well as a UI reader that communicates with the Input System as well. 
  o  	Mainmenu(select players 1-2, Start Game),
  o  	PauseMenu(Resume, Restart), 
  o	  Game Score/EndMenu(Display score, Restart Game)


Start Point:
I made a fundament, the track with a certain amount of walls & set the camera. After that, i started working on the car and got fimilar with a movement that was to became sort of a "baby" that i really didn't want to kill, because of the ressemblance to the previous mentioned games. This constraind my evoulution in getting mor familiar with differet aspects of Vector Movement which was entirely new to me, so getting stuff working as I wanted was pleassuring, though I understod that this would constrain my knowledge in the subject. More about this in my Review.

The triggers and collisions, I also got working pretty quickly and it opend my mind to get functionallity to the powerups and what I wanted them to do.
Slow you down, Speed you up, Reverse your steering, Collide in a natural way with walls And a More impactable "Bump" in other Cars.

Obstacles:
Then it was time for the Player Input. This is where the scope of time got somewhat lost. My initial thought where to make a scriptable object(never done that before) in which I'd assign the player input.

//Note(26/9): After Sebastians lesson I get a little better grasp on how to handle this and I’ll try to Implement a working player input to the movement that I’m working on. Goal: To get this working at the end of the week.

After reevaluation my experience and ability to adapt new functionality, I decided to satisfy with using the Input System Maping and adress the movement(With influence of the "Simple Example" in Unity) of my car to this way of getting the input(I keept my old movement script in the project to be able to compare and visualize the difference. (In Unity: Assets -> Scripts -> "PlayerMovement").

By now, I knew that there where alot of work left to be done and my aproach towards the architecture of the work was VERRY blurr. How should i manage my scenes, the states to save position, to instantiate the car(s), how do I get the UI to interact with the game befor, during and after playing? ETC!
This Leed to alot of confusion and I made dussins of managers in script, and got even more confused. I had to make one thing work at a time to not waste time in limbo, not even knowing how to even referance to another script.


After some establishment of what's needed and what's not, I came to the conclusion of sticking to four scripts. I am aware that many of the things in the scripts are breaking, for example the singularity princaple, but in my current state of knowledge and working with a deadline, to get closer towards the goal of the assignment this is how it turned out:

Scripts: (contains)

Car: Parameters that will influence the RigidBody of the car when your car detects colliders, such as:
     
     * Grass, Boost, Reversed, Checkpoints & FinishLine.
     * Collider/Trigger - detection.


OldMovement: Variables to manage the movement of the Car

      * Here is where the input action maping is read and attached to that; the functions of what will happen in response to those actions.
      * I did need this script to access the UIManager to call for the PauseMenu() UI.


ScenesManager: On Awake, I instantiate a instance of this class
      * I'm Loading the scene based on the build index.
      * The LoadNewGame() method also returns to scene one, CourtOne. 


UIManager: This basically itterates through the Menus as you click through them
        * Enables and disables canvases to access the right UI 


Instructions in Unity:

Unity Version: 2022.3.8f1

Package Manager:
  Additional Packages used:
    * Input System, 1.6.3
    * TextMeshPro, 3.0.6

Scene to Load, to play the game:
  Assets -> Scenes -> CourtOne
    Play the Scene From here, and you'll be given which keys to use
    AND! With some recognizion of race games and going cloakcwise, you'll manage to drive around the course, finish four laps and get to the next scene x3.

In Menu's: 
Use Mouse

Player One Keys:
W/S - Forward/Back
A/D - Turn Left/Right
Space - Drift
1 - Pause


Sources:



My review of my assignment:

Overall thoughts:

This was going to be a challenge for me. As I knew forehand that many things, both in code and in Unity, I would have to learn just to be able to accomplish the assignments specifications.
Therefore, my approach and workflow would come to revolve around simplicity & compromises, something that I'm not used to having to do. In practice this was frustrating as well as encouraging, cause of the fact that I had to prioritize the important core mechanics to get things working at all to keep it simple and playable!

To not be able to accumilate and implement stuff that, in lesson, seemd very relevant and of good use was for me the challange in this.
Am I satisfied with the result? No! Did I learn something during the process? Oh yes, however I thought that I'd be able to incorporate code and princaples in a much more broader and convinient way that I did.
This is ofcourse a work-in-progress, but the overwhelming times did make things hard to pull through. When in this state of my assignment I look back and rewatch some lectures, they make more sence than before. However I do wish that my entry level of understanding was running along the phase of the course to start with.


Good stuff, and things that I've learnt:

There is so much knowledge that's within my reach. The internet can't read my code and explain what I'M trying to achieve. It's much better to just ask a Tutor or Classmates to get help.
With some help from Mehmet, he managed to guide me and my UI to kind of work in the way that I wanted. And by the guidance of Magnus, we could address the Laps to the GameUi, which creates at least some kind of mission in the game.


Bad stuff:




 Things to improve:

 
