using Microsoft.Xna.Framework;
using MgGame.Engine.Systems;
using MgGame.Engine.Entities;

namespace MgGame.Engine.Components;

public class Collider : IComponent
{
    public IEntity Entity { get; set; }

    public Collider()
    {
        ColliderSystem.AddComponent(this);
    }

    public void Initialize() { }
    public void Update(GameTime gameTime) { }
}
