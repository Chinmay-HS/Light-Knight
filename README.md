# Light-Knight

## Overview
Welcome to **Light Knight**, an exciting 2D platformer that brings immersive gameplay mechanics and smooth animations. This game features dynamic character movement, jumping mechanics, and attack animations, all controlled through intuitive key inputs.

## Game Features
- **2D Character Movement:** Move left and right with fluid animations.
- **Jumping Mechanics:** Press `Space` to jump when on the ground.
- **Attack System:** Perform basic and combo attacks using the mouse buttons.
- **Smooth Animation Transitions:** Running, jumping, and attacking seamlessly integrate through Unity’s Animator.
- **Automated Build System:** Streamlined game builds for Windows and macOS via Unity’s BuildPipeline.

## Screenshots
![Screenshot 1](Assets/For%20README/LK1.png)

![Screenshot 2](Assets/For%20README/LK2.png)

## Technical Details
### Player Controller
The `Player` script handles movement, jumping, and attack animations:
- **Movement:** Uses `Input.GetAxis("Horizontal")` to detect player movement.
- **Jumping:** The player jumps when `Space` is pressed, using `Rigidbody2D.AddForce()`.
- **Flipping Direction:** The character flips when moving in the opposite direction.
- **Animation:** The animator handles running, jumping, and attacking states.

### Automated Build System
The `BuildScript` automates game builds for multiple platforms:
- **Windows Build:** Generates an executable (`YourGame.exe`).
- **MacOS Build:** Creates a Mac app (`YourGame.app`).
- **Automated Scene Selection:** Fetches all scenes from `EditorBuildSettings.scenes`.
- **Menu Integration:** Provides a Unity Editor menu for easy builds (`Build/Windows` and `Build/macOS`).

## Installation & Running
1. Clone the repository:
   ```sh
   git clone https://github.com/yourusername/YourGame.git
   ```
2. Open in Unity (Recommended Version: `2022.3.55f1`).
3. Press `Play` in Unity Editor or build the game via `Build/Windows` or `Build/macOS` menu options.

![Screenshot 3](Assets/For%20README/LK3.png)
![Screenshot 4](Assets/For%20README/LK4.png)

## Controls
| Action         | Key/Button |
|---------------|-----------|
| Move Left     | A / Left Arrow |
| Move Right    | D / Right Arrow |
| Jump          | Spacebar |
| Attack        | Left Mouse Click |
| Combo Attack  | Right Mouse Click |

## Contributors
- **Chinmay HS** - Developer

## License
This project is licensed under the MIT License.

