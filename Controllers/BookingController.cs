using AutoMapper;
using FlightREST.DataTransfer;
using FlightREST.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using FlightREST.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FlightREST.Controllers
{
    public class BookingController : ControllerBase
    {
        public readonly IGenericRepository<Booking> _bookingRepository;
        private readonly IMapper _mapper;

        public BookingController(IGenericRepository<Booking> bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        [HttpPost("createBooking")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(BookingReadTransfer))]
        public async Task<IActionResult> CreateFlight([FromBody] BookingCreateTransfer bookingDto)
        {
            var bookingModel = _mapper.Map<Booking>(bookingDto);

            var addedBooking = await _bookingRepository.AddAsync(bookingModel);
            return Ok(_mapper.Map<BookingReadTransfer>(addedBooking));
        }

        [HttpPut("updateBooking")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(BookingReadTransfer))]
        public async Task<IActionResult> UpdateFlight([Required] long bookingId, [FromBody] BookingBaseTransfer bookingDto)
        {
            var bookingModel = _mapper.Map<Models.Booking>(bookingDto);
            bookingModel.Id = bookingId;

            var updatedBooking = await _bookingRepository.UpdateAsync(bookingModel);

            return Ok(_mapper.Map<BookingReadTransfer>(updatedBooking));
        }

        [HttpGet("getBookings")]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(BookingReadTransfer))]
        public async Task<IActionResult> GetBookings()
        {
            var bookings = await _bookingRepository.GetAsync(null, i => i.Include(e => e.Flight).Include(e => e.Tickets).Include(e => e.User));

            return Ok(_mapper.Map<IEnumerable<BookingReadTransfer>>(bookings));
        }
    }
}
