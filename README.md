# Unity & Arduino Conveyor Control Simulation

[![Unity Version](https://img.shields.io/badge/Unity-2021.3%2B-blue.svg)](https://unity.com/)
[![Arduino](https://img.shields.io/badge/Platform-Arduino-00979D.svg)](https://www.arduino.cc/)
[![Language](https://img.shields.io/badge/Language-C%23-green.svg)]()

This repository contains a 3D simulation project for controlling a conveyor system using **Unity** for visualization and an **Arduino** as the logic controller (the brain). This project demonstrates how hardware (Arduino) can communicate with software (Unity) in *real-time* via serial communication.

![conveyor-demo](https://i.imgur.com/your-gif-url.gif)
*(Suggestion: Replace the URL above with a link to a GIF or screenshot of your project demo to make it more engaging.)*

---

## 📜 Project Description

The main goal of this project is to create a digital prototype (a *digital twin*) of an automated conveyor system. This simulation allows for testing control logic and system interactions without needing the complete physical hardware.

The Arduino is responsible for running the control code (e.g., when to turn the conveyor motor on or off), while Unity reads data from the Arduino to accurately visualize the conveyor's status in a 3D environment.

## ✨ Key Features

-   **Real-time 3D Visualization:** The conveyor's status (moving or stopped) is visualized directly in Unity.
-   **Serial Communication:** Two-way communication between Unity (C#) and Arduino (C++) over a serial port (COM).
-   **Physical Logic Control:** The Arduino script contains the basic logic to control components like a motor or sensors.
-   **Modular Structure:** The code is separated between control logic (Arduino) and visualization logic (Unity), making it easy to extend.

---

## 🛠️ Technologies Used

-   **Game Engine:** [Unity](https://unity.com/) (version 2021.3 LTS or newer is recommended)
-   **Programming Language:** C# (for scripting in Unity)
-   **Microcontroller:** [Arduino](https://www.arduino.cc/) (e.g., Arduino Uno, Nano)
-   **Controller Language:** C/C++ (for the Arduino sketch)
-   **IDE:** Visual Studio (for Unity), Arduino IDE

---

## ⚙️ How It Works

The system architecture is quite straightforward:

1.  **Arduino (Controller):**
    -   An Arduino sketch (`.ino`) is uploaded to the Arduino board.
    -   This script sends status data (e.g., the string `"ON"` or `"OFF"`) through the USB port to the computer.
    -   The Arduino can also be configured to receive commands from Unity if needed.

2.  **Unity (Simulator):**
    -   A C# script in Unity (e.g., `SerialController.cs`) is responsible for opening a connection to the serial port used by the Arduino.
    -   This script continuously reads the incoming data from the Arduino.
    -   Based on the received data (e.g., the string `"ON"`), Unity triggers the animation or movement of the conveyor object in the scene.

```mermaid
graph TD
    A[Arduino] -- Sends status data ("ON"/"OFF") via USB --> B(Computer Serial Port);
    B -- Read by C# script --> C[Unity Application];
    C -- Animates object --> D(3D Conveyor Simulation);
```

---

## 🚀 Setup and Usage Guide

To run this simulation on your computer, follow these steps:

### **1. Prerequisites (Hardware & Software)**
-   An Arduino board (Uno, Nano, or similar)
-   A USB cable for the Arduino
-   [Arduino IDE](https://www.arduino.cc/en/software)
-   [Unity Hub](https://unity.com/download) and a Unity Editor (version 2021.3 LTS or newer)

### **2. Arduino Setup**
1.  Connect your Arduino board to your computer via USB.
2.  Open the `.ino` sketch file from this repository using the Arduino IDE.
3.  From the `Tools` menu, select the correct **Board** and **Port**.
4.  Click the **Upload** button to flash the sketch to your Arduino board.
5.  Open the **Serial Monitor** in the Arduino IDE to ensure the Arduino is sending data correctly. Take note of the Port name (e.g., `COM3` or `/dev/ttyACM0`).

### **3. Unity Setup**
1.  Clone or download this repository:
    ```bash
    git clone [https://github.com/MiraeNK/Unity-Arduino-Conveyor-Control-Simulation.git](https://github.com/MiraeNK/Unity-Arduino-Conveyor-Control-Simulation.git)
    ```
2.  Open the project using **Unity Hub**.
3.  Open the main project scene (usually located in the `Assets/Scenes` folder).
4.  Find the object in the scene that has the serial communication script (e.g., a `GameController` or `SerialManager` object).
5.  In that script's component in the **Inspector**, change the **Port Name** to match the port used by your Arduino (e.g., `COM3`).
6.  Click the **Play** button in the Unity Editor to start the simulation.

Now, the conveyor object in Unity should move or stop according to the data sent by the Arduino.

---

## 📝 License

This project is licensed under the [MIT License](LICENSE). You are free to use, modify, and distribute this code.
