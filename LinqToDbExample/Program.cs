using System.Data.SqlClient;
using LinqToDB.AspNet;
using LinqToDB.Configuration;
using LinqToDB.Data;
using Microsoft.Extensions.DependencyInjection;

const string connectionString = "Server=localhost;Database=tempdb;User Id=sa;Password=BadPassword!";

await using var setupConnection = new SqlConnection(connectionString);
await setupConnection.OpenAsync();
var setupScript = await File.ReadAllTextAsync("setup.sql");
await using var sqlCommand = new SqlCommand(setupScript, setupConnection);
await sqlCommand.ExecuteNonQueryAsync();
await setupConnection.CloseAsync();

var services = new ServiceCollection()
    .AddLinqToDBContext<AsyncDataConnection>((services, builder) => {
        builder.UseSqlServer(connectionString)
            .WithInterceptor(new AsyncInterceptor());
    })
    .BuildServiceProvider();

await using var dataConnection = services.GetRequiredService<AsyncDataConnection>();
await dataConnection.QueryProcAsync<Test>("dbo.GetStuff");

public record Test(string Message);