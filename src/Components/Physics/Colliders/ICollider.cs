using Foxtale.Core.Geometry;
using Foxtale.Entities;
using Foxtale.Systems;
using Microsoft.Xna.Framework;

namespace Foxtale.Components.Physics.Colliders;

public interface ICollider : IComponent
{
    public Mesh2D Mesh { get; }
    public Transform2D Transform { get; }
    
    /// <summary>
    /// Check if intersecting another collider
    /// </summary>
    /// <param name="collider">Collider to test intersection against</param>
    /// <returns>True iff intersecting collider</returns>
    public bool Intersects(ICollider collider);
}
