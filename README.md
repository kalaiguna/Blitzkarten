# Deutsch Blitz Karten ⚡🃏

A .NET MAUI flashcard app for learning German vocabulary with smooth card flip animations.

## Features

- Interactive flashcard system with flip animation
- German vocabulary with articles (der/die/das) and English translations
- Responsive design for phones and tablets
- Dark/light theme support
- Simple navigation between cards
- Progress tracking

## Prerequisites

- [.NET 7.0+](https://dotnet.microsoft.com/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) with MAUI workload
- OR [Visual Studio Code](https://code.visualstudio.com/) with C# extensions

![App Screenshot](https://github.com/user-attachments/assets/02b7e6d3-abf1-42ae-afbc-74da9c428f91)

## Getting Started

1. Clone the repository:
   ```bash
   git clone https://github.com/kalaiguna/Blitzkarten.git

2. Open the solution in Visual Studio:

    Open Blitzkarten.sln

3. Restore NuGet packages:

    Right-click solution → "Restore NuGet Packages"

4. Run the app:

    - Select target platform (Android/iOS)
    - Choose emulator or physical device
    - Click "Start Debugging" (F5)

## Project Structure

```
Blitzkarten/
├── Controls/              # Custom UI controls
│   └── BlitzKarteView.xaml # Flashcard view
├── Models/                # Data models
│   └── BlitzKarte.cs      # Flashcard model
├── Services/              # Business logic
│   └── BlitzKarteService.cs # Data loading
├── ViewModels/            # ViewModels
│   └── MainViewModel.cs   # Main logic
├── Views/                 # Pages
│   └── MainPage.xaml      # Main view
└── Resources/             # Assets and styles
```
## Data Format
Flashcards are stored in JSON format:
```
{
  "Artikel": "der",
  "Noun": "Name",
  "Plural": "Namen",
  "Englisch": "name"
}
```
## Customizing Content
1. Edit DeuA1.json in the Resources/Raw folder

2. Set file properties to:
    - Build Action: MauiAsset
    - Copy to Output Directory: Copy if newer

## Building for Release
   Android
   
  - Right-click project → "Publish" → "Create Android Package"
  - Follow the signing process

   iOS
   
  - Requires macOS with Xcode
  - Right-click project → "Archive"

## Advanced Configuration

### Android Emulator Setup
1. Open Android Device Manager
2. Create a Pixel 5 device with API 33
3. Enable "Hardware accelerated execution"

### iOS Simulator
1. Requires Xcode 14+
2. Select "iPhone 14 Pro" simulator

   
## Contributing
Contributions welcome! 

Please:
  1. Fork the repository    
  2. Create a feature branch
  3. Submit a pull request

## License
MIT License 

Made with ❤️ and .NET MAUI

   ![.NET](https://img.shields.io/badge/.NET-7.0-blue)
   ![MAUI](https://img.shields.io/badge/MAUI-7.0-purple)
   ![Platforms](https://img.shields.io/badge/platforms-Android%20|%20iOS-lightgrey)
