using Foxtale.Engine.Components;
using Foxtale.Engine.Entities;
using Foxtale.Systems;
using Microsoft.Xna.Framework;

namespace Foxtale.Components;

public class ChunkData : IComponent
{
    private float[,] _data;

    public IEntity Entity { get; set; }

    public const int Width = 32;
    public const int Height = 32;

    public float this[int x, int y]
    {
        get => _data[x, y];
        set => _data[x, y] = value;
    }

    public ChunkData()
    {
        _data = new float[Width, Height];
        ChunkDataSystem.AddComponent(this);
    }

    public void Initialize() { }
    public void Update(GameTime gameTime) { }
}
