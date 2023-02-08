using System.Text.Json;
using System.Xml.Serialization;

namespace Converter
{
    public class Read_Save
    {
        public static List<Figure> figures;
        public static string text;

        public static object JsonConvert { get; private set; }

        public static void Read()
        {
            text = File.ReadAllText(Program.path);
            Console.Clear();
            Console.WriteLine("Чтобы сохранить файл в одном из форматов, введите клавишу F1.\n" +
                              "Чтобы завершить программу нажмите клавишу Escape.");
            if (Program.path.EndsWith(".txt"))
            {
                Console.WriteLine(text);
            }
            if (figures != null)
            {
                foreach (Figure f in figures)
                {
                    Console.WriteLine(f.Name);
                    Console.WriteLine(f.Dimensionality);
                    Console.WriteLine(f.Versatile);
                }
            }
            if (Program.path.EndsWith(".txt"))
            {
                figures = Des_Txt();
            }
            if (Program.path.EndsWith(".json"))
            {
                figures = Des_Json();
            }
            if (Program.path.EndsWith(".xml"))
            {
                figures = Des_Xml();
            }
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.F1)
            {
                Console.Clear();
                Console.WriteLine("Введите путь к файлу, в который хотите сохранить:");
                string path2 = Console.ReadLine();
                if (path2.EndsWith(".json"))
                {
                    Save_Json(path2);
                }
                else if (path2.EndsWith(".xml"))
                {
                    Save_Xml(path2);
                }
                else if (path2.EndsWith(".txt"))
                {
                    Save_Txt(path2);
                }

            }
            if (key.Key == ConsoleKey.Escape)
            {
                Console.WriteLine("Вы успешно закончили программу.");
            }
        }
        private static void Save_Json(string path2)
        {

            if (File.Exists(path2))
            {
                string json = NewMethod();
                File.WriteAllText(path2, json);
                Console.WriteLine("Успешно сохранено!");
            }
  
        }

        private static string NewMethod()
        {
            throw new NotImplementedException();
        }

        private static void Save_Xml(string path2)
        {

            if (File.Exists(path2))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Figure));
                using (FileStream fs = new FileStream(path2, FileMode.OpenOrCreate))
                {
                    xml.Serialize(fs, figures);
                }
                Console.WriteLine("Успешно сохранено!");
            }
            else
            {
                File.Create(path2);
                XmlSerializer xml = new XmlSerializer(typeof(Figure));
                using (FileStream fs = new FileStream(path2, FileMode.OpenOrCreate))
                {
                    xml.Serialize(fs, figures);
                }
                Console.WriteLine("Успешно сохранено!");
            }
        }
        private static void Save_Txt(string path2)
        {
            if (File.Exists(path2))
            {
                string new_text = File.ReadAllText(Program.path);
                File.WriteAllText(path2, new_text);
                Console.WriteLine("Успешно сохранено!");
            }
            else
            {
                File.Create(path2);
                string new_text = File.ReadAllText(Program.path);
                File.WriteAllText(path2, new_text);
Console.WriteLine("Успешно сохранено!");
            }
        }
        private static List<Figure> Des_Txt()
        {
            string[] lines = File.ReadAllLines(Program.path);
            int i;
            List<Figure> figuress = new List<Figure>();
            for (i = 0; i < lines.Length; i += 3)
            {
                figuress.Add(new Figure(lines[i], lines[i + 1], lines[i + 2]));
            }
            return figuress;
        }
        private static List<Figure> Des_Json()
        {
            string text2 = File.ReadAllText(Program.path);
            List<Figure> figuress = JsonSerializer.Deserialize<List<Figure>>(text2);
            return figuress;
        }
        private static List<Figure> Des_Xml()
        {
            Figure figure;
            XmlSerializer xml = new XmlSerializer(typeof(Figure));
            using (FileStream fs = new FileStream(Program.path, FileMode.Open))
            {
                figure = (Figure)xml.Deserialize(fs);
            }
            List<Figure> figuress = new List<Figure>();
            figuress.Add(figure);
            return figuress;
        }

    }
}