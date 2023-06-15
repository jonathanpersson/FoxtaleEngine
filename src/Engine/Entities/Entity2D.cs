using System;
using System.Collections.Generic;
using MgGame.Engine.Components;
using MgGame.Engine.Exceptions;

namespace MgGame.Engine.Entities;

public class Entity2D : Entity
{
    public Transform2D Transform { get; }

    public Entity2D()
    {
        Transform = new Transform2D();
        AddComponent(Transform);
    }
}
