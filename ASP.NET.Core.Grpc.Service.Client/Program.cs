using Contracts;
using Grpc.Net.Client;

// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("https://localhost:7031");
var client = new Greeter.GreeterClient(channel);
var input = string.Empty;

Console.WriteLine(@"Press ""q"" to exit...");
while ("q" != (input = Console.ReadLine()))
{
    var reply = await client
                            .SayHelloAsync
                                (
                                    new HelloRequest
                                    {
                                        Name = input
                                    }
                                );
    Console.WriteLine("Greeting: " + reply.Message);
}

