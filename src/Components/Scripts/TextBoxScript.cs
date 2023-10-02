using System;
using Foxtale.Core;
using Foxtale.Entities.UI.Controls;
using Foxtale.Systems.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.BitmapFonts;

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
        if (IsHovered() && Input.LeftMouseDown())
        {
            Focused = true;
            _cursorLocation = Text.Length;
        }
        else if (Input.LeftMouseDown()) Focused = false;
        
        // render new background if focused state has changed
        if (wasFocused != Focused) RenderBackground();
    }

    private void HandleTextEntry(object sender, TextInputEventArgs e)
    {
        if (!Focused || Text.Length >= Text.MaxLength) return;

        switch (e.Key)
        {
            case Keys.Left:
                _cursorLocation = _cursorLocation <= 0
                    ? Text.Length
                    : _cursorLocation - 1;
                return;
            case Keys.Right:
                _cursorLocation = _cursorLocation >= Text.Length
                    ? 0
                    : _cursorLocation + 1;
                return;
            case Keys.Back:
                if (Text.Length <= 0) return;
                Text.Content.Content = Text.Text.Remove(_cursorLocation - 1, 1);
                --_cursorLocation;
                RenderText();
                return;
            case Keys.Enter:
                Focused = false;
                RenderBackground();
                return;
        }

        string preSplit = Text.Text[.._cursorLocation];
        string postSplit = Text.Text[_cursorLocation..];
        
        Text.Content.Content = $"{preSplit}{e.Character}{postSplit}";
        ++_cursorLocation;
        RenderText();
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
        sb.FillRectangle(box, Color.White);
        if (Focused) sb.DrawRectangle(box, Color.Red, 2);
        else sb.DrawRectangle(box, Color.LightGray);
        sb.End();
        
        UserInterfaceSystem.Graphics.GraphicsDevice.SetRenderTarget(null);

        if (Text.Textures.Count < 1) Text.Textures.Add(result);
        else Text.Textures[0] = result;
    }

    private void RenderText()
    {
        string text = GetRenderedText();
        SpriteBatch sb = new(UserInterfaceSystem.Graphics.GraphicsDevice);
        RenderTarget2D result = new(UserInterfaceSystem.Graphics.GraphicsDevice,
            (int)Text.Transform.Size.X, (int)Text.Transform.Size.Y);
        UserInterfaceSystem.Graphics.GraphicsDevice.SetRenderTarget(result);
        UserInterfaceSystem.Graphics.GraphicsDevice.Clear(Color.Transparent);
        Rectangle box = new(0, 0, (int)Text.Transform.Size.X, (int)Text.Transform.Size.Y);

        sb.Begin();
        sb.DrawString(UserInterfaceSystem.Font, text, new Vector2(2, 10), Color.Black);
        sb.End();
        
        UserInterfaceSystem.Graphics.GraphicsDevice.SetRenderTarget(null);

        if (Text.Textures.Count < 2) Text.Textures.Add(result);
        else Text.Textures[1] = result;
    }

    private string GetRenderedText()
    {
        return Text.Length <= Text.DisplayLength 
            ? Text.Text 
            : Text.Text[(Text.Length - Text.DisplayLength - 1)..];
    }

    public new void Destroy()
    {
        UserInterfaceSystem.Window.TextInput -= HandleTextEntry;
        base.Destroy();
    }
}