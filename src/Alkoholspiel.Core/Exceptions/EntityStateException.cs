namespace Alkoholspiel.Core.Exceptions;

public class EntityStateException : InvalidOperationException
{
    public EntityStateException(string message) : base(message)
    {
    }
}