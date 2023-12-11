using Foxtale.Components;
using Foxtale.Components.Tiles;
using Microsoft.Xna.Framework.Graphics;

namespace Foxtale.Entities.Tiles;

public class Map : Entity2D
{
     public SetData Tileset { get; set; }
     public MapData Data { get; set; }
     
     public Map(Texture2D texture, int width, int height)
     {
         Tileset = new SetData(texture, width, height); 
         Data = new MapData();
         AddComponent(Tileset);
         AddComponent(Data);
    }
}