using System;

namespace TicketBookingCore
{
    // Processor som hanterar bokningsförfrågningar
    public class TicketBookingRequestProcessor
    {
        // Repository används för att spara bokningen
        private readonly ITicketBookingRepository _repository;

        // Repository skickas in via konstruktor för att kunna mockas i tester
        public TicketBookingRequestProcessor(ITicketBookingRepository repository)
        {
            _repository = repository;
        }

        // Tar emot en bokningsförfrågan och returnerar ett svar
        public TicketBookingResponse Book(TicketBookingRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            // Skapar ett TicketBooking-objekt från request
            var booking = new TicketBooking
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };

            // Sparar bokningen i repository
            _repository.Save(booking);

            // Returnerar ett svar med samma information
            return new TicketBookingResponse
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };
        }
    }
}


