using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace singleton1
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
}
