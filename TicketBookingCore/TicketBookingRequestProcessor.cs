public class TicketBookingRequestProcessor
{
    private ITicketBookingRepository _repository;

    public TicketBookingRequestProcessor(ITicketBookingRepository repository)
    {
        _repository = repository;
    }

    public TicketBookingRequest Book(TicketBookingRequest request)
    {
        // RED-fasen: returnerar null så testet failar
        return null;
    }
}


