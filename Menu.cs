using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamCSharp
{
    class Menu
    {
        private int choice;
        private string answer;

        public void Display()
        {
            Console.Clear();
            Console.WriteLine("\n\t =========================================================       ");
            Console.WriteLine("\t  Автоматизированная система управления словарями                  ");
            Console.WriteLine("\t =========================================================         ");
            Console.WriteLine("\t          1 - Добавить новый словарь                               ");
            Console.WriteLine("\t          2 - Добавить новое слово                                 ");
            Console.WriteLine("\t          3 - Удалить существующее слово                           ");
            Console.WriteLine("\t          4 - Изменить существующее слово                          ");
            Console.WriteLine("\t          5 - Изменить перевод1 существующего слова                ");
            Console.WriteLine("\t          6 - Изменить перевод2 существующего слова                ");
            Console.WriteLine("\t          7 - Удалить перевод1 существующего слова                 ");
            Console.WriteLine("\t          8 - Удалить перевод2 существующего слова                 ");
            Console.WriteLine("\t          9 - Поиск перевода (с возможностью сохранения результата)");
            Console.WriteLine("\t         10 - Посмотреть сохранённые результаты                    ");
            Console.WriteLine("\t         11 - Обновить текстовый файл русско-английского словаря   ");
            Console.WriteLine("\t         12 - Обновить текстовый файл англо-русского словаря       ");
            Console.WriteLine("\t         13 - Посмотреть русско-английский словарь                 ");
            Console.WriteLine("\t         14 - Посмотреть англо-русский словарь                     ");
            Console.WriteLine("\t         15 - Выход из программы                                   ");
            Console.WriteLine("\t =========================================================         ");

        }
        public int GetChoice()
        {
            Console.Write("\n> Выберите нужную операцию: ");
            choice = int.Parse(Console.ReadLine());
            return choice;
        }
        public bool AllowContinue()
        {
            Console.Write("\n> Продолжить (y/n)? - ");
            answer = Console.ReadLine();
            return (answer == "y");
        }
    }
}
