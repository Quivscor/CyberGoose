# CyberGoose
Unity mobile game

# How to add more mini games
 - Duplicate (Ctrl + D) scene called "Mini Game Template". It contains Main Camera, GameManager, MiniGameManager and a Timer inside Canvas.
 - First you want to set the length of mini game and timeout condition. In Inspector, select MiniGameManager and fill out necessary fields. Timer Is Win Condition set on true results in victory screen, when timer runs out.
 - When creating game logic, refer to MiniGame Manager for victory or defeat logic, it will carry on to the next scene and will handle assigning points and lives.
 - If additional MiniGame logic is required, make a class inheriting from MiniGameManager class.

# Project FAQ (for collaborants)
 - Scenes In Build are required to be in a specific order!
Space at the beginning of the scene list is for any NON-GAME scene (main menu, settings, victory, etc.)
If you add such a scene, adjust a number of non-game scenes in the game manager class.
