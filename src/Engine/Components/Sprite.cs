using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MgGame.Engine.Entities;
using MgGame.Engine.Systems;
using MgGame.Engine.Components.UI;

namespace MgGame.Engine.Components;

public class Sprite : IComponent
{
    public Texture2D Texture { get; set; }
    public IEntity Entity { get; set; }
    public Color RenderTint { get; set; } = Color.White;

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
}
