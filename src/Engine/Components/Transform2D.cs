using System;
using Microsoft.Xna.Framework;
using MgGame.Engine.Entities;
using MgGame.Engine.Systems;

namespace MgGame.Engine.Components;

public class Transform2D : IComponent
{
    public Vector2 Position { get; set; }
    public Vector2 Scale { get; set; }
    public float Rotation { get; set; }
    public float LayerDepth { get; set; }
    public IEntity Entity { get; set; }

    public Transform2D()
    {
        Transform2DSystem.AddComponent(this);
    }

    public void Initialize() { }
    public void Update(GameTime gameTime) { }
}