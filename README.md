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

### Add Foxtale Engine as a dependency
Use your chosen IDE to add the Foxtale Engine (not Demo) project as a dependency of your own project.

### Restore dependencies
You do not need to manually add MonoGame, Nopipeline, or any other of Foxtale Engine's dependencies. In your
project or solution root simply run `dotnet restore`, followed by `dotnet tool restore`.

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

## Asset management
Foxtale has moved away from using the regular MonoGame Content Pipeline, as it is unreliable at best
when developing across platforms. You can still use the MonoGame Pipeline in your project using Foxtale,
if you wish to do so. But it is recommended that  assets are loaded using the `AssetManager` in `Foxtale.Core.Assets`.

### Setup
The asset manager reads bundle info from an XML-config file. In order to read this file, and build content for
Foxtale, you need to copy your asset directory to the output directory. To do this automatically when
building add the following `ItemGroup` to your project's `.csproj` file.

```Xml
    <ItemGroup>
      <Content Include="<ASSET DIRECTORY>">
        <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
      </Content>
    </ItemGroup>
```

Exchange `<ASSET DIRECTORY>` with the root directory for your assets.

### Asset bundles
The Foxtale asset manager uses content bundles to bundle related assets together. This reduces file reads, in exchange
for some memory and CPU-time.
