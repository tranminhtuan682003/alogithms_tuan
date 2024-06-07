using algorithms_tuan.algorithms;
using alogithms_tuan.alogithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alogithms_tuan
{
    public class Program
    {
        static void Main(string[] args)
        {
            Exam ex = Exam.Instance;
            ex.AddProduct();

            //var result = ex.MapProductByCategory();
            //foreach (var product in result)
            //{
            //    Console.WriteLine($"Product: {product.name} \t\t {product.price} \t {product.quality} \t {product.categoryId} \t {product.CategoryName}");
            //    Console.WriteLine("------------------------------------------------------------------------------------");
            //}



            //Console.WriteLine(ex.MinByPrice());
            //ex.CallMonth(1000, 5, 0);

            //ex.sortByCategoryName();
            //var item = ex.ListCategory();
            //foreach(var category in item)
            //{
            //    Console.WriteLine(category);
            //}
            //Console.WriteLine(ex.CallMonth(0,5,2));
            //Console.WriteLine(ex.CallMonthNoDequy(1000, 5));

            //var product = ex.FindProductByPrice(ex.GetProduct(), 120);
            //foreach ( var item in product )
            //{
            //    Console.WriteLine(item);
            //}

            //ex.PrintMenu(ex.GetMenu(),0, "");

            //var bai13 = ex.SortByCategoryName();
            //foreach (var item in bai13)
            //{
            //    Console.WriteLine(item);
            //}
        }
    }
}
