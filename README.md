# Y-Zero-Pontus-Munkhammar
KarioMart - FG Assignment, 2023-10-11

Why Y-Zero? To continue the "Nintendo-RacingGame-Joke" and because of the movement long the Y-Axis.

My approach towards the game:
*   I wanted it to be in 3D, because I haven't been working in 3D earlier.
Creates an opportunity to get more comfortable in the same workspace in Unity as all the lectures.
*   The ideas of walls moving and include ramps to perform jumps to take shortcuts was another factor of why 3D was appealing. I pretty soon would find out the complications in physics behaviours was above my experience of handling.
*   With inspiration from my childhood of games such as Ignition and Micro Machines, this was the kind of games that Influenced my take on the game.
This was also why I starved for the moving back and forth in a straight line, as well as two buttons rotate/steer the vehicle.
*   Like in F-zero, I embrace the fact that the powerups and slow downs are part the course's structures that you interact with by the skills of your driving.
*   Multiplayer was the thought from the beginning. But the instantiation of a player two was compromised away due to lack of time and understanding.


I've reviewed my assignment below. Read if interested. Made it for me to acknowledge what went wrong, what to improve etc. It doesn't contain all my thoughts, but some general.
Also I don't like to polish a turd, so this is where I criticize my assignment.

Instructions in Unity:

Unity Version: 2022.3.8f1

Package Manager:
  Additional Packages used:
    * Input System, 1.6.3
    * TextMeshPro, 3.0.6

Scene to Load, to play the game.
  Assets -> Scenes -> CourtOne
    Play the Scene from here, and you'll be given which keys to use
    AND! With some recognition of race games and going clockwise, you'll manage to drive around the course, finish four laps and get to the next scene x3.
* UI -> every parent should be disabled at the start in every scene.

In Menu's: 
Use Mouse.

Player One Keys:
W/S - Forward/Back.
A/D - Turn Left/Right.
Space - Drift.
1 - Pause.

Sources.

Sebastian's lectures:
     * https://drive.google.com/drive/folders/1GIJ_NlDb0qeycuae4NYkukvQoJ4yciKO

Unity Input System Example:
Included in the project. Samples -> Input System -> Simple Demo -> SimpleController_UsingPlayerInput

Unity Manual:
     * https://docs.unity3d.com/ScriptReference/Transform.html

Influential videos to get the movement and input working:
     * https://www.youtube.com/watch?v=m5WsmlEOFiA
     * https://www.youtube.com/watch?v=ZHOWqF-b51k
     * https://www.youtube.com/watch?v=BSybcKPQCnc

Dani Krossing's YouTube tutorial:
     * https://www.youtube.com/watch?v=jrPTpD2eAMw
     * https://www.youtube.com/watch?v=Z3tO8FPCM_w&t=198s

UI:
Mehmets & Magnus Guidance <3

-----WorkProgress & Review-----

To begin with, I made a list over the things that I knew I had to include, even though I didn't know how to, with the indented dots including new things for me.

The List:

The foundation of a course/track.	

Set up the camera accordingly -> fixed top down or isometric.

  *   Input System:
  *	  I can use the input manager, and address all the actions from there, and it’ll make for a decent input manager for a prototype.
  *	  I COULD try to learn how to address these via code & Scriptable Objects, the auto generated code from the input system and create a “Input Reader” to get my inputs from there to my game manager. -> takes some more time to learn.
  
  *   Movement:
Rigid Body component. - This I have some understandings of how it works, not in a 3D environment, but I'm familiar with why to stick it to Objects.
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
  *	  Checkpoints & finish line -> register Laps
 
  *   SceneManagement:
  *   SceneManager -> initialstate, gamestate, pausestate 
  *	  Saving system to store placement of every court? "To big of a dive to address to this project for now."

  *  	UI -> Scriptable Objects -> create a SO with data as well as a UI reader that communicates with the Input System as well. 
  *  	Mainmenu(select players 1-2, Start Game),
  *  	PauseMenu(Resume, Restart), 
  *	  Game Score/EndMenu(Display score, Restart Game)

Work Progress:

Start:
I made a fundament, the track with a certain amount of walls & set the camera. 
After that, I started working on the car managed to make a movement that was to became sort of a "baby" that I really didn't want to kill, because of the resemblance to the previous mentioned games. This constrained my evolution in getting mor familiar with different aspects of Vector Movement which was entirely new to me, so getting stuff working as I wanted was pleasuring, though I understood that this would constrain my knowledge in the subject. More about this in my Review.

The triggers and collisions, I also got working quickly and it opened my mind to get functionality to the powerups and what I wanted them to do.
Slow you down, Speed you up, Reverse your steering, Collide in a natural way with walls And a More impactable "Bump" in other Cars.

