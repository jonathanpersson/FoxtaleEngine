# Foxtale Engine
Foxtale is an ECS (Entity-Component-System) game engine focused on performance, 
and extensibility. Currently only 2D is supported, but 3D-support can be added manually.

Foxtale is currently in a very early stage of development.

## Initial setup
The process for setting up a development environment differs slightly depending on which operating system and
architecture you are building for.

### .NET
To build for any platform you first need to install the latest LTS version of `.NET 6.0`, you can either install
it from Microsoft's website, or from your platform's package manager.

#### Note for ARM-users (Apple Silicon)
If you're running on Apple Silicon, you will need both the AMD64 (x64) version of
the .NET SDK, as well as ARM64. This is because as it currently stands MonoGame's content pipeline
does not run on ARM-processors. It is recommended to create an alias for the x64 installation of
.NET in your `~/.zshrc` file. For example: `alias dotnet64="/usr/local/share/dotnet/x64/dotnet"`.

### Add Foxtale Engine as a dependency
Use your chosen IDE to add the Foxtale Engine (not Demo) project as a dependency of your own project.

### Restore dependencies
You do not need to manually add MonoGame, Nopipeline, or any other of Foxtale Engine's dependencies. In your
project or solution root simply run `dotnet restore`, followed by `dotnet tool restore`.

#### Note for ARM-users (Apple Silicon)
If you're running Apple Silicon, make sure you use the x64 installation of .NET to run these commands.

### Bootstrapping
With Foxtale added as a dependency, and set up to build properly, you can now start developing!
In your project's `program.cs`-file add the following lines to boot Foxtale:

```C#
using Foxtale.Core;

using var game = new GameInstance();
game.Run();
```

When you've created your first scene (see demo-project for example) simply pass it into the `game.Run()`-call
like so:

```C#
game.Run(new YourSceneHere());
```

#### macOS DllNotFoundException for libfreeimage
If you're running macOS you're likely to run into errors when building because the MonoGame Pipeline cannot
locate the libfreeimage library. To resolve this simply install it using Homebrew `brew install freeimage`.
**If you're on Apple Silicon make sure you install it using an ARM64-version of Homebrew!** And link the
dylib to one of the locations dotnet is expecting it to be in (you can see these in the error-messages).

### Build, run, and develop!
You can now build and run your game. Get to developing!

#### Note for ARM-users (Apple Silicon)
Only the content pipeline needs to be ran as x64, so after building your assets using the x64 .NET installation,
you can build and run your game for ARM64.

### Nopipeline setup
You must set a correct reference to MonoGame.Extended.Content.Pipeline in Content/Content.npl. 
This is usually in ~/.nuget/packages/monogame.extended.content.pipeline/{VERSION}/tools/MonoGame.Extended.Content.Pipeline.dll
