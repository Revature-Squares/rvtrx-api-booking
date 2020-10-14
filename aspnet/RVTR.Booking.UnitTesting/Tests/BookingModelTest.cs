using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RVTR.Booking.ObjectModel.Models;
using Xunit;

namespace RVTR.Booking.UnitTesting.Tests
{
  public class BookingModelTest
  {
    public static readonly IEnumerable<object[]> Bookings = new List<object[]>
    {
      new object[]
      {
        new BookingModel()
        {
          Id = 0,
          AccountId = 0,
          LodgingId = 0,
          Guests = new List<GuestModel>(),
          Rentals = new List<RentalModel>()
        }
      }
    };

    [Theory]
    [MemberData(nameof(Bookings))]
    public void Test_Create_BookingModel(BookingModel booking)
    {
      var validationContext = new ValidationContext(booking);
      var actual = Validator.TryValidateObject(booking, validationContext, null, true);

      Assert.True(actual);
    }

    [Theory]
    [MemberData(nameof(Bookings))]
    public void Test_Validate_BookingModel(BookingModel booking)
    {
      var validationContext = new ValidationContext(booking);
      Assert.Empty(booking.Validate(validationContext));
    }
  }
}
