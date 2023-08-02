using Foxtale.Core;
using Foxtale.Entities;
using Foxtale.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Foxtale.Components;

public class Sprite : IComponent, ISprite
{
    public Texture2D Texture { get; set; }
    public IEntity Entity { get; set; }
    public Color RenderTint { get; set; } = Color.White;
    public Origin2D Origin { get; set; } = Origin2D.TopLeft;
    public Vector2 SpriteSize => new Vector2(Texture.Width, Texture.Height);
    public SpriteEffects Effect { get; set; } = SpriteEffects.None;

    public Sprite()
    {
        SpriteSystem.AddComponent(this);
    }

    public Sprite(Texture2D texture)
    {
        Texture = texture;
        SpriteSystem.AddComponent(this);
    }

    public void Initialize() { }
    public void Update(GameTime gameTime) { }

    public void Destroy()
    {
        SpriteSystem.RemoveComponent(this);
    }
}
