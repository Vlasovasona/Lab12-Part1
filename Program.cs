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
            if (list.Count == 0) throw new ArgumentException("empty list"); //если список пуст -> выводим ошибку
            sbyte place = InputSbyteNumber("Введите номер для нового элемента");
            HandTool tool = new HandTool(); //генерируем добавляемый элемент
            tool.RandomInit();
            list.AddNodeAtIndex(place, tool); //добавляем его в список
            Console.WriteLine("Изменим название сгенерированного инструмента:"); //демонстрация того, что на новый элемент нет двойной ссылки
            tool.Name = "RRR";
            Console.WriteLine(tool.ToString());
            Console.WriteLine("Продемонстрируем, что после изменения названия инструмента, элемент, добавленный в список, не изменилася:");
            list.PrintList();
            Console.WriteLine("Операция завершена");
        }

        static void DeleteElementFromList(MyList<Library_10.Instrument> list) //метод удаления элемента из списка
        {
            if (list.Count == 0) throw new ArgumentException("empty list"); //ошибка если список пустой
            sbyte place = InputSbyteNumber("Введите номер для удаляемого элемента");
            list.RemoveItem(place); 
            Console.WriteLine("Операция завершена");
        }

        static void Clear(ref MyList<Library_10.Instrument> list) //метод очищения памяти 
        {
            list = null; 
            GC.Collect(); //метод, который позволяет сборщику мусора выполнить сборку мусора
        }

        static void Main(string[] args)
        {
            sbyte answer1; //объявление переменной, которая отвечает за выбранный пункт меню
            MyList<Library_10.Instrument> list = new MyList<Library_10.Instrument>(); //создание списка
            do
            {
                Console.WriteLine("1. Сформировать двунаправленный список и вывести его на экран"); //меню
                Console.WriteLine("2. Добавить в список элемент с заданным номером");
                Console.WriteLine("3. Вывести список");
                Console.WriteLine("4. Удалить из списка элемент с заданным номером");
                Console.WriteLine("5. Выполнить глубокое копирование списка");
                Console.WriteLine("6. Удалить список из памяти");
                Console.WriteLine("7. Выход");
                answer1 = InputSbyteNumber(); //считываем выбранный пункт меню

                switch (answer1)
                {
                    case 1: //формирование двунаправленного списка и вывод на экран
                        {
                            sbyte size = InputSbyteNumber("Введите размер списка");
                            try
                            {
                                list = new MyList<Library_10.Instrument>(size); //ввод размера списка типа sbyte
                                Console.WriteLine("Список сформирован");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Выполнение провалено: {e.Message}");
                            }
                            break;
                        }
                    case 2: //добавление в список элемента с заданным номером
                        {
                            try
                            {
                                AddElementToList(list);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Processing failed: {e.Message}");
                            }
                            break;
                        }
                    case 3: //вывод списка
                        {
                            try
                            {
                                Console.WriteLine(list.Count);
                                list.PrintList();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Выполнение провалено: {e.Message}");
                            }
                            break;
                        }
                    case 4: //удаление из списка элемента с заданным номером
                        {
                            try
                            {
                                DeleteElementFromList(list);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Выполнение провалено: {e.Message}");
                            }
                            break;
                        }
                    case 5: //глубокое копирование списка
                        {
                            try
                            {
                                MyList<Library_10.Instrument> clone = list.Clone();
                                clone.PrintList();
                                DeleteElementFromList(list);
                                Console.WriteLine("Список после удаления:");
                                list.PrintList();
                                Console.WriteLine("Клон после удаления:");
                                clone.PrintList();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Выполнение провалено: {e.Message}");
                            }
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
            } while (answer1 != 7); //цикл повторяется пока пользователь не введет число 7
        }
    }
}
