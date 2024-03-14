# 2D-Game-Template
 A template with a pause menu, rebindable controls, audio mixing, UI menus, and two simpleplayer controllers

## Features
 - Rebindable Controls (Controller and Keyboard support with Unity's new Input System)
 - Pause Menu (Controller Rebinding, Accessibility menu, Exit)
 - Fullscreen Toggle
 - Volume Sliders (Divided into Master, Music, and SFX mixer groups)
 - Screenshake function + Screenshake intensity slider
 - Main Menu (Play, settings, continue, exit)
 - Primitive Progress saving system
 - Primitive Game Over scene
 - Basic player controller (sidescroller AND top down)
 - Basic animator controller for player (sidescroller AND top down)
 - Basic fade-to-black screen transitions

## Documentation 
 - Most of it is straightforward - the rebinding UI system is just based on sample code that comes with the new Unity Input System
 - Also this uses the URP because it seemed useful.
 - All code's commented thoroughly for your convenience.
### Game Controller Prefab
 - Controls the pause state and pause menu
 - Handles screenshake
 - Also handles rebinding and holds onto the PlayerInput and UserInput scripts
### UserInput
 - Takes the PlayerInput stuff and converts them into easier-to-read bools and Vector2s
 - The PlayerController scripts will read 'em from here
### SideScroller PlayerController
 - Capsule Collider and slippery physics to not get stuck on walls
 - Walking and Jumping
 - AreaChecker helper script - useful for stuff like floor detection
 - Knockback on Hit
 - Invincibility on Hit
### TopDown PlayerController
 - Movement in all directions
 - Renders in front of and behind stuff properly

##Credits
 - Icons by Open Game Art https://opengameart.org/content/free-keyboard-and-controllers-prompts-pack
 - All other art, code, and sounds by me - ThermiteFe8
 - Otherwise, go ham.
   
