using Foxtale.Engine.Components;
using Foxtale.Engine.Components.Physics;
using Foxtale.Engine.Systems;
using Microsoft.Xna.Framework;

namespace Foxtale.Engine.Entities;

public abstract class Scene2D : Entity2D
{
    public Children Content { get; set; }
    public IEnvironment Environment { get; }

    protected Scene2D()
    {
        Content = new Children();
        Environment = new Fluid();
        AddComponent(Content);
        AddComponent(Environment);
    }

    protected Scene2D(IEnvironment environment)
    {
        Content = new Children();
        Environment = environment;
        AddComponent(Content);
        AddComponent(Environment);
    }

    protected Scene2D(params IEntity[] children)
    {
        Content = new Children(children);
        Environment = new Fluid();
        AddComponent(Content);
        AddComponent(Environment);
    }
    
    protected Scene2D(IEnvironment environment, params IEntity[] children)
    {
        Content = new Children(children);
        Environment = environment;
        AddComponent(Content);
        AddComponent(Environment);
    }

    public abstract void Update(GameTime gameTime);

    public void Destroy()
    {
        //todo: must destroy all active entities in scene
        Content.Destroy();
        Content.Nodes.Clear();
    }
}
