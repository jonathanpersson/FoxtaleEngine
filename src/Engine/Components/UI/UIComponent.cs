using MgGame.Engine.Components;
using MgGame.Engine.Systems;
using MgGame.Engine.Entities;
using MgGame.Engine.Systems.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MgGame.Engine.Components.UI;

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
