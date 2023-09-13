using Foxtale.Components;
using Microsoft.Xna.Framework.Graphics;

namespace Foxtale.Systems;

public class TextureStackSystem : BaseSystem<TextureStack>
{
    public static void Draw(SpriteBatch sb)
    {
        foreach (TextureStack stack in components)
        {
            Transform2D transform = stack.Entity.GetComponent<Transform2D>();
            
            foreach (Texture2D sprite in stack.Textures)
            {
                sb.Draw(sprite, transform.Position, sprite.Bounds, stack.RenderTint,
                    transform.Rotation, transform.Origin, transform.Scale, 
                    stack.Effect, transform.LayerDepth);
            }
        }
    }
}