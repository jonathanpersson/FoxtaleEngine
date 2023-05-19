using MgGame.Engine.Entities;
using MgGame.Components;

namespace MgGame.Entities;

public class Chunk : Entity
{
    public static int Width => ChunkData.Width;
    public static int Height => ChunkData.Height;

    public Chunk() {
        AddComponent(new ChunkData());
    }
}
