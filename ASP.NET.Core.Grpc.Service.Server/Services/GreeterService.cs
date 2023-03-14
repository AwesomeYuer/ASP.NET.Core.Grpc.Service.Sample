using Contracts;
using Grpc.Core;

namespace ASP.NET.Core.Grpc.Service;

public class GreeterService : Greeter.GreeterBase
{
    private readonly ILogger<GreeterService> _logger;
    public GreeterService(ILogger<GreeterService> logger)
    {
        _logger = logger;
    }

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        HelloReply result = new HelloReply
        {
            Message = $"Hello: {request}"
        };

        _logger.LogInformation($"Logging content:\r\n{result}");

        return
            Task
                .FromResult
                    (
                        result
                    );
    }
}
