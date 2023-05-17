using Microsoft.Xna.Framework;
using MgGame.Engine.Entities;
using MgGame.Engine.Systems;

namespace MgGame.Engine.Components;

public abstract class Script : IComponent
{
    public IEntity Entity { get; set; }

    protected Script()
    {
        ScriptSystem.AddComponent(this);
    }

    public abstract void Initialize();
    public abstract void Update(GameTime gameTime);
}
