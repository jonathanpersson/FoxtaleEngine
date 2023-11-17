using Foxtale.Components;
using Foxtale.Core;
using Foxtale.Core.Geometry;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Foxtale.Entities.UI.Controls;

public class AnimatedImage : UIEntity
{
    public AnimatedSprite Sprite { get; }

    public AnimatedImage(int x, int y, int width, int height, string texture, float framerate, float scale = 1,
        Origin2D origin = Origin2D.TopLeft)
    {
        Sprite = new 
            AnimatedSprite(GameInstance.ContentManager.Load<Texture2D>(texture), width, height, framerate);
        Sprite.Origin = origin;
        AddComponent(Sprite);
        Transform.Position = new Vector2(x, y);
        Transform.Scale = new Vector2(scale, scale);
        Transform.OriginFromSprite(Sprite);
        Transform.Size = new Vector2(width, height);
    }
}