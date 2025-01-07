

namespace CleanArchitecture.Application.Exeptions
{
    public sealed class ConcurrencyExeptions : Exception
    {
        public ConcurrencyExeptions(string message, Exception innerException)
            :base(message, innerException)
        {

        }
    }
}
