using System;
using Foxtale.Core;
using Foxtale.Entities.UI.Controls;
using Foxtale.Systems.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace Foxtale.Components.Scripts;

public class TextBoxScript : Script
{
    private int _cursorLocation;
    public bool Focused { get; private set; }
    public TextBox Text { get; }
    
    public TextBoxScript(TextBox textBox)
    {
        _cursorLocation = 0;
        Text = textBox;
        Focused = false;
        UserInterfaceSystem.Window.TextInput += HandleTextEntry;
        RenderBackground();
        RenderText();
    }

    public override void Update(GameTime gameTime)
    {
        bool wasFocused = Focused;
        if (IsHovered() && Input.LeftMouseDown()) Focused = true;
        else if (Input.LeftMouseDown()) Focused = false;
        
        // render new background if focused state has changed
        if (wasFocused != Focused) RenderBackground();
    }

    private void HandleTextEntry(object sender, TextInputEventArgs e)
    {
        if (!Focused) return;
        
    }
    
    private bool IsHovered()
    {
        return Text.Transform.Projection.Contains(Input.GetMousePosition());
    }

    private void RenderBackground()
    {
        SpriteBatch sb = new(UserInterfaceSystem.Graphics.GraphicsDevice);
        RenderTarget2D result = new(UserInterfaceSystem.Graphics.GraphicsDevice,
            (int)Text.Transform.Size.X, (int)Text.Transform.Size.Y);
        UserInterfaceSystem.Graphics.GraphicsDevice.SetRenderTarget(result);
        UserInterfaceSystem.Graphics.GraphicsDevice.Clear(Color.Transparent);
        Rectangle box = new(0, 0, (int)Text.Transform.Size.X, (int)Text.Transform.Size.Y);

        sb.Begin();
        sb.FillRectangle(box, Color.LightGray);
        if (Focused) sb.DrawRectangle(box, Color.Red, 2);
        else sb.DrawRectangle(box, Color.White);
        sb.End();
        
        UserInterfaceSystem.Graphics.GraphicsDevice.SetRenderTarget(null);

        if (Text.Textures.Count < 1) Text.Textures.Add(result);
        else Text.Textures[0] = result;
    }

    private void RenderText()
    {
        //TODO: get slice of text to display in textbox depending on text cursor location
    }

    public new void Destroy()
    {
        UserInterfaceSystem.Window.TextInput -= HandleTextEntry;
        base.Destroy();
    }
}