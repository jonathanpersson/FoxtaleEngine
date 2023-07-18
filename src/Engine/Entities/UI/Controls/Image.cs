using Foxtale.Engine.Components;
using Foxtale.Engine.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Foxtale.Engine.Entities.UI.Controls;

public class Image : UIEntity
{
    public Sprite Sprite { get; }

    public Image(int x, int y, string texture, float scale = 1, Origin2D origin = Origin2D.TopLeft)
    {
        Sprite = new Sprite();
        Sprite.Origin = origin;
        AddComponent(Sprite);
        Transform.Position = new Vector2(x, y);
        Transform.Scale = new Vector2(scale, scale);
        Sprite.Texture = GameInstance.ContentManager.Load<Texture2D>(texture);
        Transform.OriginFromSprite(Sprite);
    }
}