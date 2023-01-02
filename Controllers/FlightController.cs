using AutoMapper;
using FlightREST.DataTransfer;
using FlightREST.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FlightREST.Controllers
{
    public class FlightController : ControllerBase
    {
        public readonly IGenericRepository<Models.Flight> _flightRepository;
        private readonly IMapper _mapper;

        public FlightController(IGenericRepository<Models.Flight> flightRepository, IMapper mapper)
        {
            _flightRepository = flightRepository;
            _mapper = mapper;
        }

        [HttpPost("createFlight")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(FlightReadTransfer))]
        public async Task<IActionResult> CreateFlight([FromBody] FlightBaseTransfer flightDto)
        {
            var flightModel = _mapper.Map<Models.Flight>(flightDto);

            var addedFlight = await _flightRepository.AddAsync(flightModel);
            return Ok(_mapper.Map<FlightReadTransfer>(addedFlight));
        }

        [HttpPut("updateFlight")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(UserReadTransfer))]
        public async Task<IActionResult> UpdateFlight([Required] long flightId, [FromBody] FlightBaseTransfer flightDto)
        {
            var userModel = _mapper.Map<Models.Flight>(flightDto);
            userModel.Id = flightId;

            var updatedPlane = await _flightRepository.UpdateAsync(userModel);

            return Ok(_mapper.Map<FlightReadTransfer>(updatedPlane));
        }

        [HttpGet("getFlights")]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(FlightReadTransfer))]
        public async Task<IActionResult> GetBookings()
        {
            var flights = await _flightRepository.GetAsync(null, i => i.Include(e => e.Bookings));

            return Ok(_mapper.Map<IEnumerable<FlightReadTransfer>>(flights));
        }

        [HttpPost("searchFlights")]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(FlightReadTransfer))]
        public async Task<IActionResult> SearchFlights(FlightSearchParameters search)
        {
            var flights = await _flightRepository.GetAsync(q => q.IsActive && 
            (string.IsNullOrEmpty(search.Arrival) || q.Arrival.ToLower().Contains(search.Arrival.ToLower())) &&
            (string.IsNullOrEmpty(search.Departure) || q.Departure.ToLower().Contains(search.Departure.ToLower())));

            return Ok(_mapper.Map<IEnumerable<FlightReadTransfer>>(flights));
        }
    }
}
