using Foxtale.Components;
using Microsoft.Xna.Framework;

namespace Foxtale.Entities.UI;

public class UIEntity : Entity2D, IUIEntity
{
    public DockTransform Dock { get; set; }

    protected UIEntity()
    {
        Transform.Scale = new Vector2(.5f, .5f);
        Dock = new DockTransform(Transform, DockStyle.TopLeft);
        AddComponent(Dock);
    }
}
