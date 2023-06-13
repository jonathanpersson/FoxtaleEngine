using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MonoGame.Extended.BitmapFonts;
using MgGame.Engine.Components.UI;
using MgGame.Engine.Entities.UI;
using System.Runtime.CompilerServices;
using MgGame.Engine.Entities.UI.Controls;

namespace MgGame.Engine.Systems.UI;

public class UserInterfaceSystem : BaseSystem<UIComponent>
{
    /// <summary>
    /// Font used to render the UI
    /// </summary>
    public static BitmapFont Font { get; private set; }

    public static GraphicsDeviceManager Graphics { get; private set; }

    private static Container testContainer;

    public static void Initialize(GraphicsDeviceManager graphics)
    {
        Graphics = graphics;
        testContainer = new Container(new Label(300, 300, "Hello, world!"));
        testContainer.AddComponent(new Style());
    }

    /// <summary>
    /// Load UI content using a MonoGame.Extended BitmapFont as font
    /// </summary>
    /// <param name="font">MonoGame.Extended bitmap font</param>
    public static void LoadContent(BitmapFont font)
    {
        Font = font;
    }
    
    /// <summary>
    /// Load UI content using a standard XNA/MonoGame SpriteFont
    /// </summary>
    /// <param name="font">XNA/MonoGame SpriteFont</param>
    public static void LoadContent(SpriteFont font)
    {
        throw new NotImplementedException("SpriteFonts are not supported at the moment.");
    }

    public static void UnloadContent()
    {

    }

    public static void Draw(SpriteBatch sb)
    {

    }
}
