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

    public Color RenderColor
    {
        get
        {
            //todo: inherit style?
            if (Entity.TryGetComponent(out Style style))
            {
                return style.ForegroundColor;
            }
            return Color.White;
        }
    }

    public Sprite()
    {
        SpriteSystem.AddComponent(this);
    }

    public Sprite(Texture2D spriteTexture)
    {
        SpriteSystem.AddComponent(this);
    }

    public void Initialize() { }
    public void Update(GameTime gameTime) { }
}
