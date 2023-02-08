namespace Converter
{
    internal class Program
    {
        public static string path;
        static void Main()
        {
            Menu();
        }
        public static void Menu()
        {
            Console.WriteLine("Введите путь до файла (вместе с названием) который хотите открыть: \r\n" +
                "------------------------------------------------------------------");
            path = Console.ReadLine();
            Read_Save.Read();
        }
    }
}