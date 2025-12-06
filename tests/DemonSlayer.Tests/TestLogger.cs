using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace DemonSlayer.Tests
{
    /// <summary>
    /// A simple logger used only for testing.
    /// It records all log messages so tests can assert logging behavior.
    /// </summary>
    public class TestLogger<T> : ILogger<T>
    {
        public List<string> Messages { get; } = new();

        public IDisposable BeginScope<TState>(TState state) => default!;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception? exception,
            Func<TState, Exception?, string> formatter)
        {
            Messages.Add(formatter(state, exception));
        }
    }
}
