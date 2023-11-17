using Foxtale.Components;
using Foxtale.Entities;

namespace Foxtale.Components.Physics.Colliders;

public class Box2DCollider : ICollider
{
    public bool Convex { get; set; } = true;
    public IEntity Entity { get; set; }

    public bool Intersects(ICollider collider)
    {
        return false;
    }

    public void Destroy()
    {

    }
}
