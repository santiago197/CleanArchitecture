﻿using CleanArchitecture.Domain.Abstractions;


namespace CleanArchitecture.Domain.Alquileres.Events
{
    public sealed record AlquilerRechazadoDomainEvent(AlquilerId id) : IDomainEvent;
    
}
