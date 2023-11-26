using Foxtale.Components;
using Foxtale.Entities.UI;
using Microsoft.Xna.Framework.Graphics;

namespace Foxtale.Systems;

public class SpriteSystem : BaseSystem<Sprite>
{
    public static void Draw(SpriteBatch sb)
    {
        foreach (Sprite sprite in components)
        {
            if (sprite.Entity is UIEntity e)
            {
                ScreenSpaceTransform transform = e.Transform;
                Draw(sb, sprite, transform);
                continue;
            }

            Draw(sb, sprite, sprite.Entity.GetComponent<Transform2D>());
        }
    }

    private static void Draw(SpriteBatch sb, Sprite sprite, Transform2D transform)
    {
        sb.Draw(sprite.Texture, transform.Position, sprite.Texture.Bounds, sprite.RenderTint,
            transform.Rotation, transform.Origin, transform.Scale, 
            sprite.Effect, transform.LayerDepth);
    }

    private static void Draw(SpriteBatch sb, Sprite sprite, ScreenSpaceTransform transform)
    {
        sb.Draw(sprite.Texture, transform.Position, sprite.Texture.Bounds, sprite.RenderTint,
            transform.Rotation, transform.Origin, transform.Scale, 
            sprite.Effect, transform.LayerDepth);
    }
}
