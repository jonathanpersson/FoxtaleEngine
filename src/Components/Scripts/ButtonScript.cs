using Foxtale.Core;
using Foxtale.Entities.UI.Controls;
using Microsoft.Xna.Framework;

namespace Foxtale.Components.Scripts;

public class ButtonScript : Script
{
    public Button Button { get; set; }
    
    public ButtonScript(Button button)
    {
        Button = button;
    }
    
    public override void Update(GameTime gameTime)
    {
        if (IsHovered()) ; //todo: add hover
    }

    private bool IsHovered()
    {
        return Button.Transform.Contains(Input.GetMousePosition());
    }
}