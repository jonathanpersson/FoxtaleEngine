using Foxtale.Entities;
using Foxtale.Systems;
using Microsoft.Xna.Framework;

namespace Foxtale.Components;

public abstract class Script : IComponent
{
    public IEntity Entity { get; set; }

    protected Script()
    {
        ScriptSystem.AddComponent(this);
    }

    public void Initialize() { }
    public abstract void Update(GameTime gameTime);

    public void Destroy()
    {
        ScriptSystem.RemoveComponent(this);
    }
}
