using System.Data.Common;
using LinqToDB.Interceptors;

public class AsyncInterceptor : ConnectionInterceptor {
    public override Task ConnectionOpeningAsync(ConnectionEventData eventData, DbConnection connection, CancellationToken cancellationToken)
    {
        Console.WriteLine("Want this to be called");
        return Task.CompletedTask;
    }

    public override void ConnectionOpening(ConnectionEventData eventData, DbConnection connection)
    {
        Console.WriteLine("This is called instead");
    }
}