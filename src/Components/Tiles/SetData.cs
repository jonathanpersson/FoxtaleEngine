using Foxtale.Entities;
using Microsoft.Xna.Framework.Graphics;

namespace Foxtale.Components.Tiles;

public class SetData : IComponent
{
    public Texture2D Texture { get; set; }
    public (int Width, int Height) TileSize { get; set; }
    public IEntity Entity { get; set; }

    public SetData(Texture2D tileset, int width, int height)
    {
        Texture = tileset;
        TileSize = (width, height);
    }

    public void Destroy()
    {
        Texture?.Dispose();
    }
}