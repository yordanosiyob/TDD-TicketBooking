using Xunit;

public class TicketBookingRequestProcessorTests
{
    [Fact]
    public void ShouldSaveToDatabase()
    {
        // Arrange
        var request = new TicketBookingRequest
        {
            FirstName = "Nevena",
            LastName = "Kicanovic",
            Email = "nevena@gmail.com"
        };

        // RED: Vi skickar null till processorn, testet ska faila
        var processor = new TicketBookingRequestProcessor(null);

        // Act
        var response = processor.Book(request);

        // Assert
        Assert.Equal(request.FirstName, response.FirstName);
    }
}

