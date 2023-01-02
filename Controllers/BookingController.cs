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
using FlightREST.Enums;
using System.Linq;

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

        [HttpGet("getBookings")]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(BookingReadTransfer))]
        public async Task<IActionResult> GetBookings()
        {
            var bookings = await _bookingRepository.GetAsync(null, i => i.Include(e => e.Flight).Include(e => e.Tickets).Include(e => e.User));

            return Ok(_mapper.Map<IEnumerable<BookingReadTransfer>>(bookings));
        }

        [HttpGet("getByUser")]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(BookingReadTransfer))]
        public async Task<IActionResult> GetBookings([Required] long userId)
        {
            var bookings = await _bookingRepository.GetAsync(q => q.UserId == userId,
                i => i.Include(e => e.Flight).Include(e => e.Tickets).Include(e => e.User));

            return Ok(_mapper.Map<IEnumerable<BookingReadTransfer>>(bookings));
        }

        [HttpPatch("updateStatus")]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerResponse(StatusCodes.Status201Created, Type = typeof(BookingReadTransfer))]
        public async Task<IActionResult> UpdateStatus([Required] long bookingId, [Required] BookingStatus status)
        {
            var booking = (await _bookingRepository.GetAsync(q => q.Id == bookingId)).SingleOrDefault();

            booking.BookingStatus = status;

            var updated = await _bookingRepository.UpdateAsync(booking);

            return Ok(_mapper.Map<BookingReadTransfer>(updated));
        }
    }
}
