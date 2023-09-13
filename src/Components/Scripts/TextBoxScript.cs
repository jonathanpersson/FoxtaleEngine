using Foxtale.Entities.UI.Controls;
using Microsoft.Xna.Framework;

namespace Foxtale.Components.Scripts;

public class TextBoxScript : Script
{
    private bool _focused;
    public TextBox Text { get; }
    
    public TextBoxScript(TextBox textBox)
    {
        Text = textBox;
        _focused = false;
    }

    public override void Update(GameTime gameTime)
    {
        
    }

    public void Render()
    {
        
    }
}