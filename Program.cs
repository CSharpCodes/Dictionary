using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            bool exit = false;
            string dictionaryName = "";
            string originalWord = "";

            do
            {
                OperationsManager manager = new OperationsManager();
                menu.Display();
                switch (menu.GetChoice())
                {
                    case 1:
                        manager.AddDictionary(manager.InputDictionaryName());
                        break;
                    case 2:
                        dictionaryName = manager.InputDictionaryName();
                        originalWord = manager.InputOriginalWord();
                        Console.Write("  Введите перевод1: ");
                        string translation1 = Console.ReadLine();
                        Console.Write("  Введите перевод2: ");
                        string translation2 = Console.ReadLine();
                        manager.AddWord(dictionaryName, originalWord, translation1, translation2);
                        break;
                    case 3:
                        manager.DelWord(manager.InputDictionaryName(), manager.InputOriginalWord());
                        break;
                    case 4:
                        dictionaryName = manager.InputDictionaryName();
                        originalWord = manager.InputOriginalWord();
                        Console.Write("  Введите новое слово: ");
                        string newOriginalWord = Console.ReadLine();
                        manager.EditWord(dictionaryName, originalWord, newOriginalWord);
                        break;
                    case 5:
                        dictionaryName = manager.InputDictionaryName();
                        originalWord = manager.InputOriginalWord();
                        Console.Write("  Введите новый перевод1: ");
                        string newTranslation1 = Console.ReadLine();
                        manager.EditTranslation1(dictionaryName, originalWord, newTranslation1);
                        break;
                    case 6:
                        dictionaryName = manager.InputDictionaryName();
                        originalWord = manager.InputOriginalWord();
                        Console.Write("  Введите новый перевод2: ");
                        string newTranslation2 = Console.ReadLine();
                        manager.EditTranslation2(dictionaryName, originalWord, newTranslation2);
                        break;
                    case 7:
                        dictionaryName = manager.InputDictionaryName();
                        originalWord = manager.InputOriginalWord();
                        manager.DelTranslation1(dictionaryName, originalWord);
                        break;
                    case 8:
                        dictionaryName = manager.InputDictionaryName();
                        originalWord = manager.InputOriginalWord();
                        manager.DelTranslation2(dictionaryName, originalWord);
                        break;
                    case 9:
                        dictionaryName = manager.InputDictionaryName();
                        originalWord = manager.InputOriginalWord();
                        manager.SearchWord(dictionaryName, originalWord);
                        break;
                    case 10:
                        manager.ReadFromResult();
                        break;
                    case 11:
                        manager.SaveRusEng();
                        break;
                    case 12:
                        manager.SaveEngRus();
                        break;
                    case 13:
                        manager.DisplayRusEng();
                        break;
                    case 14:
                        manager.DisplayEngRus();
                        break;
                    case 15:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("\n>Вы выбрали несуществующий вариант");
                        break;
                }
                if (exit)
                    break;
            } while (menu.AllowContinue());
            Console.WriteLine("\n\nПрограмма завершена");
        }
    }
}
