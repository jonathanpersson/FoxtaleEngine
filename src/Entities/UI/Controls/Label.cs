using Foxtale.Components;
using Foxtale.Components.UI;
using Foxtale.Systems.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.BitmapFonts;

namespace Foxtale.Entities.UI.Controls;

public class Label : UIEntity
{
    public Text Text { get; }
    public Sprite Sprite { get; }
    
    public Label(int x, int y, string text)
    {
        Text = new Text(text);
        Sprite = new Sprite();
        AddComponent(Text);
        AddComponent(Sprite);
        Transform.Position = new Vector2(x, y);
        Render();
    }

    /// <summary>
    /// Render label text to sprite
    /// </summary>
    public void Render()
    {
        Vector2 texSize = UserInterfaceSystem.Font.MeasureString(Text.Content);
        Transform.Size = texSize;
        SpriteBatch sb = new(UserInterfaceSystem.Graphics.GraphicsDevice);
        RenderTarget2D result = new(UserInterfaceSystem.Graphics.GraphicsDevice,
            (int)texSize.X, (int)texSize.Y);
        UserInterfaceSystem.Graphics.GraphicsDevice.SetRenderTarget(result);
        UserInterfaceSystem.Graphics.GraphicsDevice.Clear(Color.Transparent);
        
        sb.Begin();
        sb.DrawString(UserInterfaceSystem.Font, Text.Content, Vector2.Zero, Color.White);
        sb.End();
        
        UserInterfaceSystem.Graphics.GraphicsDevice.SetRenderTarget(null);
        Sprite.Texture = result;
    }
}
