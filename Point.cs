using Library_10;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба12_часть1
{
    public class Point<T> where T: IInit, new()
    {
        public T? Data { get; set; }
        public Point<T>? Next {  get; set; }
        public Point<T>? Pred { get; set; }

        public static Point<T> MakeRandomData() //создание элемента типа <T>
        {
            T data = new T(); //должно иметь конструктор без параметров 
            data.RandomInit(); //рандомно заполняем 
            return new Point<T>(data); //создаем новый элемент 
        }

        public static T MakeRandomItem() //создание информационного поля
        {
            T data = new T();
            data.RandomInit();
            return data;
        }

        public Point()
        {
            this.Data = default(T); //если мы подставим сюда ссылку, то будет null, иначе (если значимый тип) будет присвоено 0
            this.Next = null;
            this.Pred = null;
        }

        public Point(T data)
        {
            this.Data = data;
            this.Next = null;
            this.Pred = null;
        }

        public override string ToString() //преобразование элемента типа Point в строку 
        {
            return Data == null ? "" : Data.ToString(); //проверка на null (если Data пустая, будет возвращена пустая строка)
        }
    }
}
