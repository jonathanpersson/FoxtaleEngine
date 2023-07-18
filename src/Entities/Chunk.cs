using Foxtale.Components;
using Foxtale.Engine.Entities;

namespace Foxtale.Entities;

public class Chunk : Entity2D
{
    public static int Width => ChunkData.Width;
    public static int Height => ChunkData.Height;

    public Chunk() {
        AddComponent(new ChunkData());
    }
}
