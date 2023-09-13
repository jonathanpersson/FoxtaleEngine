using Foxtale.Entities;
using Foxtale.Systems;
using Microsoft.Xna.Framework;

namespace Foxtale.Components.Physics;

public class Collider : IComponent
{
    public IEntity Entity { get; set; }

    public Collider()
    {
        ColliderSystem.AddComponent(this);
    }

    public void Destroy()
    {
        throw new System.NotImplementedException();
    }
}
