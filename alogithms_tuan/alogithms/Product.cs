using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alogithms_tuan.alogithms
{
    public class Product : IEnity
    {

        public string name { get; set; }
        public int price { get; set; }
        public int quality { get; set; }
        public int categoryId { get; set; }
        public int id { get; set; }
        public Product(string name, int price,int quality, int categoryId)
        {
            this.name = name;
            this.price = price;
            this.quality = quality;
            this.categoryId = categoryId;
        }

        public void PrintInfor()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("name : " + name);
            Console.WriteLine("price : " + price);
            Console.WriteLine("quality : " + quality);
            Console.WriteLine("categoryId : " + categoryId);
            Console.WriteLine("----------------------------");
        }
    }
}
