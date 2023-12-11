using Microsoft.Xna.Framework.Graphics;
using Foxtale.Entities;
using Foxtale.Core.Collections;
using Foxtale.Entities.Tiles;
using System.Collections.Generic;
using System;

namespace Foxtale.Components.Tiles;

public class MapData : IComponent
{
    private long _width;
    private long _height;
    private DataMatrix<Chunk> _chunks;
    public IEntity Entity { get; set; }
    public int HorizontalChunks => _chunks.Width;
    public int VerticalChunks => _chunks.Height;
    public long ChunkWidth => _width / HorizontalChunks;
    public long ChunkHeight => _height / VerticalChunks;

    public MapData()
    {

    }

    public void Destroy()
    {

    }
}
