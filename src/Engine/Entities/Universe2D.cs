using MgGame.Engine.Components;
using MgGame.Engine.Systems;

namespace MgGame.Engine.Entities;

public class Universe2D : Entity2D
{
    public Universe2D()
    {
        AddComponent(new Children());
    }
}
