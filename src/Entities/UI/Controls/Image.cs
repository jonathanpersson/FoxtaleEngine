using Foxtale.Components;
using Foxtale.Core;
using Foxtale.Core.Geometry;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Foxtale.Entities.UI.Controls;

public class Image : UIEntity
{
    public Sprite Sprite { get; }

    public Image(int x, int y, string texture, Origin2D origin = Origin2D.TopLeft)
    {
        Sprite = new Sprite();
        Sprite.Origin = origin;
        AddComponent(Sprite);
        Transform.Position = new Vector2(x, y);
        Sprite.Texture = GameInstance.ContentManager.Load<Texture2D>(texture);
        Transform.Size = new Vector2(Sprite.Texture.Width, Sprite.Texture.Height);
        Transform.OriginFromSprite(Sprite);
    }
}