using System;
using Foxtale.Components;
using Foxtale.Components.Scripts;
using Foxtale.Components.UI;
using Foxtale.Systems.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.BitmapFonts;

namespace Foxtale.Entities.UI.Controls;

public class Button : UIEntity
{
    public Text Text { get;  }
    public AnimatedSprite Sprite { get; }
    public ButtonScript Script { get; }
    public Event OnClick;

    public Button(int x, int y, string text, EventHandler onClick)
    {
        OnClick = new Event(onClick);
        Text = new Text(text);
        Sprite = new AnimatedSprite();
        Script = new ButtonScript(this);
        AddComponent(OnClick);
        AddComponent(Text);
        AddComponent(Sprite);
        AddComponent(Script);
        Transform.Position = new Vector2(x, y);
        Render();
    }

    public void Render()
    {
        Vector2 buttonSize = new Vector2(36, 12) + (Vector2)UserInterfaceSystem.Font.MeasureString(Text.Content);
        SpriteBatch sb = new(UserInterfaceSystem.Graphics.GraphicsDevice);
        RenderTarget2D result = new(UserInterfaceSystem.Graphics.GraphicsDevice,
            (int)buttonSize.X * 3, (int)buttonSize.Y);
        UserInterfaceSystem.Graphics.GraphicsDevice.SetRenderTarget(result);
        UserInterfaceSystem.Graphics.GraphicsDevice.Clear(Color.Transparent);
        Rectangle button = new(0, 0, (int)buttonSize.X, (int)buttonSize.Y);
        Vector2 textLocation = new(18, 6);
        
        sb.Begin();
        sb.FillRectangle(button, Color.Gray);
        sb.DrawString(UserInterfaceSystem.Font, Text.Content, textLocation, Color.Black);
        textLocation.X += buttonSize.X;
        button.X += (int)buttonSize.X;
        sb.FillRectangle(button, Color.LightGray);
        sb.DrawRectangle(button, Color.White, 2);
        sb.DrawString(UserInterfaceSystem.Font, Text.Content, textLocation, Color.Black);
        textLocation.X += buttonSize.X;
        button.X += (int)buttonSize.X;
        sb.FillRectangle(button, Color.DarkRed);
        sb.DrawRectangle(button, Color.Red, 2);
        sb.DrawString(UserInterfaceSystem.Font, Text.Content, textLocation, Color.White);
        sb.End();
        
        UserInterfaceSystem.Graphics.GraphicsDevice.SetRenderTarget(null);

        Sprite.Texture = result;
        Sprite.SpriteSize = buttonSize;
        Sprite.Frames = 3;
        Sprite.SourceRectangle = new Rectangle(0, 0, (int)buttonSize.X, (int)buttonSize.Y);
        Transform.Size = buttonSize;
    }
}