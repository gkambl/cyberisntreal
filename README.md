# cyberisntreal - Cybersecurity Education Game

A pixel-perfect 2D cybersecurity education game built with MonoGame. Play as a cybersecurity analyst in a bunker-like SOC, spotting differences between baseline and live logs to identify security threats.

## Game Features

- **Educational Content**: Learn about real security vulnerabilities (SQL Injection, XSS, Path Traversal, SSRF, Authentication Abuse)
- **Progressive Difficulty**: 10+ missions with increasing complexity
- **Threat Meter System**: DEFCON-style pressure system with random scare events
- **Pixel-Perfect Graphics**: Retro CRT aesthetic at 320×180 scaled to 1280×720
- **Real Security Logs**: Authentic-looking log entries with actual attack patterns

## How to Play

1. **Briefing Screen**: Review your mission objectives
2. **Operations Screen**: 
   - Compare BASELINE (left) vs LIVE (right) log panels
   - Use arrow keys to navigate through log entries
   - Press ENTER to mark anomalies when you spot differences
   - Press TAB to switch between left and right panels
3. **Debrief Screen**: Learn about the security vulnerabilities you found

## Controls

- **Arrow Keys/WASD**: Navigate through log entries
- **ENTER/SPACE**: Mark anomaly or proceed to next screen
- **TAB**: Switch between baseline and live log panels
- **ESC**: Exit game

## Security Concepts Covered

- **SQL Injection**: Malicious SQL code in input fields
- **Path Traversal**: Attempts to access files outside allowed directories  
- **Cross-Site Scripting (XSS)**: Malicious scripts in user input
- **Server-Side Request Forgery (SSRF)**: Requests to internal resources
- **Authentication Abuse**: Brute force and credential stuffing attacks

## Building and Running

### Prerequisites

- .NET 6.0 SDK or later
- MonoGame 3.8.1+

### Build Instructions

1. Clone or extract the project files
2. Open terminal/command prompt in the project directory
3. Restore dependencies:
   ```bash
   dotnet restore
   ```
4. Build the project:
   ```bash
   dotnet build
   ```
5. Run the game:
   ```bash
   dotnet run
   ```

### Alternative Build (Visual Studio)

1. Open `cyberisntreal.csproj` in Visual Studio 2022
2. Build Solution (Ctrl+Shift+B)
3. Run (F5 or Ctrl+F5)

## Game Architecture

```
/cyberisntreal
  /Content              # Fonts and assets
  /Screens              # Game screens (Briefing, Ops, Debrief)
  /UI                   # UI components (Cursor)
  /GameCore             # Game state, missions, threat system
  /Logs                 # Log generation and analysis
  Game1.cs              # Main game class
  Program.cs            # Entry point
```

## Educational Value

After each mission, players receive:
- Explanation of detected vulnerabilities
- Real-world impact of each threat type
- 3-point mitigation checklists
- References to security frameworks (OWASP, CWE)

## Technical Details

- **Resolution**: 320×180 virtual resolution scaled to 1280×720
- **Graphics**: Pixel-perfect rendering with nearest-neighbor sampling
- **Framework**: MonoGame 3.8.1 (cross-platform)
- **Performance**: Stable 60 FPS with minimal resource usage
- **Compatibility**: Windows, macOS, Linux

## Troubleshooting

**Game won't start**: Ensure .NET 6.0+ is installed
**Blurry graphics**: Check that the game is running in fullscreen or at exact 4x scale
**Content not loading**: Verify Content/Content.mgcb builds successfully

## License

MIT License. See [LICENSE](LICENSE).

## Contributing

This is an educational project demonstrating game development and cybersecurity concepts. Feel free to:
- Add new anomaly types
- Create additional missions  
- Improve the visual effects
- Enhance educational content

---

**"Cyber is not real... but the threats are."**