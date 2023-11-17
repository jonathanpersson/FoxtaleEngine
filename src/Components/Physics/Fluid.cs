using Foxtale.Entities;
using Microsoft.Xna.Framework;

namespace Foxtale.Components.Physics;

public class Fluid : IEnvironment
{
    public IEntity Entity { get; set; }

    public Fluid()
    {

    }

    public void Destroy()
    {
        throw new System.NotImplementedException();
    }
}
