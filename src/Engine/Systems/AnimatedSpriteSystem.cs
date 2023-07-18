using Foxtale.Engine.Components;
using Foxtale.Engine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Foxtale.Engine.Systems;

public class AnimatedSpriteSystem : BaseSystem<AnimatedSprite>
{
    public static void Draw(SpriteBatch sb)
    {
        foreach (AnimatedSprite sprite in components)
        {
            Transform2D transform = sprite.Entity.GetComponent<Transform2D>();
            sb.Draw(sprite.Texture, transform.Position, sprite.SourceRectangle, sprite.RenderTint,
                transform.Rotation, transform.Origin, transform.Scale, 
                SpriteEffects.None, transform.LayerDepth);
        }
    }
}
