# Y-Zero-Pontus-Munkhammar
KarioMart - FG Assignment, 2023-10-11

Why Y-Zero? To continue the "Nintendo-RacingGame-Joke" and because of the movement long the Y-Axis.

My approach towards the game:
*   I wanted it to be in 3D, because of the fact that I haven't been working in 3D earlier.
This was a great opportunity to get more comfortable in the same workspace in Unity as Sebastian was showcasing all the lectures in.
*   The ideas of walls moving and include ramps to perform jumps to take shortcuts was another factor of why 3D was appealing, some things that I pretty soon would find out where going to accumulate complications in physics behaviors above my experience of handeling.
*   With inspiration from my childhood of games such as Ignition and Micro Machines, this was the kind of games that Influenced my take on the game.
This was also why I starved for the movement in the game: two buttons for going back and forth in a straight line, as well as two buttons to rotate/steer the vehicle.
*   Like in F-zero, I embrace the fact that the powerups and slow downs are part the course's structures that you interact with by the skills of your driving.
This was going to be a challenge for me. As I knew forehand that many things, both in code and in Unity, I would have to learn just to be able to accomplish the assignments specifications.
Therefore, my approach and workflow would come to revolve around simplicity & compromises, something that I'm not used to having to do. In practice this was frustrating as well as encouraging, cause of the fact that I had to prioritize the important core mechanics to get things working at all to keep it simple and playable!
...
Easier said than done when new ideas start flying and learning new stuff opens possibilities to evolve into other things.


To begin with, I made a list over the things that I knew I had to include, even though I didn't know how to.
The List Looked something like this, with the indented dots including obstacles for me:

The foundation of a course.	
Set up the camera correctly -> fixed topdown or isometric

  *   Input System:
  o	  I can use the input manager, and address all the actions from there, and it’ll make for a decent input manager for a prototype
  o	  However, I COULD learn how to address these via code, auto generate the new input system file, create a “Input Reader” and get my inputs from there to my game manager. -> takes some more time to learn.
  *   I’ll use the PlayerInput  component for this, Because…
  *   
  *   Movement: 
RigidBody component. - This I have some understandings of how it works, not in a 3D environment, but I'm familiar with why to stick it to Objects.
  *	  A Vector3 for position and rotation(if used to change the movement)
  *	  If Multiplayer, an own value to checkpoint count, lap count (and time?)
  •	  Car Movement and what the “Car-script” will store:
  •	  SO Controllers will store:
  o	  Max, min or constant values such as:

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
  •	  Saving system: "To big of a dive to address to this project for now."

  UI:
  •	UI -> Scriptable Objects -> create a SO with data as well as a UI reader that communicates with the Input System as well. 
  •	"For this I’ll try to use a SO to access the mouse function while in the PauseMenu, just to tryout how the different functions of the InputSystem works."
      This was what I intended to do. Here I got help from my classmate
  o	Mainmenu(select players 1-2, Start Game),
  o	PauseMenu(Resume, Restart), 
  o	Game Score/EndMenu(Display score, Restart Game)


Instructions:
In unity:

Package Manager:
  Additional Packages used:
    * Input System, 1.6.3
    * TextMeshPro, 3.0.6

Scene to Load to play the game:
  Assets -> Scenes -> CourtOne
    Play the Scene From here, and you'll be given which keys to use
    AND! With some recognizion of race games, you'll manage to drive around the course, finish four laps and get to the next scene.



