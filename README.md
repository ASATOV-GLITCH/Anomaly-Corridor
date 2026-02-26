Anomaly Corridor
Experience a short, chilling psychological horror loop built with Unity 

👁️ Overview
Anomaly Corridor is a psychological horror game where the player is trapped in a seemingly endless corridor. The goal is to notice subtle changes in the environment to break the loop. This project demonstrates my ability to handle complex game logic, environmental storytelling, and player immersion.

🚀 Key Features
Procedural Loop System: A seamless transition between corridor segments.

Dynamic Anomalies: Randomly triggered events that challenge the player's perception.

Atmospheric Audio: Immersive sound design to enhance the horror experience.

Optimized Performance: Smooth gameplay even on lower-end hardware.

🛠️ Tech Stack
Engine: Unity

Language: C#

Tools: Freesound for sounds

🎮 How to Play
Observe: Walk through the corridor and memorize every detail.

Identify: If you notice an anomaly, turn back. If everything is normal, continue forward.

Survive: Reach the end of the loop to escape.

⚡ Performance & Optimization
During the initial testing phase on an RTX 4070, I encountered unexpected stuttering. After enabling the FPS counter, I discovered the game was running at over 5000 FPS, causing the GPU to work at maximum capacity unnecessarily.

To solve this and ensure a smooth experience for all players, I implemented the following optimizations:

Frame Rate Limiter: Created a frame.cs script to cap the frame rate at 60 FPS (or the monitor's native refresh rate) to prevent hardware overheating and resource waste.

Static Batching: All non-moving environmental objects were marked as Static in the Unity Inspector. This allows Unity to combine meshes and significantly reduce the number of Draw Calls, boosting overall performance.

Lightmapping: Optimized the scene by baking static lighting, which reduces real-time lighting calculations 

📞 Contact
If you have any questions or feedback regarding the project, feel free to reach out!

Telegram: @Underdog_O
