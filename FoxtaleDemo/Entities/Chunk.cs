using Foxtale.Entities;
using FoxtaleDemo.Components;

namespace FoxtaleDemo.Entities;

public class Chunk : Entity2D
{
    public static int Width => ChunkData.Width;
    public static int Height => ChunkData.Height;

    public Chunk() {
        AddComponent(new ChunkData());
    }
}
