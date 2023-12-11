using Foxtale.Components;
using Foxtale.Components.Tiles;
using Microsoft.Xna.Framework;

namespace Foxtale.Entities.Tiles;

public class Chunk : Entity2D
{
    public int Width { get; }
    public int Height { get; }
    public ChunkData Data { get; }
    public Sprite Sprite { get; set; }

    public Chunk(float x, float y, int width, int height)
    {
        Width = width;
        Height = height;
        Transform.Position = new Vector2(x, y);
        Sprite = new Sprite();
        Data = new ChunkData(this);
    }
}