using MgGame.Engine.Components;
using MgGame.Engine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MgGame.Engine.Systems;

public class SpriteSystem : BaseSystem<Sprite>
{
    public static void Draw(SpriteBatch sb)
    {
        foreach (Sprite sprite in components)
        {
            Vector2 location = sprite.Entity.GetComponent<Transform2D>().Position;
            sb.Draw(sprite.Texture, location, sprite.RenderColor);
        }
    }
}
