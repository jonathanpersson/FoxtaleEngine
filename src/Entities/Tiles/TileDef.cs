using Microsoft.Xna.Framework.Graphics;
using Foxtale.Components;

namespace Foxtale.Entities.Tiles;

public class TileDef : Entity2D
{
    public ISprite Sprite { get; set; }

    public TileDef(Texture2D sprite)
    {
        Sprite = new Sprite(sprite)
        {
            Render = false
        };
        AddComponent(Sprite);
    }
}