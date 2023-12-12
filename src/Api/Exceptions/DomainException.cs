using System.Runtime.Serialization;

namespace SimpleShop.src.Api.Exceptions;
#pragma warning disable CS1591
/// <summary>
/// The exception raise in the Domain layer 
/// </summary>
public class DomainException : Exception
{
    public DomainException(string? message) : base(message)
    {
    }

    public DomainException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected DomainException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}