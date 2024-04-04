using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Laboratornaya_10
{
    public class HandTool:Instrument                      //класс internal, потому что он доступен только в этой сборке
    {                                                     //класс public, потому что нужно, чтобы работали тесты
        private string material;

        static string[] materials = {"Дерево","Сталь","Пластик", "Железо"};

        protected string Material { get; set; }
        
        public HandTool() : base()
        {
            Material = "Нет материала";
        }

        public HandTool(string name,  string material): base(name)
        {
            Material = material;
        }

        public override void Show()                           
        {
            base.Show();
            Console.WriteLine($"Материал: {Material}");
        }

        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите материал ручного инструмента");
            Material = Console.ReadLine();
        }

        public override void RandomInit()
        {
            base.RandomInit();
            Material = materials[rnd.Next(materials.Length)];
        }

        public bool Eqals(HandTool other)
        {
            return this.Name == other.Name 
                && this.Material == other.Material;
        }
    }
}
