using Foxtale.Components;
using Foxtale.Core;
using Microsoft.Xna.Framework;

namespace Foxtale.Systems;

public class Transform2DSystem : BaseSystem<Transform2D> 
{
    public static void Initialize(GraphicsDeviceManager g)
    {
        Transform2D.ScreenSize = new Vector2(g.PreferredBackBufferWidth, g.PreferredBackBufferWidth);
    }
}
