# Receipt Processor

This Receipt Processor API was made with ASP.NET.

## API Details

This project is a solution to the Receipt Processor Challenge, found here:
https://github.com/fetch-rewards/receipt-processor-challenge

Included in this project are example Bruno requests. These can be run with the Bruno API client or Bruno CLI, found here https://www.usebruno.com/

## How to run

### Docker
To run via Docker, navigate to the root and run
`docker build -t ReceiptProcessorApi .`
to build the image.

Run

`docker run -it --rm -p <hostport>:8080 --name ReceiptServer ReceiptProcessorApi`

to start up the server. Internally, the URL of the ReceiptServer will be `http://localhost:8080`.

### Local

To run locally, run
`dotnet run`
within the ReceiptProcessorApi directory. This will run the server with default settings. The URL will be
`http://localhost:80`