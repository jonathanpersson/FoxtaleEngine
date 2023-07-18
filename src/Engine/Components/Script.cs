using Foxtale.Engine.Entities;
using Foxtale.Engine.Systems;
using Microsoft.Xna.Framework;

namespace Foxtale.Engine.Components;

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
