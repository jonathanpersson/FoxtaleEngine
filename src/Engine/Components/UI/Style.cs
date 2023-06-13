using MgGame.Engine.Components;
using MgGame.Engine.Entities;
using MgGame.Engine.Systems;
using MgGame.Engine.Systems.UI;
using Microsoft.Xna.Framework;

namespace MgGame.Engine.Components.UI;

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
}
