using Foxtale.Engine.Entities;
using Foxtale.Engine.Systems;
using Microsoft.Xna.Framework;

namespace Foxtale.Engine.Components.Physics;

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
