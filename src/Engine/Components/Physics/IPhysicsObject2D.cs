using Foxtale.Engine.Core;
using MonoGame.Extended;
using Microsoft.Xna.Framework;

namespace Foxtale.Engine.Components.Physics;

public interface IPhysicsObject2D : IComponent
{
    /// <summary>
    /// Amount of gravity applied to physics object
    /// </summary>
    public static float Gravity = 9.81f;

    /// <summary>
    /// Axis gravity is applied to
    /// </summary>
    public static Axis2D GravityAxis { get; set; } = Axis2D.Y;

    public Quadrilateral Bounds { get; set; }
    public float Mass { get; set; }
    public float MaxVelocity { get; }
    public float Density { get; }
    public Vector2 Velocity { get; set; }
    public Vector2 Acceleration { get; set; }
}
