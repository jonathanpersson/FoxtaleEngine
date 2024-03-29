﻿using Foxtale.Core;
using Foxtale.Entities;
using Foxtale.Systems;
using Microsoft.Xna.Framework;

namespace Foxtale.Components.Physics;

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
        _environment = GameInstance.ActiveSceneEnvironment;
        Density = Mass / Bounds.Area;
        //todo: https://en.wikipedia.org/wiki/Terminal_velocity
        // MaxVelocity = Math.Sqrt((2 * Mass * IPhysicsObject2D.Gravity) / (_environment.Density * ));
    }

    public void Destroy()
    {
        RigidBodySystem.RemoveComponent(this);
    }
}
