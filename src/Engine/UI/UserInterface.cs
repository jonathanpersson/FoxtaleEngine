using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MonoGame.Extended.BitmapFonts;

namespace MgGame.Engine.UI;

public static class UserInterface
{
    /// <summary>
    /// Font used to render the UI
    /// </summary>
    public static BitmapFont Font { get; private set; }

    public static void Initialize()
    {

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
        throw new NotImplementedException("BitmapFonts are not supported at the moment.");
    }

    public static void UnloadContent()
    {

    }

    public static void Update()
    {

    }

    public static void Draw(SpriteBatch sb)
    {
        sb.DrawString(Font, "Hello, world!", Vector2.Zero, Color.White);
    }
}
