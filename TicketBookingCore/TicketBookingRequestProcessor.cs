namespace TicketBookingCore
{
    public class TicketBookingRequestProcessor
    {
        private readonly ITicketBookingRepository _repository;

        // The repository is injected so it can be mocked in tests
        public TicketBookingRequestProcessor(ITicketBookingRepository repository)
        {
            _repository = repository;
        }

        public TicketBookingResponse Book(TicketBookingRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var booking = new TicketBooking
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };

            _repository.Save(booking);

            return new TicketBookingResponse
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };
        }
    }
}
