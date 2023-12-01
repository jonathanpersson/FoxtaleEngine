using Foxtale.Components;
using Foxtale.Components.Tiles;

namespace Foxtale.Entities.Tiles;

public class Chunk : Entity2D
{
    public int Width { get; }
    public int Height { get; }
    public ChunkData Data { get; }
    public Sprite Sprite { get; set; }

    public Chunk(int width, int height)
    {
        Width = width;
        Height = height;
        Sprite = new Sprite();
        Data = new ChunkData(this);
    }
}