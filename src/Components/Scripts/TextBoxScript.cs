using Foxtale.Entities.UI.Controls;
using Microsoft.Xna.Framework;

namespace Foxtale.Components.Scripts;

public class TextBoxScript : Script
{
    public TextBox Text { get; }
    
    public TextBoxScript(TextBox textBox)
    {
        Text = textBox;
    }

    public override void Update(GameTime gameTime)
    {
        
    }
}