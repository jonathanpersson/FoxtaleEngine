using Foxtale.Entities;
using Foxtale.Entities.UI;
using Foxtale.Entities.UI.Controls;
using Microsoft.Xna.Framework;

namespace FoxtaleDemo.Entities.Scenes;

public class Test : Scene2D
{
    public Test()
    {
        
    }

    protected override void Activate()
    {
        Content.Add(new Fox());
        Content.Add(new Container(
            new Button(500, 600, "Test Button", (object? sender, EventArgs e) =>
            {
                Console.WriteLine("Hello world!");
            }),
            new TextBox(300, 600, 10, 14, "test")
        ));
}

    protected override void Deactivate()
    {
        
    }

    public override void Update(GameTime gameTime)
    {
        
    }
}