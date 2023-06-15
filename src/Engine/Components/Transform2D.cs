using System;
using Microsoft.Xna.Framework;
using MgGame.Engine.Entities;
using MgGame.Engine.Systems;
using MonoGame.Extended;

namespace MgGame.Engine.Components;

public class Transform2D : IComponent
{
    public Vector2 Position { get; set; } = Vector2.Zero;
    public Vector2 Scale { get; set; } = Vector2.One;
    public float Rotation { get; private set; } = 0;
    public float LayerDepth { get; set; } = 0;
    public IEntity Entity { get; set; }

    public Transform2D()
    {
        Transform2DSystem.AddComponent(this);
    }

    public Transform2D(int x, int y)
    {
        Position = new Vector2(x, y);
        Transform2DSystem.AddComponent(this);
    }

    public Transform2D(Vector2 position, Vector2 scale, float rotation = 0, float layerDepth = 0)
    {
        Position = position;
        Scale = scale;
        Rotation = rotation;
        LayerDepth = layerDepth;
        Transform2DSystem.AddComponent(this);
    }

    public void Initialize() { }
    public void Update(GameTime gameTime) { }

    public void Rotate(float deg)
    {
        double d = 1 / 360 * deg;
        Rotation = (float)Math.Min(d, d - Math.Truncate(d));
    }
}