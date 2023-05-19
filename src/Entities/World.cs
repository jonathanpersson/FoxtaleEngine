using MgGame.Engine.Entities;
using MgGame.Engine.Components;

namespace MgGame.Entities;

public class World : Entity
{
    /// <summary>
    /// World width in chunks
    /// </summary>
    public const int Width = 16;

    /// <summary>
    /// World height in chunks
    /// </summary>
    public const int Height = 16;

    public World()
    {
        AddComponent(new Universe2D());
    }
}
