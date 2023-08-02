using Foxtale.Entities;
using Foxtale.Systems;
using Microsoft.Xna.Framework;

namespace Foxtale.Components.Physics;

public class Collider : IComponent
{
    public IEntity Entity { get; set; }

    public Collider()
    {
        ColliderSystem.AddComponent(this);
    }

    public void Initialize() { }
    public void Update(GameTime gameTime) { }

    public void Destroy()
    {
        throw new System.NotImplementedException();
    }
}
