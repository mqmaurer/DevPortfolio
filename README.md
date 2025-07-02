# DevPortfolio (Ongoing Project)

A personal mobile app for testing and experimenting with my own ideas.

## Description
DevPortfolio is a mobile application developed with Unity 2023.1.0f1. It focuses on augmented reality (AR), interactivity, and user-friendly design. The project serves as a platform to explore and develop new technologies and concepts, especially in the area of mobile AR using ARFoundation and Google ARCore for Android.

## Technologies
- Unity 6000.0.23f1
- AR Foundation
- Google ARCore (Android platform)
- C#

## Features
- Mobile AR applications with real-world environment tracking
- Interactive user interfaces

  

## Installation / Build Instructions

### Prerequisites
- Unity 6000.0.23f1 installed 
- Android SDK & NDK (can be installed via Unity Hub)
- ARCore supported Android device
- Google ARCore package installed via Unity Package Manager
- AR Foundation package installed via Unity Package Manager

### Steps
1. Clone or download this repository.
2. Open the project in Unity 6000.0.23f1
3. Make sure the Android platform is selected in **File > Build Settings**.
4. Configure Player Settings for Android:
   - Minimum API Level: 24 or higher (required by ARCore)
   - Set package name and permissions as needed.
5. Connect your ARCore-compatible Android device or use an emulator.
6. Build and run the app via **Build Settings**.

## Usage
- Launch the app on your Android device.
- Follow on-screen instructions to enable camera and AR permissions.
- Interact with AR objects in your environment.
- Explore experimental features as they are developed.

## Project Structure
```
DevPortfolio/
├── Assets/                   # Unity Assets (Scripts, Scenes, Prefabs, Materials, etc.)
│   ├── Scripts/              # C# scripts
│   ├── Scenes/               # Unity scenes
│   ├── Models/               # 3D models
│   └── Textures/             # Textures and materials
├── ProjectSettings/          # Unity project settings
├── Packages/                 # Unity packages and dependencies
├── .gitignore                # Git ignore rules
├── README.md                 # This readme
```

## Contributing
This is a personal project and currently not open for external contributions. Feel free to reach out if you want to collaborate or have suggestions.

## Known Issues
- Some AR features may not work on unsupported devices.
- Performance may vary depending on device hardware.
- Experimental features might be unstable or incomplete.

## Roadmap
- Add multiplayer AR interactions
- Improve UI/UX for easier navigation
- Integrate hand and eye tracking when supported
- Expand AR content and storytelling elements

## Credits
Developed by Monique Maurer.  
Uses Unity AR Foundation and Google ARCore.

## License
This project is licensed under the MIT License.

