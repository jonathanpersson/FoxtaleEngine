using System.Collections.Generic;
using Foxtale.Components;

namespace Foxtale.Entities.UI;

public class Container : UIEntity
{
    public Container()
    {
        AddComponent(new Children());
    }

    public Container(IUIEntity child)
    {
        AddComponent(new Children(child));
    }

    public Container(IEnumerable<IUIEntity> children)
    {
        AddComponent(new Children(children));
    }

    public Container(params IUIEntity[] children)
    {
        AddComponent(new Children(children));
    }
}
