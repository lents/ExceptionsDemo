using System;

namespace InnerExceptionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Outer try-catch block to handle higher-level errors
                PerformOperation();
            }
            catch (Exception ex)
            {
                // Display outer exception details along with inner exception details
                Console.WriteLine("Outer Exception caught:");
                Console.WriteLine($"Message: {ex.Message}");

                if (ex.InnerException != null)
                {
                    Console.WriteLine("\nInner Exception details:");
                    Console.WriteLine($"Message: {ex.InnerException.Message}");
                    Console.WriteLine($"Stack Trace: {ex.InnerException.StackTrace}");
                }
            }
        }

        static void PerformOperation()
        {
            try
            {
                // Simulate a lower-level exception (e.g., divide by zero)
                int result = Divide(10, 0);
            }
            catch (DivideByZeroException ex)
            {
                // Wrap the original exception with a more meaningful one
                throw new InvalidOperationException("An error occurred during the operation.", ex);
            }
        }

        static int Divide(int numerator, int denominator)
        {
            return numerator / denominator;  // This will throw DivideByZeroException
        }
    }
}
