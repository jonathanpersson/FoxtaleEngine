using Foxtale.Components;

namespace Foxtale.Entities.UI;

public interface IUIEntity : IEntity
{
    public DockTransform Dock { get; set; }
}
