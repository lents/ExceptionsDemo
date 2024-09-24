namespace FailFast
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Th();
            Console.WriteLine("Hello, World!");
        }

        static void Th()
        {
            try
            {
                Console.WriteLine("Я в программе");
                Environment.FailFast("Экстренно падаю");
                Console.WriteLine("Я все еще в программе");
            }
            catch (Exception e)
            {
                Console.WriteLine("Я поймал ошибку");
            }
            finally
            {
                Console.WriteLine("Я в finally");
            }
        }
    }
}
