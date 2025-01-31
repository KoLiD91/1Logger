using System;
using System.Collections.Generic;

namespace LoggerExample
{
    public class Logger
    {
        private static readonly Lazy<Logger> _instance =
            new Lazy<Logger>(() => new Logger());

        private readonly List<string> _messages;

        public static Logger Instance => _instance.Value;

        private Logger()
        {
            _messages = new List<string>();
        }

        public void Log(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException("Message cannot be empty", nameof(message));

            _messages.Add(message);
            Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
        }

        public IReadOnlyList<string> Messages => _messages.AsReadOnly();
    }

    public class Program
    {
        public static void Main()
        {
            try
            {
                var logger1 = Logger.Instance;
                var logger2 = Logger.Instance;

                Console.WriteLine($"Czy to ta sama instancja? {ReferenceEquals(logger1, logger2)}");
                Console.WriteLine();

                logger1.Log("Pierwszy komunikat z logger1");
                logger2.Log("Drugi komunikat z logger2");
                logger1.Log("Trzeci komunikat z logger1");

                Console.WriteLine("\nWszystkie zarejestrowane komunikaty:");
                foreach (var message in Logger.Instance.Messages)
                {
                    Console.WriteLine($" - {message}");
                }

                logger1.Log("");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\nZłapano oczekiwany wyjątek: {ex.Message}");
            }
        }
    }
}