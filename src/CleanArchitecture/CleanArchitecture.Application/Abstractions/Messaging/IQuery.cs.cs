﻿using CleanArchitecture.Domain.Abstractions;
using MediatR;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{

}
    
