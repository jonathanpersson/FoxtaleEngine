using Foxtale.Entities;
using Foxtale.Systems.UI;
using Microsoft.Xna.Framework;

namespace Foxtale.Components.UI;

public abstract class UIComponent : IComponent
{
    public IEntity Entity { get; set; }

    protected UIComponent()
    {
        UserInterfaceSystem.AddComponent(this);
    }

    public virtual void Initialize() { }

    public void Update(GameTime gameTime) { }

    public void Destroy()
    {
        UserInterfaceSystem.RemoveComponent(this);
    }
}
