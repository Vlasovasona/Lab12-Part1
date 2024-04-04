using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Laboratornaya_10
{
    public class Instrument
    {
        protected string name;

        protected Random rnd = new Random();

        static string[] Names = { "Отвертка", "Молоток", "Пила", "Ключ", "Дрель", "Шлифовальная машина", "Перфоратор", "Линейка", "Штангенциркуль", "Углометр", "Микрометр", "Лобзик", "Разводной ключ", "Ножницы", "Болгарка", "Рубанок", "Топопр", "Плоскогубцы","Рулетка","Динамометр","Кусачки","Утики"};

        protected string Name { get; set; }        

        public Instrument()                     //конструктор без параметров, по умолчанию инструмент отвертка
        {
            Name = "Нет инструмента";
        }
        public Instrument(string name)          //конструктор с параметром
        {
            Name = name;
        }
        //механизм позднего связывания. для каждого класса строится таблица виртуальных методов, там хранится адрес Show. Во время создания объекта
        //в таблицу записывается его адрес. Когда перебираем массив, сначала переходим на объект, а потом в нужную таблицу ВМ и найдем адрес метода Show
        public virtual void Show()                      //виртуальный метод для просмотра, он проверяет на какой объект ссылка типа Instrument ссылается
        {
            Console.WriteLine($"Название инструмента: {Name}");
        }

        public virtual void Init() 
        {
            Console.WriteLine("Введите имя");
            Name = Console.ReadLine();
        }

        public virtual void RandomInit()
        {
            Name = Names[rnd.Next(Names.Length)];
        }

        public bool Eqals(Instrument other)
        {
            return this.Name == other.Name;
        }
    }
}
