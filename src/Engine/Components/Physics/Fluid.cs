using Foxtale.Engine.Entities;
using Microsoft.Xna.Framework;

namespace Foxtale.Engine.Components.Physics;

public class Fluid : IEnvironment
{
    public IEntity Entity { get; set; }

    public Fluid()
    {

    }

    public void Initialize() { }
    public void Update(GameTime gameTime) { }

    public void Destroy()
    {
        throw new System.NotImplementedException();
    }
}
