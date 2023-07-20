using Foxtale.Engine.Components;
using Foxtale.Engine.Systems.UI;
using Foxtale.Engine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.BitmapFonts;

namespace Foxtale.Engine.Components.UI;

public class Text : UIComponent
{
    public string Content { get; set; }

    public Text(string content)
    {
        Content = content;
    }
}
