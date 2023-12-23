# RabbitMQ Booking System

This application demonstrates a booking system using RabbitMQ to handle message processing and inter-service communication. It is designed to showcase the integration of these technologies within a .NET environment.

## Features

- Booking creation and management.
- RabbitMQ consumer for processing booking messages.
- Support for Unicode characters in passenger names.

## Prerequisites

- .NET Core SDK (version 5.0 or later recommended).
- Docker (for running RabbitMQ containers).
- Access to a RabbitMQ server.

## Setup

1. Clone the repository:
   ```bash
   git clone https://github.com/baal98/RabitMQ-Demo.git
   cd your-repository
   ```

2. RabbitMQ are running. You can use Docker to run these services:
   ```bash
   docker-compose up -d
   ```

3. RabbitMQ configurations in the application as needed.

## Running the Application

1. To build the application, run:
   ```bash
   dotnet build
   ```

2. To start the application, execute:
   ```bash
   dotnet run
   ```

## Usage

- To create a booking, send a POST request to the booking endpoint with the booking details.
- The RabbitMQ consumer will process the message and perform the necessary actions.

## API Endpoints

- `POST /booking` - Create a new booking.

## Contributing

Contributions to this project are welcome. Please refer to the `CONTRIBUTING.md` file for guidelines.

## License

This project is licensed under the MIT License - see the `LICENSE` file for details.