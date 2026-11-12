========================================================================
PROJECT README - THIRD-PERSON NAVIGATION & PUZZLE APPLICATION
========================================================================

1. OVERVIEW
------------------------------------------------------------------------
This application is a 3D third-person point-and-click game set inside a
multi-level arena. The player explores the ground floor and elevated
walkways using ramps, collects colour-coded keys, and unlocks matching
sliding doors while tracking their progress on screen.


2. HOW TO CONTROL THE APPLICATION
------------------------------------------------------------------------
- Move Character: Left-click anywhere on the ground floor, ramps, or
  upper walkways. A visual marker will appear at your clicked target
  and disappear once the character arrives.
- Rotate Camera: Hold Right-Click and drag the mouse (or use the A / D
  and Left / Right arrow keys) to orbit the camera around the player.
- Zoom Camera: Use the Mouse Scroll Wheel to zoom closer or further
  away from the character.
- Pick Up Keys: Walk directly over a coloured key to pick it up.
- Open Doors: Walk up to a door that matches the colour of your held
  key and press the 'C' key to slide it open.
- Adjust Speed: Click and drag the "Move Speed" slider in the top-left
  corner of the screen to make the character walk slower or faster.
- **Once up the ramp, go down the ramp at the side to "RESET" and drop back to ground level.**


3. FEATURES IMPLEMENTED
------------------------------------------------------------------------
- Multi-Level 3D Environment:
  An enclosed arena featuring a main ground floor, two inclined ramps,
  an elevated walkway loop, and three separate rooms behind sliding
  doors.

- Point-and-Click Pathfinding:
  Clicking any walkable surface automatically calculates the shortest
  path for the character, including climbing up and down ramps between
  the ground floor and upper walkways.

- Third-Person Camera:
  Follows the character smoothly and automatically adjusts its distance
  when near walls or under walkways so the view of the player is not
  blocked.

- Coloured Keys and Sliding Doors (Red, Blue, and Green):
  * One-Key Limit: The player can only carry one key at a time. Walking
    over another key while already holding one will leave it on the
    ground.
  * Colour Matching & Unlocking: A door will only open when the player
    is holding the same colour key, standing near the door, and
    pressing the 'C' key.
  * Single-Use Keys: Once a door is unlocked, the key is consumed and
    removed from the player's inventory.
  * Automatic Closing: Doors smoothly slide shut automatically after
    the player walks away from them.

- User Interface (HUD):
  * Displays which key the player is currently holding (or "None").
  * Displays the total number of doors opened since the game started.
  * Provides an interactive slider to control character movement speed
    in real time.


4. ISSUES ENCOUNTERED & HOW THEY WERE RESOLVED
------------------------------------------------------------------------
- Character Not Moving on Click:
  Initially, clicking the floor registered the target location, but the
  character stayed in place due to a conflict with an older movement
  component. Removing the conflicting component resolved the issue.

- Clicking Near Doors & Climbing Ramps:
  Clicking directly on the invisible doorway trigger zones initially
  blocked ground clicks, and the character stopped near the top of the
  ramps. Updating click detection to pass through trigger zones and
  smoothing the ramp-to-walkway connection allowed seamless movement
  across all levels.

- Camera Obstruction & UI Slider Interaction:
  Walls and overhead walkways occasionally blocked the camera view, and
  text labels overlapped the speed slider. Adding automatic obstacle
  detection to the camera and adjusting the UI text boundaries fixed
  both issues so the slider drags cleanly without moving the character.


5. QUICK TESTING GUIDE
------------------------------------------------------------------------
1. Left-click on the upper walkway to watch the character climb the
   ramp automatically.
2. Walk into the Red key, then try walking into the Blue key to verify
   that only one key can be held at a time.
3. Approach the Blue or Green door and press 'C' to verify it stays
   locked without the matching key.
4. Approach the Red door and press 'C' to see it slide open, reset
   "Held Key" back to "None", and increase "Doors Opened" to 1.
5. Walk away from the open door to watch it slide closed automatically.
6. Drag the speed slider in the top-left corner to test movement speed
   changes.
========================================================================