using System;

namespace Foxtale.Entities.Tiles;

public class Tile : Entity2D
{
    public Guid TileDefId { get; }

    public Tile(Guid tileDefId)
    {
        TileDefId = tileDefId;
    }

    public Tile(Guid tileDefId, bool hasCollision)
    {
        TileDefId = tileDefId;
        
    }
}
