using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Laboratornaya_10
{
    internal class MeasuringTool:Instrument
    {
        private string units;
        private double accuracy;

        static string[] uni = {"Сантиметры","Миллиметры","Метры","Градусы"};
        static double[] acc = { 1, 0.01, 0.1, 0.5, 0.05 };

        protected string Units { get; set; }
        protected double Accuracy
        {
            get => accuracy;
            set
            {
                if (value < 0)
                    throw new Exception("Точность не может быть отрицательной");
                else if (value > 5.0)
                    throw new Exception("Точность не может быть больше 5 мм");
                else accuracy = value;
            }
        }

        public MeasuringTool() : base()                          //конструкторы
        {
            Units = "Нет единиц измерения";
            Accuracy = 0;
        }


        public MeasuringTool(string name, string units, int accuracy) : base(name)
        {
            Units = units;
            Accuracy = accuracy;
        }

        public override void Show()                                  //для сокрытия имен используем new
        {
            base.Show();
            Console.WriteLine($"Источник питания: {Units}, время работы от аккумулятора: {Accuracy}");
        }

        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите единицы измерения");
            Units = Console.ReadLine();
            Console.WriteLine("Введите точность измерительного инструмента");
            try
            {
                Accuracy = double.Parse(Console.ReadLine());
            }
            catch
            {
                Accuracy = 0;
            }
        }

        public override void RandomInit()
        {
            base.RandomInit();
            Units = uni[rnd.Next(uni.Length)];
            Accuracy = acc[rnd.Next(acc.Length)];
        }

        public bool Eqals(MeasuringTool other)
        {
            return this.Name == other.Name
                && this.Units == other.Units
                && this.Accuracy == other.Accuracy;
        }
    }
}
