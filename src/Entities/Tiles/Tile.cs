using System;
using Foxtale.Components.Physics.Colliders;
using Foxtale.Systems;

namespace Foxtale.Entities.Tiles;

public class Tile : Entity2D
{
    public bool HasCollision { get; set; }
    public ICollider? Collider { get; set; }
    public Guid TileDefId { get; }

    public Tile(Guid tileDefId)
    {
        TileDefId = tileDefId;
    }

    public Tile(Guid tileDefId, bool hasCollision, ICollider? collider = null)
    {
        TileDefId = tileDefId;
        HasCollision = hasCollision;

        if (!HasCollision) return;
        Collider = collider ?? new Box2DCollider(Transform);
        ColliderSystem.AddComponent(Collider);
    }
}
