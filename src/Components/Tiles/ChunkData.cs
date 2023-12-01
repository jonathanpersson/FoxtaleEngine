using Foxtale.Core.Collections;
using Foxtale.Entities;
using Foxtale.Entities.Tiles;
using Microsoft.Xna.Framework.Graphics;

namespace Foxtale.Components.Tiles;

public class ChunkData : IComponent
{
    protected Chunk Chunk;
    public DataMatrix<Tile> Tiles { get; set; }
    public bool RefreshOnActivate { get; set; }
    public bool Active { get; protected set; }
    public IEntity Entity { get; set; }

    public ChunkData(Chunk chunk, bool refreshOnActivate = true)
    {
        Chunk = chunk;
        Tiles = new DataMatrix<Tile>(Chunk.Width, Chunk.Height);
        RefreshOnActivate = refreshOnActivate;
        Active = false;
    }

    public void Activate()
    {
        Active = true;
        if (RefreshOnActivate || Chunk.Sprite.TextureData == null) Refresh();
    }

    public void Deactivate()
    {
        Active = false;
    }

    public void Refresh()
    {
        
    }

    public void Destroy()
    {
        
    }
}