Obstacles:
Then it was time for the Player Input. This is where the scope of time got somewhat lost. My initial thought where to make a scriptable object (never done that before) in which I'd assign the player input.

//Note(26/9): After Sebastians lesson I get a little better grasp on how to handle this and I’ll try to Implement a working player input to the movement that I’m working on. Goal: To get this working at the end of the week.

After re-evaluateng my experience and ability to adapt new functionality, I decided to satisfy with using the Input System Maping and address the movement(With influence of the "Simple Example" in Unity) of my car to this way of getting the input(I kept my old movement script in the project to be able to compare and visualize the difference. (In Unity: Assets -> Scripts -> "PlayerMovement").

By now, I knew that there where a lot of work left to be done and my approach towards the architecture of the work was VERRY blur. How should I manage my scenes, the states to save position, to instantiate the car(s), how do I get the UI to interact with the game before, during and after playing? ETC!
This led to a lot of confusion, and I made a couple of managers in script, and got even more confused. I had to make one thing work at a time to not waste time in limbo, not even knowing how to even reference to another script.


After some establishment of what's needed, I concluded sticking to four scripts. 
I am aware that many of the things in the scripts are breaking, for example the singularity principle, but in my current state of knowledge and working with a deadline, to get closer towards the goal of the assignment this is how it turned out:

Scripts: (what it contains)

Car: Parameters that will influence the RigidBody of the car when your car detects colliders, such as:
     
      * Grass, Boost, Reversed, Checkpoints & FinishLine.
      * Collider/Trigger - detection.


OldMovement: Variables to manage the movement of the Car

      * Here is where the input action mapping is read and attached to that; the functions of what will happen in response to those actions.
      * I did need this script to access the UIManager to call for the PauseMenu() UI.


ScenesManager: On Awake, I instantiate a instance of this class

      * I'm Loading the scene based on the build index.
      * The LoadNewGame() method also returns to scene one, CourtOne. 


UIManager: This basically iterates through the Menus as you click through them

      * Enables and disables canvases to access the right UI 




My review of my assignment:(post mortem to self)

Overall thoughts:

This was going to be a challenge for me. As I knew forehand that many things, both in code and in Unity, I would have to learn just to be able to accomplish the assignments specifications.
Therefore, my approach and workflow would come to revolve around simplicity & compromises, something that I'm not used to having to do. In practice this was frustrating as well as encouraging, cause of the fact that I had to prioritize the important core mechanics to get things working at all to keep it simple and playable!

To not be able to accumulate and implement stuff that, in lesson, seemed very relevant and of good use was for me the challenge in this.
Am I satisfied with the result? No! Did I learn something during the process? Oh yes, however I thought that I'd be able to incorporate code and principles in a much more broader and convenient way that I did.
This is of course a work-in-progress, but the overwhelming times did make things hard to pull through. When in this state of my assignment I look back and rewatch some lectures, they make more sense than before. However, I do wish that my entry level of understanding was running along the phase of the course to start with.


Good stuff, and things that I've learnt:

There is so much knowledge that's within my reach. The internet can't read my code and explain what I'M trying to achieve. It's much better to just ask a Tutor or Classmates to get help.
With some help from Mehmet, he managed to guide me and my UI to kind of work in the way that I wanted. And by the guidance of Magnus, we could address the Laps to the GameUi, which creates at least some kind of mission in the game. He also introduced me to Time.timescale, which I used to pause the game.

Bad stuff:

I'm disappointed towards my ability to adapt my code towards generic structures. As of my understanding, this is not super easy to create, but the time that it takes to learn this was beyond my expectation.
I may be criticising my "beginners code" a bit to much as well, but when the enthusiasm is there to learn something, and you find out that you just don't understand right now... that's stressful.
Copy pasta in the scenes. Do make a game atleast that generic, so that you can instantiate the right stuff in the right time. This is crucial for the time to come!


Things to improve:

To unlock a way of thinking by introduce more functionality in unity. This was a great example where I lack knowledge and a wake up call over the great amount of things that is out there.
Move one step at a time. Review and rewind to get the understandings of how tings work properly.
Get more familiar with all the different terms used in programming and make yourself a map/library to keep track of the things that I "know", "can improve" and "don't know yet".
Try structuring even more! Make time to find out what you're going to need to learn, and how to, before entering a stage where you have no idea what to do. AND if you do, try to eevaluate how much time it'll take to learn the things that's needs to be done.
Get started on a library of these things.
 

"Note to self: In the future, I'd rather handle these kinds of text in Word and just assign the basic functions in the README"
//Pontus Munkhammar
