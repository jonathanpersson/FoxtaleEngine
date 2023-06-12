using MgGame.Engine.Components;
using MgGame.Engine.Systems.UI;
using MgGame.Engine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.BitmapFonts;

namespace MgGame.Engine.Components.UI;

public class Text : UIComponent
{
    public string Content { get; set; }

    public Text(string content)
    {
        Content = content;
    }

    public override void Initialize()
    {
        if (!Entity.TryGetComponent(out Sprite spr))
        {
            Entity.AddComponent(new Sprite());
            Initialize();
            return;
        }

        // pre-render text as texture to save time later!
        Vector2 texSize = UserInterfaceSystem.Font.MeasureString(Content);
        SpriteBatch sb = new(UserInterfaceSystem.Graphics.GraphicsDevice);
        RenderTarget2D render = new(UserInterfaceSystem.Graphics.GraphicsDevice, (int)texSize.X, (int)texSize.Y);

        UserInterfaceSystem.Graphics.GraphicsDevice.SetRenderTarget(render);
        
        sb.Begin();
        sb.DrawString(UserInterfaceSystem.Font, Content, Vector2.Zero, Color.White);
        sb.End();

        UserInterfaceSystem.Graphics.GraphicsDevice.SetRenderTarget(null);
        spr.Texture = render;
    }
}
