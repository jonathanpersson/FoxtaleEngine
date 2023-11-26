using Foxtale.Components;
using Foxtale.Entities.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Foxtale.Systems;

public class AnimatedSpriteSystem : BaseSystem<AnimatedSprite>
{
    public static void Update(GameTime gameTime)
    {
        foreach (AnimatedSprite component in components)
        {
            if (!component.Render) continue;
            component.Update(gameTime);
        }
    }

    public static void Draw(SpriteBatch sb)
    {
        foreach (AnimatedSprite sprite in components)
        {
            if (!sprite.Render) continue;

            if (sprite.Entity is UIEntity e)
            {
                ScreenSpaceTransform transform = e.Transform;
                Draw(sb, sprite, transform);
                continue;
            }

            Draw(sb, sprite, sprite.Entity.GetComponent<Transform2D>());
        }
    }

    private static void Draw(SpriteBatch sb, AnimatedSprite sprite, ScreenSpaceTransform transform)
    {
        sb.Draw(sprite.Texture, transform.Position, sprite.SourceRectangle, sprite.RenderTint,
            transform.Rotation, transform.Origin, transform.Scale, 
            sprite.Effect, transform.LayerDepth);
    }

    private static void Draw(SpriteBatch sb, AnimatedSprite sprite, Transform2D transform)
    {
        sb.Draw(sprite.Texture, transform.Position, sprite.SourceRectangle, sprite.RenderTint,
            transform.Rotation, transform.Origin, transform.Scale, 
            sprite.Effect, transform.LayerDepth);
    }
}
