using Library_10;
using Лаба12_часть1;

namespace Первая_часть
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CloneExceptionListTest() //тест для проверки ошибки при попытке создания клона пустого списка
        {
            MyList<Library_10.Instrument> list = new MyList<Library_10.Instrument>();
            Assert.ThrowsException<Exception>(() => { list.Clone(); });
        }

        [TestMethod]
        public void AddToBeginTest() //тестирование доавления в начало заполненного списка 
        {
            MyList<Library_10.Instrument> list = new MyList<Library_10.Instrument>(2);
            Instrument tool = new Instrument();
            list.AddToBegin(tool);
            Library_10.Instrument addedValue = list.GetPointAtIndex(0);
            Assert.AreEqual(tool, addedValue);
        }

        [TestMethod]
        public void AddToBeginToEmptyListTest() //тестирование добавления в начало пусттого списка
        {
            MyList<Library_10.Instrument> list = new MyList<Library_10.Instrument>();
            Instrument tool = new Instrument();
            list.AddToBegin(tool);
            Library_10.Instrument addedValue = list.GetPointAtIndex(0);
            Assert.AreEqual(tool, addedValue);
        }

        [TestMethod]
        public void AddNodeAtIndexTest() //проверка добавления по индексу в середину заполненного списка
        {
            MyList<Library_10.Instrument> list = new MyList<Library_10.Instrument>(5);
            Instrument tool = new Instrument();
            list.AddNodeAtIndex(3,tool);
            Library_10.Instrument addedValue = list.GetPointAtIndex(2); //индекс третьего елемента равен двум
            Assert.AreEqual(addedValue, tool);
        }

        [TestMethod]
        public void AddNodeAtIndexTestToEmptyListTest() //проверка добавления по индексу в пустой список
        {
            MyList<Library_10.Instrument> list = new MyList<Library_10.Instrument>();
            Instrument tool = new Instrument();
            list.AddNodeAtIndex(1, tool);
            Library_10.Instrument addedValue = list.GetPointAtIndex(0);
            Assert.AreEqual(tool, addedValue);
        }

        [TestMethod]
        public void AddNodeAtIndexToEndListTest() //проверка добавления по индексу в конец заполненного списка
        {
            MyList<Library_10.Instrument> list = new MyList<Library_10.Instrument>(6);
            Instrument tool = new Instrument();
            list.AddNodeAtIndex(7, tool);
            Library_10.Instrument addedValue = list.GetPointAtIndex(6); //проверяем седьмой элемент, у него индекс равен 6
            Assert.AreEqual(tool, addedValue);
        }

        [TestMethod]
        public void AddNodeAtIndexToBegListTest() //проверка добавления по индексу в начало заполненного списка
        {
            MyList<Library_10.Instrument> list = new MyList<Library_10.Instrument>(6);
            Instrument tool = new Instrument();
            list.AddNodeAtIndex(1, tool);
            Library_10.Instrument addedValue = list.GetPointAtIndex(0);
            Assert.AreEqual(tool, addedValue);
        }

        [TestMethod]
        public void AddToEndToEmptyListTest() //проверка на добавление элемента в конец пустого списка
        {
            MyList<Library_10.Instrument> list = new MyList<Library_10.Instrument>();
            Instrument tool = new Instrument();
            list.AddToEnd(tool);
            Library_10.Instrument addedValue = list.GetPointAtIndex(0);
            Assert.AreEqual(tool, addedValue);
        }

        [TestMethod]
        public void PointStringTest() //проверка метода ToString для Point<T>
        {
            int value = 5;
            Point<int> node = new Point<int>(value);
            Assert.AreEqual("5", node.ToString());
        }

        [TestMethod]
        public void PointEmptyStringTest() //проверка метода ToString для пустого Point
        {
            Point<int> node = new Point<int>();
            Assert.AreEqual("0", node.ToString());
        }

        [TestMethod]
        public void ListConstructException() //проверка исключения констркутора списка при попытке создать пустой список
        {
            Assert.ThrowsException<Exception>(() => {
                MyList<Library_10.Instrument> list = new MyList<Library_10.Instrument>(0);
            });
        }

        [TestMethod]
        public void RemoveAtIndexTest() //метод для проверки удаления элемента из середины заполненного списка
        {
            MyList<Library_10.Instrument> list = new MyList<Library_10.Instrument>(5);
            Library_10.Instrument deletedValue = list.GetPointAtIndex(2);
            list.RemoveItem(3);
            Assert.IsNull(list.FindItem(deletedValue)); //если метод FindItem возвращает null, значит элемент удален 
        }

        [TestMethod]
        public void RemoveAtIndexOneElementTest() //проверка удаления элемента из списка из одного элемента
        {
            MyList<Library_10.Instrument> list = new MyList<Library_10.Instrument>(1);
            Library_10.Instrument deletedValue = list.GetPointAtIndex(0);
            list.RemoveItem(1);
            Assert.IsNull(list.FindItem(deletedValue)); //если метод FindItem возвращает null, значит элемент удален 
        }

        [TestMethod]
        public void RemoveAtIndexFromEndListTest() //метод для проверки удаления эелмента из конца заполненного списка
        {
            MyList<Library_10.Instrument> list = new MyList<Library_10.Instrument>(3);
            Library_10.Instrument deletedValue = list.GetPointAtIndex(2); //получаем value последнего элемента 
            list.RemoveItem(3); //удаляем последний элемент 
            Assert.IsNull(list.FindItem(deletedValue)); //если метод FindItem возвращает null, значит элемент удален 
        }

        [TestMethod]
        public void RemoveAtIndexFromBegListTest() //метод для проверки удаления элемента из начала списка 
        {
            MyList<Library_10.Instrument> list = new MyList<Library_10.Instrument>(4);
            Library_10.Instrument deletedValue = list.GetPointAtIndex(0); //получаем value первого элемента 
            list.RemoveItem(1);
            Assert.IsNull(list.FindItem(deletedValue)); //если метод FindItem возвращает null, значит элемент удален 
        }

        [TestMethod]
        public void RemoveToEmptyListTest() //проверка исключения при попытке удаления 6 элемента из пустого списка
        {
            MyList<Library_10.Instrument> list = new MyList<Library_10.Instrument>();
            Assert.ThrowsException<Exception>(() => { list.RemoveItem(6); });
        }
    }
}