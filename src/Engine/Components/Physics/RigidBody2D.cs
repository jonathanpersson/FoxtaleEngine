using MgGame.Engine.Core;
using MgGame.Engine.Entities;
using Microsoft.Xna.Framework;

namespace MgGame.Engine.Components.Physics;

public class RigidBody2D : IPhysicsObject2D
{
    private IEnvironment _environment;
    public IEntity Entity { get; set; }
    public Quadrilateral Bounds { get; set; }
    public Vector2 Velocity { get; set; }
    public Vector2 Acceleration { get; set; }
    public float Mass { get; set; }
    public float Density { get; private set; }
    public float MaxVelocity { get; }

    public RigidBody2D() { }

    public void Initialize()
    {
        _environment = GameInstance.ActiveUniverse.Environment;
        Density = Mass / Bounds.Area;

    }

    public void Update(GameTime gameTime) { }
}
