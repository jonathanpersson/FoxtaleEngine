using MgGame.Engine.Core;
using MonoGame.Extended;

namespace MgGame.Engine.Components;

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
    public float Mass { get; set; }
    public float MaxVelocity { get; }
    public float CurrentVelocity { get; }
}
