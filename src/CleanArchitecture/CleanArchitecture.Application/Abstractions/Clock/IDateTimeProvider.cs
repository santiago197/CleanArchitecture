

namespace CleanArchitecture.Application.Abstractions.Clock
{
    internal interface IDateTimeProvider
    {
        DateTime currentTime { get; }
    }
}
