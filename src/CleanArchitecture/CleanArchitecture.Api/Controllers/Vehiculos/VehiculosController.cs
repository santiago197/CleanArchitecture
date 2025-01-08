﻿using CleanArchitecture.Application.Vehiculos.SearchVehiculos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Vehiculos
{
    [ApiController]
    [Route("api/[controller]")  ]
    public class VehiculosController : ControllerBase
    {
        private readonly ISender _sender;

        public VehiculosController(ISender sender)
        {
            _sender = sender;
        }
        [HttpGet]
        public async Task<IActionResult> SearchVehiculos(
            DateOnly startDate, DateOnly endDate, CancellationToken cancellationToken)
        {
            var query = new SearchVehiculosQuery(startDate, endDate);
            var resultados =await _sender.Send(query, cancellationToken);
            return Ok(resultados.Value);
        }
    }
}
