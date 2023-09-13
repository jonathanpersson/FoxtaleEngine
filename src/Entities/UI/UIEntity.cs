using Microsoft.Xna.Framework;

namespace Foxtale.Entities.UI;

public class UIEntity : Entity2D, IUIEntity
{
    protected UIEntity()
    {
        Transform.Scale = new Vector2(.5f, .5f);
    }
}
