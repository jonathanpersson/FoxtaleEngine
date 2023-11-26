using Foxtale.Components;
using Microsoft.Xna.Framework;

namespace Foxtale.Entities.UI;

public class UIEntity : Entity, IUIEntity
{
    public DockTransform Dock { get; set; }
    public ScreenSpaceTransform Transform { get; set; }

    protected UIEntity()
    {
        Transform = new ScreenSpaceTransform();
        Dock = new DockTransform(Transform, DockStyle.TopLeft);
        AddComponent(Dock);
        AddComponent(Transform);
    }
}
