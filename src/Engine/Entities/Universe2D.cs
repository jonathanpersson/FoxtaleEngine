using Foxtale.Engine.Components;
using Foxtale.Engine.Components.Physics;
using Foxtale.Engine.Systems;

namespace Foxtale.Engine.Entities;

public class Universe2D : Entity2D
{
    public Children Content { get; }
    public IEnvironment Environment { get; }

    public Universe2D()
    {
        Content = new Children();
        Environment = new Fluid();
        AddComponent(Content);
        AddComponent(Environment);
    }

    public Universe2D(IEnvironment environment)
    {
        Content = new Children();
        Environment = environment;
        AddComponent(Content);
        AddComponent(Environment);
    }
}
