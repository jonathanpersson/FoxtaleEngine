using System;
using MgGame.Engine.Exceptions;
using MgGame.Entities;
using MgGame.Components;

namespace MgGame.World;

public class World
{
    private Chunk[,] _chunks;

        /// <summary>
    /// World width in chunks
    /// </summary>
    public const int Width = 16;

    /// <summary>
    /// World height in chunks
    /// </summary>
    public const int Height = 16;

    public World(float[,] worldData) {
        _chunks = new Chunk[Width, Height];

        for (int x = 0; x < worldData.GetLength(0); x++)
        {
            for (int y = 0; y < worldData.GetLength(1); y++)
            {
                SetTileGlobal(x, y, worldData[x, y]);
            }
        }
    }

    private void SetTileGlobal(int globalX, int globalY, float data)
    {
        int x = (int)Math.Floor((double)globalX / Chunk.Width);
        int y = (int)Math.Floor((double)globalY / Chunk.Height);
        int chunkX = globalX - x * Chunk.Width;
        int chunkY = globalY - y * Chunk.Height;
        
        if (_chunks[x, y] == null) _chunks[x, y] = new Chunk();

        // Possibly throws a MissingComponentException if ChunkData doesn't exist. This is intentional.
        ChunkData chunkData = _chunks[x, y].GetComponent<ChunkData>();
        chunkData[chunkX, chunkY] = data;
    }
}
