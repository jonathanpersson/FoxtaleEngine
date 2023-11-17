using Foxtale.Entities;
using Foxtale.Systems;
using Microsoft.Xna.Framework;

namespace Foxtale.Components.Physics.Colliders;

public interface ICollider : IComponent
{
    /// <summary>
    /// If false, collider can be viewed as being "hollow", intersection
    /// is only calculated on the sides of the collider.
    /// If true, collider is essentially "solid", and intersection is calculated
    /// on any point of the collider.
    /// </summary>
    public bool Convex { get; set; }

    /// <summary>
    /// Check if intersecting another collider
    /// </summary>
    /// <param name="collider">Collider to test intersection against</param>
    /// <returns>True iff intersecting (see Convex) collider</returns>
    public bool Intersects(ICollider collider);
}
