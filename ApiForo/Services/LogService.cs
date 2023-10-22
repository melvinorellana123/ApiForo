using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;

namespace ApiForo.Services;

public static class LogService
{
    public static void AddLogger(this IServiceCollection services, IConfiguration Configuration)
    {
        var connectionString =
            Configuration.GetConnectionString("Connection");
        Log.Logger = new LoggerConfiguration()
            .WriteTo.MSSqlServer(connectionString,
                sinkOptions: new MSSqlServerSinkOptions { TableName = "LogEntries", AutoCreateSqlTable = true },
                restrictedToMinimumLevel: LogEventLevel.Information
            ).CreateLogger();

        services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog());
    }
}