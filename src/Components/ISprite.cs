using Foxtale.Core.Geometry;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Foxtale.Components;

public interface ISprite : IComponent
{
    public bool Render { get; set; }
    public Texture2D Texture { get; set; }
    public Color RenderTint { get; set; }
    public Origin2D Origin { get; set; }
    public Vector2 SpriteSize { get; }
    public SpriteEffects Effect { get; set; }
}