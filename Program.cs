using System.Collections;
using System.Diagnostics.Metrics;
using Library_10;
using System.Collections.Generic;
namespace Лаба12_часть1
{
    internal class Program
    {
        static sbyte InputSbyteNumber(string msg = "Введите число")  //функция для проверки введенного числа на тип sbyte
        {
            Console.WriteLine(msg); //вывод сообщения msg
            bool isConvert; //объявление переменной, отвечающей за проверку на корректность
            sbyte number; //переменная, которой будет присвоено корректно введенное число
            do
            {
                isConvert = sbyte.TryParse(Console.ReadLine(), out number); //проверка на принадлежность типу sbyte
                if (!isConvert) Console.WriteLine("Неправильно введено число. Возможно вы ввели слишком длинное число. Попробуйте заново"); //в случае провала, вывод сообщения о некорректном вводе числа
            } while (!isConvert); //повторение цикла до тех пор, пока пользователь не введет корректное число
            return number; //ф-ция принимает значение введенного корректного числа
        }

        static void AddElementToList(MyList<Library_10.Instrument> list) //функция добавления нового элемента в список
        {
            sbyte place = InputSbyteNumber("Введите номер для нового элемента");
            Library_10.Instrument tool = new Library_10.Instrument();
            tool.RandomInit();
            if (place == 0 || place > list.Count+1) throw new Exception("Неправильно введено число");
            else list.AddNodeAtIndex(place, tool);
            Console.WriteLine("Операция завершена");
        }

        static void DeleteElementFromList(MyList<Library_10.Instrument> list) //метод удаления элемента из списка
        {
            sbyte place = InputSbyteNumber("Введите номер для удаляемого элемента");
            if (list.Count == 0) throw new Exception("Операция удаления для пустого списка невозможна");
            if (place == 0 || place > list.Count) throw new Exception("Неправильно введено число");
            else list.RemoveItem(place);
            Console.WriteLine("Операция завершена");
        }

        static void Clear(ref MyList<Library_10.Instrument> list) //метод очищения памяти 
        {
            list = null; 
            GC.Collect(); //метод, который позволяет сборщику мусора выполнить сборку 
        }

        static void Main(string[] args)
        {
            sbyte answer3, answerGlobal, answer1, answer2; //объявление переменных, которые отвечают за выбранный пункт меню
            MyList<Library_10.Instrument> list = new MyList<Library_10.Instrument>();
            do
            {
                Console.WriteLine("1. Сформировать двунаправленный список и вывести его на экран");
                Console.WriteLine("2. Добавить в список элемент с заданным номером");
                Console.WriteLine("3. Вывести список");
                Console.WriteLine("4. Удалить из списка элемент с заданным номером");
                Console.WriteLine("5. Выполнить глубокое копирование списка");
                Console.WriteLine("6. Удалить список из памяти");
                Console.WriteLine("7. Выход");
                answer1 = InputSbyteNumber();

                switch (answer1)
                {
                    case 1: //формирование двунаправленного списка и вывод на экран
                        {
                            sbyte size = InputSbyteNumber("Введите размер списка");
                            list = new MyList<Library_10.Instrument>(size); //ввод размера списка типа sbyte
                            Console.WriteLine("Список сформирован");
                            break;
                        }
                    case 2: //добавление в список элемента с заданным номером
                        {
                            AddElementToList(list);
                            break;
                        }
                    case 3: //вывод списка
                        {
                            Console.WriteLine(list.Count);
                            list.PrintList();
                            break;
                        }
                    case 4: //удаление из списка элемента с заданным номером
                        {
                            DeleteElementFromList(list);
                            break;
                        }
                    case 5: //глубокое копирование списка
                        {
                            MyList<Library_10.Instrument> clone = list.Clone();
                            clone.PrintList();
                            DeleteElementFromList(list);
                            Console.WriteLine("Список после удаления:");
                            list.PrintList();
                            Console.WriteLine("Клон после удаления:");
                            clone.PrintList();
                            break;
                        }
                    case 6: //удаление списка из памяти
                        {
                            Clear(ref list); //даем доступ к той области памяти, в которой находидтя список и очищаем ее
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("Демонстрация завершена");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Неправильно задан пункт меню");
                            break;
                        }
                }
            } while (answer1 != 7); //цикл повторяется пока пользователь не введет число 6
        }
    }
}
