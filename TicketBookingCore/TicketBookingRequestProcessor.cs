public class TicketBookingRequestProcessor
{
    private readonly ITicketBookingRepository _repository;

    public TicketBookingRequestProcessor(ITicketBookingRepository repository)
    {
        _repository = repository;
    }

    public TicketBookingRequest Book(TicketBookingRequest request)
    {
        // GREEN: minsta möjliga för att testet ska fungera
        if (_repository != null)
        {
            _repository.Save(request);
        }

        return request;
    }
}

