using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MgGame.Entities;
using MgGame.Systems;

namespace MgGame.Components;

public class Sprite : IComponent
{
    public Texture2D Texture { get; set; }
    public IEntity Entity { get; set; }

    public Sprite(Texture2D spriteTexture)
    {
        SpriteSystem.AddComponent(this);
    }

    public void Initialize() { }
    public void Update(GameTime gameTime) { }
}
