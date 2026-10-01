# Classic Snake Game 🐍

A fully functional, classic Snake Game built with C# and Windows Forms using the GDI+ rendering engine. This project demonstrates core game loop implementation, collision detection, state management, and real-time graphics rendering.

## ✨ Features
*   **Custom Game Engine:** Built from scratch using a `Timer` for the game loop and GDI+ for drawing.
*   **Expanded Grid:** Operates on a 23x23 tile grid for an extended gameplay experience.
*   **Special Purple Food Mechanic:** 
    *   🔴 **Standard Red Food:** Grants +10 points and increases snake length by 1.
    *   🟣 **Special Purple Food:** Has a 20% spawn chance, grants +20 points, and increases snake length by 2.
*   **Robust Mechanics:** Includes precise self-collision detection, boundary wall-collision detection, and logic to prevent the classic 180-degree instant death bug.

## 🛠️ Technologies Used
*   **C#**
*   **.NET Framework 4.7.2**
*   **Windows Forms (WinForms)**
*   **GDI+** (Graphics Device Interface)

## 🎮 Controls
*   **Up Arrow:** Move Up
*   **Down Arrow:** Move Down
*   **Left Arrow:** Move Left
*   **Right Arrow:** Move Right
*   **Enter:** Restart Game (after Game Over screen)

## 🚀 How to Run
1. Clone the repository:
   ```bash
   git clone [https://github.com/radu-stefanescu/SnakeGame.git](https://github.com/radu-stefanescu/SnakeGame.git)
