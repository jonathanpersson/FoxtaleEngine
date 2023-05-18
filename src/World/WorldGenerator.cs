using SimplexNoise;
using MgGame.Engine.Entities;

namespace MgGame.World;

public static class WorldGenerator
{
    /// <summary>
    /// World width in chunks
    /// </summary>
    public const int WorldWidth = 8;

    /// <summary>
    /// World height in chunks
    /// </summary>
    public const int WorldHeight = 8;

    public static World Generate()
    {
        SimplexNoise.Noise.Seed = 123456;
        int width = WorldWidth * Chunk.ChunkWidth;
        int height = WorldHeight * Chunk.ChunkHeight;

        float[,] layer1 = SimplexNoise.Noise.Calc2D(width, height, 0.1f);
        return new World();
    }
}
