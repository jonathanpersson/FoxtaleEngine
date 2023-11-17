using Foxtale.Components;
using Foxtale.Components.UI;
using Foxtale.Core;
using Foxtale.Core.Geometry;
using Foxtale.Entities.UI;
using Foxtale.Entities.UI.Controls;
using Foxtale.Systems.UI;
using Microsoft.Xna.Framework;

namespace Foxtale.Entities.Scenes;

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
        Image loadingImage = new (0, 0, "Textures/foxtale", 6, Origin2D.MiddleCenter);
        loadingImage.Dock.Style = DockStyle.MiddleCenter;
        Container container = new(
            loadingImage
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