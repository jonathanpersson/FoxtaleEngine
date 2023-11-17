using System;
using Foxtale.Components.UI;
using Foxtale.Entities.UI;
using Foxtale.Entities.UI.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.BitmapFonts;

namespace Foxtale.Systems.UI;

public class UserInterfaceSystem : BaseSystem<UIComponent>
{
    /// <summary>
    /// Font used to render the UI
    /// </summary>
    public static BitmapFont Font { get; private set; }

    public static GraphicsDeviceManager Graphics { get; private set; }
    
    public static GameWindow Window { get; private set; }

    private static Container infoContainer;

    public static void Initialize(GraphicsDeviceManager graphics, GameWindow window)
    {
        Graphics = graphics;
        Window = window;
    }

    /// <summary>
    /// Load UI content using a MonoGame.Extended BitmapFont as font
    /// </summary>
    /// <param name="font">MonoGame.Extended bitmap font</param>
    public static void LoadContent(BitmapFont font)
    {
        Font = font;
        infoContainer = new Container(
            new Label(4, 4, $"Foxtale Engine Pre-Alpha"),
            new FrameCounter(4, 16)
        );
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
