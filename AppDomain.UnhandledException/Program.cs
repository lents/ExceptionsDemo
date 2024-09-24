using System;

namespace UnhandledExceptionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Subscribe to the unhandled exception event
            AppDomain.CurrentDomain.UnhandledException += GlobalUnhandledExceptionHandler;

            Console.WriteLine("Starting the application...");

            // Trigger an unhandled exception
            throw new InvalidOperationException("This is a test exception!");

            // Note: The program will not reach this point
            Console.WriteLine("Application continues...");
        }

        // Handler for unhandled exceptions
        static void GlobalUnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Exception exception = (Exception)e.ExceptionObject;
            Console.WriteLine("An unhandled exception occurred:");
            Console.WriteLine($"Exception: {exception.Message}");
            Console.WriteLine($"Is the runtime terminating? {e.IsTerminating}");

            // Log the exception to a file, database, or other destination if needed
            // Example: LogToFile(exception);
        }
    }
}
