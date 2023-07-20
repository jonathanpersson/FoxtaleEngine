using Foxtale.Engine.Components.Scripts;

namespace Foxtale.Engine.Entities.UI.Controls;

public class FrameCounter : Label
{
    public FrameCounter(int x, int y) : base(x, y, "0 FPS")
    {
        AddComponent(new FrameCounterScript());
    }
}