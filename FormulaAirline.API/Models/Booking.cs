namespace FormulaAirline.API.Models;

public class Booking
{
    public int Id { get; set; }

    public string PassengerName { get; set; } = null!;

    public string PassportNb { get; set; } = null!;

    public string From { get; set; } = null!;

    public string To { get; set; } = null!;

    public int Status { get; set; }
}