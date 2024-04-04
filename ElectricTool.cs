using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Laboratornaya_10
{
    internal class ElectricTool:Instrument
    {
        private string powerSupply;
        private int workingTime;

        static string[] supply = {"Электричество"};
        static int[] hours = { 0, 30, 60, 120, 240, 180 };

        protected string PowerSupply { get; set; }
        protected int WorkingTime
        {
            get => workingTime;
            set
            {
                if (value < 0)
                    throw new Exception("Время работы от аккумулятора не может быть отрицательным");
                else workingTime = value;
            }
        }

        public ElectricTool() : base()                          //конструкторы
        {
            PowerSupply = "Нет источника питания";
            WorkingTime = 0;
        }


        public ElectricTool(string name, string powerSupply, int workingTime) : base(name)
        {
            PowerSupply = powerSupply;
            WorkingTime = workingTime;
        }

        public override void Show()                                  //сокрытие имен
        {
            base.Show();
            Console.WriteLine($"Источник питания: {PowerSupply}, время работы от аккумулятора: {WorkingTime}");
        }

        public override void Init()
        {
            base.Init();
            Console.WriteLine("Источник питания электрического инструмента");
            PowerSupply = Console.ReadLine();
            Console.WriteLine("Введите время работы инструмента от аккумулятора в минутах. Если аккумулятора нет, введите 0");
            try
            {
                WorkingTime = int.Parse(Console.ReadLine());
            }
            catch
            {
                WorkingTime = 0;
            }
        }

        public override void RandomInit()
        {
            base.RandomInit();
            PowerSupply = supply[rnd.Next(supply.Length)];
            WorkingTime = hours[rnd.Next(hours.Length)];
        }

        public bool Eqals(ElectricTool other)
        {
            return this.Name == other.Name
                && this.PowerSupply == other.PowerSupply
                && this.WorkingTime == other.WorkingTime;
        }
    }
}
