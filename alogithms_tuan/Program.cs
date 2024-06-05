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
            CacBaiTap cacbaitap = CacBaiTap.Instance();
            cacbaitap.AddEnity();
            //database.SortByPrice("Product");
            //database.PrintTable("Product");
            //database.MaxByPrice("Product");
            //database.CallSalaryNoDequy(1000, 4);
            Console.WriteLine(cacbaitap.CallMonth(1000, 5,0));
        }
    }
}
