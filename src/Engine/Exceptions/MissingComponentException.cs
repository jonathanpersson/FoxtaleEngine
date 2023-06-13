using System;
using MgGame.Engine.Components;
using MgGame.Engine.Entities;

namespace MgGame.Engine.Exceptions;

public class MissingComponentException : Exception
{
    public MissingComponentException() {}
    public MissingComponentException(IEntity entity, Type expected)
    {
        throw new MissingComponentException($"Entity {entity.GetType} does not contain component {expected.GetType}.");
    }
    public MissingComponentException(string message) : base(message) { }
}
