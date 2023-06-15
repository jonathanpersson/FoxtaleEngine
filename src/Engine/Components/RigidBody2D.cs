using MgGame.Engine.Entities;
using Microsoft.Xna.Framework;

namespace MgGame.Engine.Components;

public class RigidBody2D : IPhysicsObject2D
{
    public IEntity Entity { get; set; }

    public RigidBody2D() { }

    public void Initialize() { }

    public void Update(GameTime gameTime) { }
}
