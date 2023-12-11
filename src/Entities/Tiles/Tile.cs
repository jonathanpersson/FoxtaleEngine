using System;
using Foxtale.Components.Physics.Colliders;
using Foxtale.Systems;

namespace Foxtale.Entities.Tiles;

public class Tile : Entity2D
{
    public bool HasCollision { get; set; }
    public ICollider? Collider { get; set; }
    public (int X, int Y) TilesetPosition { get; set; }
    public Map Tilemap { get; set; }

    public Tile()
    {
        
    }
    
    public Tile((int X, int Y) tilesetPos, bool hasCollision, ICollider? collider = null)
    {
        TilesetPosition = tilesetPos;
        HasCollision = hasCollision;

        if (!HasCollision) return;
        Collider = collider ?? new Box2DCollider(Transform);
        ColliderSystem.AddComponent(Collider);
    }
}
