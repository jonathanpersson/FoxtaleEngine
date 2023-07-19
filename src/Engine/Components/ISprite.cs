using Foxtale.Engine.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Foxtale.Engine.Components;

public interface ISprite : IComponent
{
    public Texture2D Texture { get; set; }
    public Color RenderTint { get; set; }
    public Origin2D Origin { get; set; }
    public Vector2 SpriteSize { get; }
}