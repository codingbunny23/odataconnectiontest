using System;
using Microsoft.EntityFrameworkCore;

namespace ODataConnectionError.Helpers;

public class ContextFactory
{
    private static string CONNECTION_STRING;

    public ContextFactory(string connectionString)
    {
        CONNECTION_STRING = connectionString;
    }

    /// <summary>
    /// Creates a context with SqlServer as it's provider.
    /// </summary>
    public T Create<T>() where T : DbContext
    {
        if (string.IsNullOrEmpty(CONNECTION_STRING))
        {
            throw new ArgumentNullException("'database' is null");
        }

        DbContextOptionsBuilder<T> builder = new();
        builder.UseSqlServer(CONNECTION_STRING);
        T context = CreateWithOptions(builder.Options);
        return context;
    }

    public T CreateWithOptions<T>(DbContextOptions<T> options) where T : DbContext
    {
        T? context = Activator.CreateInstance(typeof(T), new object[] { options }) as T;
        if (context == null)
        {
            throw new Exception($"Could not create context of type {typeof(T).Name}");
        }
        return context;
    }
}