using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alogithms_tuan.alogithms
{
    public class ProductWithCategory : Product
    {
        public string CategoryName { get; set; }


        /// <summary>
        /// Constructer of class ProductWithCategory
        /// </summary>
        public ProductWithCategory(string name, int price, int quality, int categoryId, string categoryName) : base(name,price,quality,categoryId)
        {
            CategoryName = categoryName;
        }
    }
}
