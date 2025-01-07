namespace CleanArchitecture.Application.Exeptions
{
    public sealed record ValidationError(
        string PropertyName,
        string ErrorMessage
    );
}
