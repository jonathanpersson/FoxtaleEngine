using Foxtale.Entities;
using Foxtale.Systems.UI;
using Microsoft.Xna.Framework;

namespace Foxtale.Components.UI;

public class Style : IComponent, IStyle
{
    public Color ForegroundColor { get; set; }
    public Color BackgroundColor { get; set; }
    public Vector4 Margin { get; set; }
    public IEntity Entity { get; set; }

    public Style()
    {
        ForegroundColor = Color.White;
        BackgroundColor = Color.Transparent;
        Margin = Vector4.Zero;
        StyleSystem.AddComponent(this);
    }

    public void Initialize() { }
    public void Update(GameTime gameTime) { }

    public void Destroy()
    {
        StyleSystem.RemoveComponent(this);
    }
}
