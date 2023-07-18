using System;
using System.Collections.Generic;
using Foxtale.Engine.Components;
using Foxtale.Engine.Exceptions;

namespace Foxtale.Engine.Entities;

public class Entity2D : Entity
{
    public Transform2D Transform { get; }

    public Entity2D()
    {
        Transform = new Transform2D();
        AddComponent(Transform);
    }
}
