using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Foxtale.Systems;
using System;

namespace Foxtale.Components;

/// <summary>
/// A type of Transform2D specifically intended for entities that are rendered relative
/// to the screen. That is (0, 0) is the top-left corner of the game window, not the
/// scene origin.
/// </summary>
public class ScreenSpaceTransform : Transform2D
{
    private Vector2? _scale = null;
    public new static Vector2 ScreenPosition { get; set; }
    public new static Vector2 ScreenScale { get; set; }
    public new static Vector2 ScreenOrigin => Vector2.Zero;
    public new Vector2 Scale
    {
        get => _scale ?? ScreenScale;
        set => _scale = value;
    }
    public new Rectangle Projection =>
        new((int)Position.X, (int)Position.Y, (int)(Scale.X * Size.X), (int)(Scale.Y * Size.Y));

    public ScreenSpaceTransform() : base() {}
    public ScreenSpaceTransform(Vector2 position, float rotation = 0, float layerDepth = 0)
    {
        Position = position;
        Rotation = rotation;
        LayerDepth = layerDepth;
        Transform2DSystem.AddComponent(this);
    }

    public void SetScaling(float scale)
    {
        _scale = new Vector2(scale, scale);
    }
}
