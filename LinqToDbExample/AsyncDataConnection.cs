using LinqToDB.Configuration;
using LinqToDB.Data;

public class AsyncDataConnection : DataConnection {
    public AsyncDataConnection(LinqToDBConnectionOptions<AsyncDataConnection> options) : base(options)
    {
    }
}