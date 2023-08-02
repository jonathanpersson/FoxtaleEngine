using Foxtale.Components;

namespace Foxtale.Entities;

public class Entity2D : Entity
{
    public Transform2D Transform { get; }

    public Entity2D()
    {
        Transform = new Transform2D();
        AddComponent(Transform);
    }
}
