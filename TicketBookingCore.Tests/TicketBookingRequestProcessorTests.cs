[Fact]
public void ShouldSaveToDatabase()
{
    // Arrange: skapa ett testobjekt med namn och email
    var request = new TicketBookingRequest
    {
        FirstName = "Nevena",
        LastName = "Kicanovic",
        Email = "nevena@gmail.com"
    };

    // RED-fasen: processorn är inte klar, testet ska misslyckas
    var processor = new TicketBookingRequestProcessor(null);

    // Act: kör Book-metoden
    var response = processor.Book(request);

    // Assert: kontrollera att namnet stämmer
    Assert.Equal(request.FirstName, response.FirstName);
}
