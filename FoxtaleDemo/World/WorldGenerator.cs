using FoxtaleDemo.Entities;
using SimplexNoise;

namespace FoxtaleDemo.World;

public static class WorldGenerator
{

    public static World Generate()
    {
        SimplexNoise.Noise.Seed = GenerateSeed();
        int width = World.Width * Chunk.Width;
        int height = World.Height * Chunk.Height;
        float[,] result = new float[width, height];
        float[,] layer1 = Noise.Calc2D(width, height, 0.1f);
        float[,] layer2 = Noise.Calc2D(width, height, 0.5f);
        float[,] layer3 = Noise.Calc2D(width, height, 1f);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                result[x, y] = (layer1[x, y] + layer2[x, y] + layer3[x, y]) / 3;
            }
        }

        return new World(result);
    }

    private static int GenerateSeed() {
        Random random = new Random();
        return random.Next(int.MinValue, int.MaxValue);
    }
}
