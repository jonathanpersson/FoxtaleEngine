using Foxtale.Engine.Entities;
using Foxtale.Engine.Systems.UI;
using Foxtale.Engine.Components;
using Foxtale.Engine.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Foxtale.Engine.Components.UI;

public abstract class UIComponent : IComponent
{
    public IEntity Entity { get; set; }

    protected UIComponent()
    {
        UserInterfaceSystem.AddComponent(this);
    }

    public virtual void Initialize() { }

    public void Update(GameTime gameTime) { }
}
