

using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Reviews
{
    public static class ReviewErrors
    {
        public static readonly Error NotEligible = new(
            "review.NotEligible",
            "No se puede crear una reseña para un alquiler que no esté completado"
        );
    }
}
