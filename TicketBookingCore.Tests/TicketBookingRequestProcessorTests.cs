using Moq;
using TicketBookingCore;

namespace TicketBookingCore.Tests
{
    public class TicketBookingRequestProcessorTests
    {
        private readonly Mock<ITicketBookingRepository> _repositoryMock;
        private readonly TicketBookingRequestProcessor _processor;
        private readonly TicketBookingRequest _request;

        public TicketBookingRequestProcessorTests()
        {
            _repositoryMock = new Mock<ITicketBookingRepository>();
            _processor = new TicketBookingRequestProcessor(_repositoryMock.Object);
            _request = new TicketBookingRequest
            {
                FirstName = "Nevena",
                LastName = "Kicanovic",
                Email = "nevena@gmail.com"
            };
        }

        [Fact]
        public void ShouldReturnTicketBookingResponseWithRequestValues()
        {
            var response = _processor.Book(_request);

            Assert.NotNull(response);
            Assert.Equal(_request.FirstName, response.FirstName);
            Assert.Equal(_request.LastName, response.LastName);
            Assert.Equal(_request.Email, response.Email);
        }

        [Fact]
        public void ShouldSaveToDatabase()
        {
            _processor.Book(_request);

            _repositoryMock.Verify(r => r.Save(It.Is<TicketBooking>(b =>
                b.FirstName == _request.FirstName &&
                b.LastName == _request.LastName &&
                b.Email == _request.Email)), Times.Once);
        }

        [Fact]
        public void ShouldThrowExceptionIfRequestIsNull()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _processor.Book(null!));
            Assert.Equal("request", exception.ParamName);
        }

        [Fact]
        public void ShouldNotSaveIfRequestIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => _processor.Book(null!));

            _repositoryMock.Verify(r => r.Save(It.IsAny<TicketBooking>()), Times.Never);
        }
    }
}
