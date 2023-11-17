using Microsoft.Xna.Framework;

namespace Foxtale.Components.UI;

public interface IStyle
{
    public Color ForegroundColor { get; set; }
    public Color BackgroundColor { get; set; }
    public Vector4 Margin { get; set; }
}
