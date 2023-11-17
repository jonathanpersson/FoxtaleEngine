using Foxtale.Components;
using Foxtale.Entities;

namespace Foxtale.Components.Physics.Colliders;

public class Box2DCollider : ICollider
{
    public IEntity Entity { get; set; }
    public void Destroy()
    {
        
    }
}
