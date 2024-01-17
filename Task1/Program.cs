using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    enum Models { Apple, Asus, Lenovo }
    enum ProcessorTypes { SingleCore, MultiCore }
    enum ProcessorFreqs { _1000MHz, _1500MHz, _2000MHz }
    enum Rams { _4Gb, _8Gb, _16Gb }
    enum HardDisks { _500Gb, _1000Gb, _2000Gb }
    enum vRams { _10Gb, _20Gb, _40Gb }
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Computer> list = new List<Computer>()
            {
                new Computer(1, "Apple", "SingleCore", 1000, 4, 500, 10, 40),
new Computer(2, "Asus", "MultiCore", 1500, 8, 1000, 20, 20),
new Computer(3, "Lenovo", "SingleCore", 2000, 16, 2000, 40, 30),
new Computer(4, "Apple", "MultiCore", 2000, 8, 500, 10, 400),
new Computer(5, "Asus", "SingleCore", 1000, 4, 1000, 20, 50),
new Computer(6, "Lenovo", "MultiCore", 1500, 8, 2000, 40, 100),
new Computer(7, "Apple", "SingleCore", 1000, 4, 500, 10, 10),
new Computer(8, "Asus", "MultiCore", 1500, 8, 1000, 20, 80),
new Computer(9, "Lenovo", "SingleCore", 2000, 16, 2000, 40, 90),
            };


            Console.WriteLine("Укажите тип процессора: SingleCore или MultiCore");
            string processorType = Console.ReadLine();
            List<Computer> computers=(from d in list
                                     where d.ProcessorType == processorType
                                     select d).ToList();
            foreach (var item in computers)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("");

            Console.WriteLine("Укажите объем ОЗУ в ГБ");
            double ram =Convert.ToDouble(Console.ReadLine());
            computers=list.Where(d => d.Ram>= ram).ToList();
            foreach (var item in computers)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("");

            Console.WriteLine("Отсортированный по увеличению стоимости список");
            computers = list.OrderBy(d=>d.Price).ToList();
            foreach (var item in computers)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("");

            Console.WriteLine("Cписок, сгруппированный по типу процессора");
            var groupedComputers = list.GroupBy(d => d.ProcessorType);
            foreach (var item in groupedComputers)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("");

            Console.WriteLine("Самый дешевый и самый дорогой компьютеры");
            var cheapeastComputer = list.Min(d => d.Price);
            var mostExpensiveComputer = list.Max(d => d.Price);
            Console.WriteLine(cheapeastComputer);
            Console.WriteLine(mostExpensiveComputer);
            Console.WriteLine("");

            if (list.Any(d=>d.Count>=30))
            {
                Console.WriteLine("Хотя бы один компьютер в количестве не менее 30 штук существует");
            }
            else
            {
                Console.WriteLine("Нет компьютеров в количестве не менее 30 штук");
            }

            Console.ReadKey();

        }
    }




    public class Computer
    {
        public int Code
        {
            get; set;
        }

        public string Model
        {
            get; set;
        }

        public string ProcessorType
        {
            get; set;
        }

        public double ProcessorFreq
        {
            get;set;
        }

        public double Ram
        {
            get; set;
        }

        public double HardDisk
        {
            get; set;
        }

        public double VRam
        {
            get; set;
        }

        public double Price
        {
            get; set;
        }

        public double Count
        { get; set; }


        public Computer(int code, string model, string processorType, double processorFreq, double ram, double hardDisk, double vRam, double count)
        {
            Code = code;
            Model = model;
            ProcessorType = processorType;
            ProcessorFreq = processorFreq;
            Ram = ram;
            HardDisk = hardDisk;
            VRam = vRam;
            Count = count;
            Price=CalculatePrice(model, processorType, processorFreq, ram, hardDisk, vRam);


        }


        public override string ToString()
        {
            return $"Код - {Code}, Марка компьютера - {Model}, Тип процессора - {ProcessorType}, Частота процессора - {ProcessorFreq} МГц, Объем оперативной памяти - {Ram} ГБ, Объем жесткого диска - {HardDisk} ГБ, Объем памяти видеокарты - {VRam} ГБ, Цена - {Price} у.е., Количество - {Count} штук";
        }

        public int CalculatePrice(string model, string processorType, double processorFreq, double ram, double hardDisk, double vRam)
        {
            int price=0;
            switch (model)
            {
                case "Apple":
                    price += 3;
                    break;
                case "Asus":
                    price += 2;
                    break;
                case "Lenovo":
                    price += 1;
                    break;
            }
            switch (processorType)
            {
                case "SingleCore":
                    price += 1;
                    break;
                case "MultiCore":
                    price += 2;
                    break;
            }
            switch (processorFreq)
            {
                case 1000:
                    price += 1;
                    break;
                case 1500:
                    price += 2;
                    break;
                case 2000:
                    price += 3;
                    break;
            }
            switch (ram)
            {
                case 4:
                    price += 1;
                    break;
                case 8:
                    price += 2;
                    break;
                case 16:
                    price += 3;
                    break;
            }
            switch (hardDisk)
            {
                case 500:
                    price += 1;
                    break;
                case 1000:
                    price += 2;
                    break;
                case 2000:
                    price += 3;
                    break;
            }
            switch (vRam)
            {
                case 10:
                    price += 1;
                    break;
                case 20:
                    price += 2;
                    break;
                case 40:
                    price += 3;
                    break;
            }
            return price;

        }

    }
}
