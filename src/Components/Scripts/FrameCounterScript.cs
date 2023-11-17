using Foxtale.Entities.UI.Controls;
using Microsoft.Xna.Framework;

namespace Foxtale.Components.Scripts;

public class FrameCounterScript : Script
{
    private double _timer;
    private int _frames;

    public FrameCounterScript()
    {
        _timer = 0;
        _frames = 0;
    }

    public override void Update(GameTime gameTime)
    {
        _timer += gameTime.ElapsedGameTime.TotalSeconds;
        ++_frames;
        if (_timer < 1 || Entity is not Label entity) return;
        entity.Text.Content = $"{_frames} FPS";
        entity.Render();
        _timer = 0;
        _frames = 0;
    }
}