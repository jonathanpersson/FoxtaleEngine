using System;
using Foxtale.Engine.Core;
using Foxtale.Engine.Entities;
using Foxtale.Engine.Systems;
using Microsoft.Xna.Framework;
using MonoGame.Extended;

namespace Foxtale.Engine.Components;

public class Transform2D : IComponent
{
    public Vector2 Position { get; set; } = Vector2.Zero;
    public Vector2 Scale { get; set; } = Vector2.One;
    public Vector2 Origin { get; set; } = Vector2.Zero;
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

    /// <summary>
    /// Calculate origin from sprite
    /// </summary>
    /// <param name="sprite">Sprite to get origin from</param>
    public void OriginFromSprite(Sprite sprite)
    {
        Origin = sprite.Origin switch
        {
            Origin2D.TopLeft => Vector2.Zero,
            Origin2D.MiddleLeft => new Vector2(0, sprite.Texture.Height / 2),
            Origin2D.BottomLeft => new Vector2(0, sprite.Texture.Height),
            Origin2D.TopCenter => new Vector2(sprite.Texture.Width / 2, 0),
            Origin2D.MiddleCenter => new Vector2(sprite.Texture.Width / 2, sprite.Texture.Height / 2),
            Origin2D.BottomCenter => new Vector2(sprite.Texture.Width / 2, sprite.Texture.Height),
            Origin2D.TopRight => new Vector2(sprite.Texture.Width, 0),
            Origin2D.MiddleRight => new Vector2(sprite.Texture.Width, sprite.Texture.Height / 2),
            Origin2D.BottomRight => new Vector2(sprite.Texture.Width, sprite.Texture.Height),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}