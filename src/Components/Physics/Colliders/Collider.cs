using Foxtale.Entities;
using Foxtale.Systems;
using Microsoft.Xna.Framework;

namespace Foxtale.Components.Physics.Colliders;

public interface ICollider : IComponent
{
    /// <summary>
    /// Check if intersecting another collider
    /// </summary>
    /// <param name="collider">Collider to test intersection against</param>
    /// <returns>True iff intersecting collider</returns>
    public bool Intersects(ICollider collider);
}
