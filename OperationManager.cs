using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

namespace ExamCSharp
{
    class OperationsManager
    {
        private string path;
        private XDocument doc;
        private XElement root;
        public OperationsManager()
        {
            path = @"..\..\data\dictionary.xml";
            doc = XDocument.Load(path);
            root = doc.Element("catalog");
        }
        private void DisplayAllDictionaries()
        {
            int k = 0;
            var dictionaries = root.Elements("dictionary").ToList();
            Console.WriteLine("\n  Список всех словарей:");
            foreach (var dictionary in dictionaries)
                Console.WriteLine($"  {++k}. {dictionary.Attribute("name").Value}");
            Console.WriteLine();
        }
        private XElement GetDictionary(string dictionaryName)
        {
            return root.Elements("dictionary")
                .Where(c => c.Attribute("name").Value == dictionaryName)
                .FirstOrDefault();
        }
        private XElement GetWord(XElement dictionary, string originalWord)
        {
            var word = dictionary.Elements("word")
            .Where(p => p.Attribute("original").Value == originalWord)
            .FirstOrDefault();
            return word;
        }
        public string InputDictionaryName()
        {
            DisplayAllDictionaries();
            Console.Write("  Введите название словаря: ");
            return Console.ReadLine();
        }
        public string InputOriginalWord()
        {
            Console.Write("  Введите слово для перевода: ");
            return Console.ReadLine();
        }
        public string InputTranslation1()
        {
            Console.Write("  Введите перевод1: ");
            return Console.ReadLine();
        }
        public void AddDictionary(string dictionaryName)
        {
            if (GetDictionary(dictionaryName) != null)
                Console.WriteLine("  Такой словарь уже существует");
            else
            {
                root.Add(new XElement("dictionary",
                    new XAttribute("name", dictionaryName)));
                doc.Save(path);
                Console.WriteLine("  Словарь успешно добавлен");
            }
        }
        public void AddWord(string dictionaryName, string originalWord, string translation1, string translation2)
        {
            var dictionary = GetDictionary(dictionaryName);
            if (dictionary == null)
                Console.WriteLine("  Данный словарь не существует");
            else
            {
                var word = GetWord(dictionary, originalWord);
                if (word != null)
                    Console.WriteLine("  Данное слово уже существует");
                else
                {
                    dictionary.Add(new XElement("word",
                        new XAttribute("original", originalWord),
                        new XAttribute("translation1", translation1),
                        new XAttribute("translation2", translation2)));
                        doc.Save(path);
                        Console.WriteLine("  Слово успешно добавлено");
                }
            }
        }
        public void DelWord(string dictionaryName, string originalWord)
        {
            var dictionary = GetDictionary(dictionaryName);
            if (dictionary == null)
                Console.WriteLine("  Данный словарь не существует");
            else
            {
                var word = GetWord(dictionary, originalWord);
                if (word == null)
                    Console.WriteLine("  Данное слово не существует");
                else
                {
                    word.Remove();
                    doc.Save(path);
                    Console.WriteLine("  Слово успешно удалёно");
                }
            }

        }

        public void DelTranslation1(string dictionaryName, string originalWord)
        {
            var dictionary = GetDictionary(dictionaryName);
            if (dictionary == null)
                Console.WriteLine("  Данный словарь не существует");
            else
            {
                var word = GetWord(dictionary, originalWord);
                if (word == null)
                    Console.WriteLine("  Данное слово не существует");
                else
                {
                    if (word.Attribute("translation2") != null && word.Attribute("translation2").Value != "")
                    {
                        if (word.Attribute("translation1") == null)
                            Console.WriteLine("  Перевод2 отсутствует для данного слова");
                        else
                        {
                            word.Attribute("translation1").Remove();
                            doc.Save(path);
                            Console.WriteLine("  Перевод успешно удалён");
                        }
                    }
                    else
                        Console.WriteLine("  Это единственный перевод и его нельзя удалить");
                }
            }

        }
        public void DelTranslation2(string dictionaryName, string originalWord)
        {
            var dictionary = GetDictionary(dictionaryName);
            if (dictionary == null)
                Console.WriteLine("  Данный словарь не существует");
            else
            {
                var word = GetWord(dictionary, originalWord);
                if (word == null)
                    Console.WriteLine("  Данное слово не существует");
                else
                {
                    if (word.Attribute("translation1") != null && word.Attribute("translation1").Value != "")
                    {
                        if (word.Attribute("translation2") == null)
                            Console.WriteLine("  Перевод2 отсутствует для данного слова");
                        else
                        {
                            word.Attribute("translation2").Remove();
                            doc.Save(path);
                            Console.WriteLine("  Перевод успешно удалён");
                        }
                    }
                    else
                        Console.WriteLine("  Это единственный перевод и его нельзя удалить");
                }
            }

        }

