using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MgGame.Engine.Components.UI;

public interface IStyle
{
    public Color ForegroundColor { get; set; }
    public Color BackgroundColor { get; set; }
    public Vector4 Margin { get; set; }
}
