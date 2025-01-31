using singleton1;
using System;
using System.Collections.Generic;

namespace LoggerExample
{
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