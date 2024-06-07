using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alogithms_tuan.alogithms
{
    internal class Category : IEnity
    {
        public string name { get; set; }
        public int price { get; set; }
        public int quality { get; set; }
        public int categoryId { get; set; }
        public int id { get; set; }
        public Category(int id,string name)
        {
            this.id = id;
            this.name = name;
        }

        /// <summary>
        /// funciton PrinInfor to print ìnormation of Category
        /// </summary>
        public void PrintInfor()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("id : " + id);
            Console.WriteLine("name : " + name);
            Console.WriteLine("----------------------------");
        }
    }
}
