using Foxtale.Engine.Components;
using Foxtale.Engine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Foxtale.Engine.Systems;

public class SpriteSystem : BaseSystem<Sprite>
{
    public static void Draw(SpriteBatch sb)
    {
        foreach (Sprite sprite in components)
        {
            Transform2D transform = sprite.Entity.GetComponent<Transform2D>();
            sb.Draw(sprite.Texture, transform.Position, sprite.Texture.Bounds, sprite.RenderTint,
                transform.Rotation, transform.Origin, transform.Scale, 
                sprite.Effect, transform.LayerDepth);
        }
    }
}
