using System;
using Microsoft.Xna.Framework;
using MgGame.Entities;
using MgGame.Systems;

namespace MgGame.Components;

public class Transform : IComponent
{
    public Vector2 Position { get; set; }
    public Vector2 Scale { get; set; }
    public float Rotation { get; set; }
    public float LayerDepth { get; set; }
    public IEntity Entity { get; set; }

    public Transform()
    {
        TransformSystem.AddComponent(this);
    }

    public void Initialize() { }
    public void Update(GameTime gameTime) { }
}