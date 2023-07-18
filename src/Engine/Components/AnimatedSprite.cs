using Foxtale.Engine.Core;
using Foxtale.Engine.Entities;
using Foxtale.Engine.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Foxtale.Engine.Components;

public class AnimatedSprite : IComponent, ISprite
{
    public Texture2D Texture { get; set; }
    public IEntity Entity { get; set; }
    public Color RenderTint { get; set; } = Color.White;
    public Origin2D Origin { get; set; } = Origin2D.TopLeft;
    public Vector2 SpriteSize { get; set; }
    public Rectangle SourceRectangle { get; private set; }
    public int Frame { get; private set; }
    public float Framerate { get; set; }

    public AnimatedSprite()
    {
        AnimatedSpriteSystem.AddComponent(this);
    }
    
    public void Initialize() { }
    public void Update(GameTime gameTime) { }
}