using System;

namespace Foxtale.Exceptions;

public class UndefinedMeshOperationException : Exception
{
    public UndefinedMeshOperationException() { }
    public UndefinedMeshOperationException(string message) : base(message) { }
}
