using System;
using Foxtale.Core;
using Foxtale.Entities.UI.Controls;
using Microsoft.Xna.Framework;

namespace Foxtale.Components.Scripts;

public class ButtonScript : Script
{
    private bool _clicked;
    public Button Button { get; set; }
    
    public ButtonScript(Button button)
    {
        Button = button;
        _clicked = false;
    }
    
    public override void Update(GameTime gameTime)
    {
        if (IsHovered())
        {
            Button.Sprite.Frame = 1;

            if (Input.LeftMouseDown())
            {
                Button.Sprite.Frame = 2;
                _clicked = true;
            }
            else if (_clicked) Click();
            else _clicked = false;
        } else if (Button.Sprite.Frame != 0) Button.Sprite.Frame = 0;
    }

    private void Click()
    {
        _clicked = false;
        Button.OnClick.Call();
    }

    private bool IsHovered()
    {
        return Button.Transform.Contains(Input.GetMousePosition());
    }
}