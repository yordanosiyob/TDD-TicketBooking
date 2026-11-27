# TDD Ticket Booking

A ticket booking core library developed with Test-Driven Development (TDD) in C# and .NET, using xUnit and Moq.

## About
The project was built following the Red-Green-Refactor cycle: a failing test is written first, followed by the minimal implementation needed to pass it, and finally the code is refactored while keeping all tests green. The commit history reflects this process.

## Features
- Processes booking requests and returns a booking response
- Saves bookings through a repository abstraction (`ITicketBookingRepository`)
- Validates input and guards against null dependencies

## Testing
- Unit tests written with xUnit
- The repository is mocked with Moq, so the business logic is tested in isolation without a database
- Tests verify the response values, that the booking is saved exactly once with the correct data, and that invalid input throws the expected exceptions
- All tests run automatically on every push through GitHub Actions

## Tech stack
- C# / .NET 9
- xUnit
- Moq
- GitHub Actions (CI)

## Project structure
- **TicketBookingCore**: business logic and models
- **TicketBookingCore.Tests**: unit tests

## How to run the tests
```bash
dotnet test
```
