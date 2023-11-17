using Foxtale.Components;
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
            Transform2D transform = sprite.Entity.GetComponent<Transform2D>();
            sb.Draw(sprite.Texture, transform.Position, sprite.SourceRectangle, sprite.RenderTint,
                transform.Rotation, transform.Origin, transform.Scale, 
                sprite.Effect, transform.LayerDepth);
        }
    }
}
