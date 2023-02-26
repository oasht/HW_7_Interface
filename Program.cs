using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using System.Collections;
using System.CodeDom;
using HW_7_Interface;
using System.Xml.Linq;

namespace HW_7_Interface
{
    class Good : IComparable
    {
        public string name { get; set; }
        public double weight { get; set; }
        public DateTime prod_date { get; set; }
        public double price { get; set; }

        public int CompareTo(object obj)
        {
            if (obj is Good) { return name.CompareTo((obj as Good).name); }
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"Product: {name}, weight: {weight}, production date {prod_date.ToShortDateString()}, price {price}";
        }
    }
    //class Class_price : IComparer
    //{
    //    public int Compare(object x, object y)
    //    {
    //        if (x is Good && y is Good) { return double.Compare((x as Good).price, (y as Good).price); }
    //        throw new NotImplementedException();
    //    }
    //}

    class Sort_price : IComparer<Good>
    {
        public int Compare(Good x, Good y) { if (x.price < y.price) return -1; else if (x.price > y.price) return 1; else return 0; }
    }
    class Sort_weight : IComparer<Good>
    {
        public int Compare(Good x, Good y) { if (x.weight < y.weight) return -1; else if (x.weight > y.weight) return 1; else return 0; }
    }
    class Class_Prod_date : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Good && y is Good) { return DateTime.Compare((x as Good).prod_date, (y as Good).prod_date); }
            throw new NotImplementedException();
        }
    }

    //class Class_Weight : IComparer
    //{
    //    public int Compare(object x, object y)
    //    {
    //        if (x is Good && y is Good) { return Compare((x as Good).weight, (y as Good).weight); }
    //        throw new NotImplementedException();
    //    }
    //}


    class Shop : IEnumerable
    {
        Good[] goods =
                    {
        new Good
        {
            name="Milk",
            weight =0.8,
            prod_date =new DateTime(2023,2,12),
            price = 60.50
        },
        new Good
        {
            name="Bread",
            weight =0.5,
            prod_date =new DateTime(2023,2,20),
            price = 40.56
        },

        
        new Good
        {
            name="Soap",
            weight =0.2,
            prod_date =new DateTime(2023,2,01),
            price = 80.44
        },

        new Good
        {
            name = "Eggs",
            weight = 0.7,
            prod_date = new DateTime(2023, 2, 16),
            price =132.22
        }

};

        public IEnumerator GetEnumerator()
        {
            return goods.GetEnumerator();
        }

        public void Sort()
        {
            Array.Sort(goods);
        }
        public void Sort(IComparer comp) { Array.Sort(goods, comp); }
        public void Sort_price() { Array.Sort(goods, new Sort_price()); }
        public void Sort_weight() { Array.Sort(goods, new Sort_weight()); }
    }



    class Program
    {
        static void Main(string[] args)
        {

            string q = "1";
            int digit;
            
            do
            {
                Shop shop = new Shop();

                Clear();
                WriteLine($"List of goods:\n");
                foreach (Good item in shop)
                { WriteLine(item); }
                WriteLine("\n\nPlease choose action:\n\n1 - sort by name\n2 - sort by price\n3 - sort by date\n4 - sort by weight\n");
                try
                {
                    digit = Convert.ToInt32(ReadLine());
                }
                catch (Exception)
                {
                    WriteLine("Error, input just number!!!");
                    WriteLine("Press Enter");
                    ReadLine();
                    continue;
                }

                switch (digit)
                {

                    case 1:
                        { 

                            WriteLine("\n***************************SORTED BY NAME***************************\n");
                            shop.Sort();
                            foreach (Good item in shop)
                            { WriteLine(item); }
                        }
                        break;
                    case 2:
                        {
                            
                           WriteLine("\n***************************SORTED BY PRICE***************************\n");
                            shop.Sort_price();
                            foreach (Good item in shop)
                            { WriteLine(item); }
                        }
                        break;
                        case 3:
                        {
                            WriteLine("\n***************************PRODUCTION DATE**************************\\n\"");
                            shop.Sort(new Class_Prod_date());
                            foreach (Good item in shop)
                            { WriteLine(item); }
                        }
                        break;
                        case 4:
                        {
                            WriteLine("\n*******************************WEIGHT*******************************\\n\"");
                            shop.Sort_weight();
                            foreach (Good item in shop)
                            { WriteLine(item); }
                        }
                        break;
                }

                WriteLine("\nPress 1 to continue\n");
                q = ReadLine();
                Clear();
            } while (q == "1");

        }
    }

}


