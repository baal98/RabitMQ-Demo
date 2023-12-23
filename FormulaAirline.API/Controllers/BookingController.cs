using FormulaAirline.API.Models;
using FormulaAirline.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace FormulaAirline.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BookingController : ControllerBase
{
    private readonly ILogger<BookingController> _logger;
    private readonly IMessageProducer _messageProducer;

    // In-memory database
    private static readonly List<Booking> Bookings = new();

    public BookingController(ILogger<BookingController> logger, IMessageProducer messageProducer)
    {
        _logger = logger;
        _messageProducer = messageProducer;
    }

    // Retrieve a booking by ID
    [HttpGet("{id}", Name = "GetBooking")]
    public ActionResult<Booking> GetBooking(int id)
    {
        var booking = Bookings.FirstOrDefault(b => b.Id == id);
        if (booking == null)
        {
            return NotFound();
        }
        return booking;
    }

    [HttpPost]
    public IActionResult CreateBooking([FromBody] Booking booking)
    {
        if (booking == null)
        {
            return BadRequest();
        }

        // Generate a new ID for the booking - assuming Id is an integer and you're incrementing it
        booking.Id = Bookings.Any() ? Bookings.Max(b => b.Id) + 1 : 1;

        Bookings.Add(booking);
        _messageProducer.SendingMessage(booking);
        
        // Now reference the "GetBooking" route name
        return CreatedAtRoute("GetBooking", new { id = booking.Id }, booking);
    }
}
