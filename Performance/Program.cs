using System.Diagnostics;

namespace ExceptionHandlingPerformanceDemo
{
    class Program
        {
            static void Main(string[] args)
            {
                const int iterations = 100000;

                // Benchmark with exception handling
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                HandleWithExceptions(iterations);
                stopwatch.Stop();
                Console.WriteLine($"With exceptions: {stopwatch.ElapsedMilliseconds} ms, Memory usage: {GC.GetTotalMemory(false)} bytes");

                // Force garbage collection to reset memory
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();

                // Benchmark without exceptions (using if-checks)
                stopwatch.Restart();
                HandleWithIfChecks(iterations);
                stopwatch.Stop();
                Console.WriteLine($"With if-checks: {stopwatch.ElapsedMilliseconds} ms, Memory usage: {GC.GetTotalMemory(false)} bytes");
            }

            // Simulate exception handling scenario
            static void HandleWithExceptions(int iterations)
            {
                for (int i = 0; i < iterations; i++)
                {
                    try
                    {
                        PerformDivisionWithException(i);
                    }
                    catch (DivideByZeroException)
                    {
                        // Handle exception, but do nothing for the purpose of this demo
                    }
                }
            }

            // Simulate if-check scenario to avoid exceptions
            static void HandleWithIfChecks(int iterations)
            {
                for (int i = 0; i < iterations; i++)
                {
                    PerformDivisionWithIfCheck(i);
                }
            }

            // Method that throws an exception for a divide-by-zero case
            static int PerformDivisionWithException(int divisor)
            {
                return 10 / divisor;  // This will throw DivideByZeroException when divisor is 0
            }

            // Method that avoids exceptions by checking divisor first
            static int PerformDivisionWithIfCheck(int divisor)
            {
                if (divisor == 0)
                {
                    // Handle the zero case, returning a default value
                    return 0;
                }
                return 10 / divisor;
            }
        }
    }

