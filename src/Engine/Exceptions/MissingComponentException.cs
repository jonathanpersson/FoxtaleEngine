using System;
using Foxtale.Engine.Entities;
using Foxtale.Engine.Components;

namespace Foxtale.Engine.Exceptions;

public class MissingComponentException : Exception
{
    public MissingComponentException() {}
    public MissingComponentException(IEntity entity, Type expected)
    {
        throw new MissingComponentException($"Entity {entity.GetType()} does not contain component {expected.GetType()}.");
    }
    public MissingComponentException(string message) : base(message) { }
}