        public void EditWord(string dictionaryName, string originalWord, string newOriginalWord)
        {
            var dictionary = GetDictionary(dictionaryName);
            if (dictionary == null)
                Console.WriteLine("  Данный словарь не существует");
            else
            {
                var word = GetWord(dictionary, originalWord);
                if (word == null)
                    Console.WriteLine("  Данное слово не существует");
                else
                {
                        word.Attribute("original").Value = newOriginalWord.ToString();
                        doc.Save(path);
                        Console.WriteLine("  Слово успешно изменено");
                }
            }

        }

        public void EditTranslation1(string dictionaryName, string originalWord, string newTranslation1)
        {
            var dictionary = GetDictionary(dictionaryName);
            if (dictionary == null)
                Console.WriteLine("  Данный словарь не существует");
            else
            {
                var word = GetWord(dictionary, originalWord);
                if (word == null)
                    Console.WriteLine("  Данное слово не существует");
                else
                {
                    if (word.Attribute("translation1") == null)
                        Console.WriteLine("  Перевод1 отсутствует для данного слова");
                    else
                    {
                        word.Attribute("translation1").Value = newTranslation1.ToString();
                        doc.Save(path);
                        Console.WriteLine("  Перевод слова успешно изменен");
                    }
                }
            }

        }
        public void EditTranslation2(string dictionaryName, string originalWord, string newTranslation2)
        {
            var dictionary = GetDictionary(dictionaryName);
            if (dictionary == null)
                Console.WriteLine("  Данный словарь не существует");
            else
            {
                var word = GetWord(dictionary, originalWord);
                if (word == null)
                    Console.WriteLine("  Данное слово не существует");
                else
                {
                    if (word.Attribute("translation2") == null)
                        Console.WriteLine("  Перевод2 отсутствует для данного слова");
                    else
                    {
                        word.Attribute("translation2").Value = newTranslation2.ToString();
                        doc.Save(path);
                        Console.WriteLine("  Перевод слова успешно изменен");
                    }
                }
            }

        }
        public void SearchWord(string dictionaryName, string originalWord)
        {
            var dictionary = GetDictionary(dictionaryName);
            if (dictionary == null)
                Console.WriteLine("  Данный словарь не существует");
            else
            {
                var word = GetWord(dictionary, originalWord);
                if (word != null)
                {
                    if (word.Attribute("translation1") == null)
                    {
                        Console.WriteLine($"\n  Слово: {word.Attribute("original").Value}, " +
                        $"перевод: {word.Attribute("translation2").Value}");
                        Console.Write("  Для записи результата в файл нажмите клавишу 's': ");
                        string buf = Console.ReadLine();
                        if (buf == "s")
                        {
                            string path1 = @"..\..\result.txt";
                            using (FileStream fs1 = new FileStream(path1, FileMode.Append, FileAccess.Write))
                            {
                                using (StreamWriter sw = new StreamWriter(fs1))
                                {
                                    sw.WriteLine($"  Слово: {word.Attribute("original").Value}, " +
                                $"перевод: {word.Attribute("translation2").Value}");
                                }
                            }
                            Console.WriteLine("  Запись в файл успешно выполнена\n");
                        }
                    }
                    else if(word.Attribute("translation2") == null)
                    {
                        Console.WriteLine($"\n  Слово: {word.Attribute("original").Value}, " +
                    $"перевод: {word.Attribute("translation1").Value}");
                        Console.Write("  Для записи результата в файл нажмите клавишу 's': ");
                        string buf = Console.ReadLine();
                        if (buf == "s")
                        {
                            string path1 = @"..\..\result.txt";
                            using (FileStream fs1 = new FileStream(path1, FileMode.Append, FileAccess.Write))
                            {
                                using (StreamWriter sw = new StreamWriter(fs1))
                                {
                                    sw.WriteLine($"  Слово: {word.Attribute("original").Value}, " +
                                $"перевод: {word.Attribute("translation1").Value}");
                                }
                            }
                            Console.WriteLine("  Запись в файл успешно выполнена\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"\n  Слово: {word.Attribute("original").Value}, " +
                    $"перевод1: {word.Attribute("translation1").Value}, " +
                    $"перевод2: {word.Attribute("translation2").Value}");
                        Console.Write("  Для записи результата в файл нажмите клавишу 's': ");
                        string buf = Console.ReadLine();
                        if (buf == "s")
                        {
                            string path1 = @"..\..\result.txt";
                            using (FileStream fs1 = new FileStream(path1, FileMode.Append, FileAccess.Write))
                            {
                                using (StreamWriter sw = new StreamWriter(fs1))
                                {
                                    sw.WriteLine($"  Слово: {word.Attribute("original").Value}, " +
                                $"перевод1: {word.Attribute("translation1").Value}, " +
                                $"перевод2: {word.Attribute("translation2").Value}");
                                }
                            }
                            Console.WriteLine("  Запись в файл успешно выполнена\n");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("  Данное слово не существует");
                }
            }

        }

        public void ReadFromResult()
        {
            string path1 = @"..\..\result.txt";
            using (FileStream fs1 = new FileStream(path1, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs1))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
        }
        public void SaveRusEng()
        {
            var dictionary = root.Elements("dictionary")
                .Where(c => c.Attribute("name").Value == "Русско-английский")
                .FirstOrDefault();
            int k = 0;
            string path1 = @"..\..\RusEngDictionary.txt";
            using (FileStream fs1 = new FileStream(path1, FileMode.Open, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs1))
                {
                    sw.WriteLine("\n  Русско-английский словарь");
                    sw.WriteLine("  =========================");
                    foreach (var p in dictionary.Elements("word").ToList())
                    {
                        if (dictionary.Element("word").Attribute("translation1") == null)
                        {
                            sw.WriteLine($"  {++k}. Слово: {p.Attribute("original").Value}, перевод: {p.Attribute("translation2").Value}");
                        }
                        else if (dictionary.Element("word").Attribute("translation2") == null)
                        {
                            sw.WriteLine($"  {++k}. Слово: {p.Attribute("original").Value}, перевод: {p.Attribute("translation1").Value}");
                        }
                        else
                        {
                            sw.WriteLine($"  {++k}. Слово: {p.Attribute("original").Value}, перевод1: {p.Attribute("translation1").Value}, перевод2: {p.Attribute("translation2").Value}");
                        }
                    }
                }
            }
            Console.WriteLine("\n  Файл успешно обновлен");
        }
        public void SaveEngRus()
        {
            var dictionary = root.Elements("dictionary")
                .Where(c => c.Attribute("name").Value == "Англо-русский")
                .FirstOrDefault();
            int k = 0;
            string path1 = @"..\..\EngRusDictionary.txt";            
            using (FileStream fs1 = new FileStream(path1, FileMode.Open, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs1))
                {
                    sw.WriteLine("\n  Англо-русский словарь");
                    sw.WriteLine("  =====================");
                    foreach (var p in dictionary.Elements("word").ToList())
                    {
                        if (p.Attribute("translation1") == null)
                        {
                            sw.WriteLine($"  {++k}. Слово: {p.Attribute("original").Value}, перевод: {p.Attribute("translation2").Value}");
                        }
                        else if (p.Attribute("translation2") == null)
                        {
                            sw.WriteLine($"  {++k}. Слово: {p.Attribute("original").Value}, перевод: {p.Attribute("translation1").Value}");
                        }
                        else
                        {
                            sw.WriteLine($"  {++k}. Слово: {p.Attribute("original").Value}, перевод1: {p.Attribute("translation1").Value}, перевод2: {p.Attribute("translation2").Value}");
                        }
                    }

                }
            }
            Console.WriteLine("\n  Файл успешно обновлен");
        }
        public void DisplayRusEng()
        {
            string path1 = @"..\..\RusEngDictionary.txt";
            using (FileStream fs1 = new FileStream(path1, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs1))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
        }
        public void DisplayEngRus()
        {
            string path1 = @"..\..\EngRusDictionary.txt";
            using (FileStream fs1 = new FileStream(path1, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs1))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
        }
    }
}
