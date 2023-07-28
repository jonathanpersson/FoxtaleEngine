using Foxtale.Engine.Entities;
using Microsoft.Xna.Framework;

namespace Foxtale.Entities.Scenes;

public class Test : Scene2D
{
    public Test()
    {
        
    }

    protected override void Activate()
    {
        Content.Add(new Fox());
}

    protected override void Deactivate()
    {
        
    }

    public override void Update(GameTime gameTime)
    {
        
    }
}