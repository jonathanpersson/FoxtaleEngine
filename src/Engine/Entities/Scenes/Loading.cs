using Foxtale.Engine.Components.UI;
using Foxtale.Engine.Core;
using Foxtale.Engine.Entities.UI;
using Foxtale.Engine.Entities.UI.Controls;
using Foxtale.Engine.Systems.UI;
using Microsoft.Xna.Framework;

namespace Foxtale.Engine.Entities.Scenes;

public class Loading : Scene2D
{
    private readonly Scene2D _afterLoading;
    private double _timer;
    
    public Loading(Scene2D afterLoading)
    {
        _afterLoading = afterLoading;
        _timer = 0;
    }

    protected override void Activate()
    {
        GameInstance.ClearColor = Color.FromNonPremultiplied(35, 29, 26, 255);
        Container container = new(
            new Image(UserInterfaceSystem.Graphics.PreferredBackBufferWidth / 2, 
                UserInterfaceSystem.Graphics.PreferredBackBufferHeight / 2
                , "Textures/foxtale", 6, Origin2D.MiddleCenter)/*,
            new AnimatedImage(UserInterfaceSystem.Graphics.PreferredBackBufferWidth / 2, 
                UserInterfaceSystem.Graphics.PreferredBackBufferHeight / 2 - 100
                , 78, 64, "Textures/Fox/walk", 10, 6, Origin2D.MiddleCenter)*/
        );
        container.AddComponent(new Style());
        Content.Add(container);
    }

    protected override void Deactivate()
    {
        GameInstance.ClearColor = Color.Black;
    }

    public override void Update(GameTime gameTime)
    {
        _timer += gameTime.ElapsedGameTime.TotalSeconds;
        if (_timer < 4) return;
        GameInstance.SetScene(_afterLoading);
    }
}