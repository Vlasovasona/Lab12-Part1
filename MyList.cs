using Library_10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Лаба12_часть1
{
    public class MyList<T> where T : IInit, ICloneable, new() //необходимо, чтобы тип T использовал интерфес IInit, ICloneable (т.к. осуществляется клонирование)
    {
        Point<T>? beg = null; //начало двунаправленного списка
        Point<T>? end = null; //конец двунаправленного списка

        sbyte count = 0; //счетчик элементов в списке

        public sbyte Count => count;

        public Point<T> MakeRandomData() //создание элемента типа <T>
        {
            T data = new T(); //должно иметь конструктор без параметров (см. строка 10)
            data.RandomInit(); //рандомно заполняем (см. строка 10)
            return new Point<T>(data); //создаем новый элемент 
        }

        public T MakeRandomItem() //создание информационного поля
        {
            T data = new T();
            data.RandomInit();
            return data;
        }

        public void AddToBegin(T item) //добавление в начало списка
        {
            T newData = (T)item.Clone(); //глубокая копия (чтобы разные структуры данных не ссылались на один и тот же элемент)
            Point<T> newItem = new Point<T>(newData); //создали новый элемент
            count++; //увеличили счетчик
            if (beg != null) //проверка на null
            {
                beg.Pred = newItem; 
                newItem.Next = beg;         //добавление newItem, теперь начало в newItem
                beg = newItem;
            }
            else
            {
                beg = newItem;              
                end = beg;
            }
        }

        public void AddToEnd(T item) //работа метода аналогична методу AddToBegin
        {
            T newData = (T)item.Clone();
            Point<T> newItem = new Point<T>(newData);
            count++;
            if (end != null)
            {
                end.Next = newItem;
                newItem.Pred = end;
                end = newItem;
            }
            else
            {
                beg = newItem;
                end = beg;
            }
        }

        public void AddNodeAtIndex(sbyte index, T item) //добавление элемента по ключу
        {
            Point<T> newNode = new Point<T>(item); //создание нового элемента списка
            Point<T>? current = beg; //текущий элемент - первый
            Point<T>? temp = null; //временная переменная для хранения текущего элемента
            count++; //сразу увеличичваем количество элементов на 1
            int kol = 0; //счетчик
            index--; //уменьшаем на 1, т.к. изначально пользователь вводит место для добавления на один больше, чем нужный индекс
            // Если список пуст, добавляем новый элемент как головной и хвостовой
            if (beg == null) //если список пуст, добавляем item на место первого элемента
            {
                beg = newNode;
                end = newNode;
                return;
            }

            // Переходим к нужному индексу
            while (current != null && kol < index)
            {
                temp = current; //сохраняем текущий элемент как предыдущий
                current = current.Next; //переходим к следующему 
                kol++; 
            }

            // Добавляем новый элемент в середину списка
            if (temp != null)
            {
                temp.Next = newNode; //связываем предудыщий с новым
                newNode.Pred = temp; //связываем новый с предыдущим
                newNode.Next = current; //связываем новый с текущим
                if (current != null) 
                {
                    current.Pred = newNode; //обновляем связь текущего с новым
                }

                // Если добавляем в конец, обновляем хвост
                if (current == null)
                {
                    end = newNode;
                }
            }
            else
            {
                // Добавляем новый элемент в начало списка
                newNode.Next = beg; //связываем текущий с первым
                beg.Pred = newNode; //связываем текущий с новым
                beg = newNode; //обновляем первый элемент
            }
        }

        public MyList() { } //конструктор без параметров

        public MyList(sbyte size) //конструктор с параметром (размер списка)
        {
            if (size <= 0) throw new Exception("Размер не может быть нулевым или отрицательным"); 
            beg = MakeRandomData(); //создали первый элемент
            end = beg; //изначально в списке один элемент, поэтому beg и end установлены на единственном элементе
            for (int i = 1; i < size; i++) //далее заполняем список элементами в количестве size
            {
                T newItem = MakeRandomItem(); //генерируем значение нового элемента
                AddToEnd(newItem); //добавляем его в конец
            }
            count = size; 
        }

        //public MyList(T[] collection) //конструктор на основе коллекции, принцип работы не отличается от конструктора с параметром 
        //{
        //    if (collection == null) throw new Exception("empty collection: null");
        //    if (collection.Length == 0) throw new Exception("empty collection");
        //    T newData = (T)collection[0].Clone();
        //    beg = new Point<T>(newData);
        //    end = beg;
        //    for (int i = 0; i < collection.Length; i++)
        //    {
        //        AddToEnd(collection[i]);
        //    }
        //}

        public void PrintList() //метод для вывода элементов
        {
            if (count == 0) Console.WriteLine("the list is empty");
            Point<T>? current = beg; //присвоили переменной current ссылку на начальный элемент
            for (int i = 0; current != null; i++) //пока не долшли до конца списка
            {
                Console.WriteLine(current); //выводим current
                current = current.Next; //передвигаем current на следующий элемент
            }
        }

        public Point<T>? FindItem(T item) //метод для поиска элемента (знак вопроса означает, что для метода допускается возвращение null)
        {
            Point<T>? current = beg;
            while (current != null)
            {
                if (current.Data == null) throw new Exception("Data is null");
                if (current.Data.Equals(item)) return current; //если элемент найден, возвращаем значение current
                current = current.Next; //иначе передвигаем current на следующий элемент
            }
            return null; //в случае неудачного поиска возращаем значение null
        }

        public bool RemoveItem(sbyte index) //метода для удаления элемента списка по ключу
        {
            if (beg == null) throw new Exception("the empty list"); //проверка на пустоту списка
            count--; //уменьшаем количество элементов в списке на 1
            index--;
            Point<T>? current = beg; 
            int currentIndex = 0;

            //one elemnt
            if (beg == end) //если в списке только один элемент
            {
                beg = end = null; //присваиваем null началу и концу списка (единственному элементу)
                return true; //возвращаем true, операция прошла успешно
            }

            //the first (ситуация, когда удаляется первый элемент)
            if (index == 0) 
            {
                beg = beg?.Next; //начало передвигаем на второй элемент списка
                beg.Pred = null; //для второго (новоиспеченного первого) элемента ссылку на предыдущий ставим на null
                return true; //операция успешна, true
            }

            //the last
            if (index == count)
            {
                end = end.Pred;
                end.Next = null;
                return true;
            }

            while (current != null && currentIndex < index) //поиск удаляемого элемента
            {
                current = current.Next;
                currentIndex++;
            }

            if (current.Next != null) current.Next.Pred = current.Pred;
            if (current.Pred != null) current.Pred.Next = current.Next;
            return true;
        }

        public MyList<T> Clone()
        {
            int size = count;
            if (size <= 0) throw new Exception("Невозможно провести операцию клонирования пустой коллекции"); 
            else
            {
                MyList<T> clone = new MyList<T>();
                Point<T>? current = beg;

                while (current != null)
                {
                    T newData = (T)current.Data.Clone();
                    clone.AddToEnd(newData);
                    current = current.Next;
                }
                return clone;
            }
        } //клонирование списка

        public T GetPointAtIndex(int index) //вспомогательный метод для тестирования добавления элемента в список
        {
            if (index < 0 || index >= count) throw new Exception("Invalid index");
            Point<T>? current = beg;
            int currentIndex = 0;
            while (current != null && currentIndex < index) 
            {
                current = current.Next;
                currentIndex++;
            }
            return current.Data;
        }
    }
}
