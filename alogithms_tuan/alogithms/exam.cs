using alogithms_tuan.alogithms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace algorithms_tuan.algorithms
{
    public class Exam
    {
        private List<string> nameEnity;
        private List<Product> products;
        private List<Category> categories;
        private List<Menu> menus;
        private Dictionary<int, string> categoryDictionary;


        private static Exam instance;

        /// <summary>
        /// Singleton instance of Exam class.
        /// </summary>
        public static Exam Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Exam();
                }
                return instance;
            }
        }

        /// <summary>
        /// Gets the list of products.
        /// </summary>
        public List<Product> GetProduct()
        {
            return products;
        }

        /// <summary>
        /// Gets the list of menus.
        /// </summary>
        public List<Menu> GetMenu()
        {
            return menus;
        }

        /// <summary>
        /// Initializes the Exam instance and populates products, categories, and menus.
        /// </summary>
        private Exam()
        {
            products = new List<Product>();
            categories = new List<Category>();
            menus = new List<Menu>();
            nameEnity = new List<string>();
            categoryDictionary = new Dictionary<int, string>();
        }

        /// <summary>
        /// Adds predefined products, categories, and menus to the instance.
        /// </summary>
        public void AddProduct()
        {
            //addProduct
            products.Add(new Product("CPU", 750, 10, 1));
            products.Add(new Product("RAM", 50, 2, 2));
            products.Add(new Product("HDD", 70, 1, 2));
            products.Add(new Product("Main", 400, 3, 1));
            products.Add(new Product("KeyBoard", 30, 8, 4));
            products.Add(new Product("Mouse", 25, 50, 4));
            products.Add(new Product("VGA", 60, 35, 3));
            products.Add(new Product("Monitor", 120, 28, 2));
            products.Add(new Product("Case", 120, 28, 5));

            //addCategory
            categories.Add(new Category(1, "Computer"));
            categories.Add(new Category(2, "Memory"));
            categories.Add(new Category(3, "Card"));
            categories.Add(new Category(4, "Accessory"));

            //addMenu
            menus.Add(new Menu(1, "the thao", 0));
            menus.Add(new Menu(2, "xa hoi", 0));
            menus.Add(new Menu(3, "the thao trong nuoc", 1));
            menus.Add(new Menu(4, "giao thong", 2));
            menus.Add(new Menu(5, "moi truong", 2));
            menus.Add(new Menu(6, "the thao quoc te", 1));
            menus.Add(new Menu(7, "moi truong do thi", 5));
            menus.Add(new Menu(8, "giao thong un tac", 4));
        }

        //bai4 
        /// <summary>
        /// Finds products by name with the input list Product and nameProduct
        /// </summary>
        public List<string> FindProductByName(List<Product> product,string name)
        {
            List<string> nameProduct = new List<string>();
            foreach (var item in product)
            {
                if (item.name.Equals(name))
                {
                    nameProduct.Add(item.name);
                }
            }
            return nameProduct;
        }

        //bai5
        /// <summary>
        /// Finds products by category ID with the input list Product and categoryId
        /// </summary>
        public List<string> FindProductByCategory(List<Product> product , int categoryId)
        {
            foreach (var item in product)
            {
                if (item.categoryId.Equals(categoryId))
                {
                    nameEnity.Add(item.name);
                }
            }
            return nameEnity;
        }

        //bai6
        /// <summary>
        /// Finds products by price with the input List Product and priceProduct
        /// </summary>
        public List<string> FindProductByPrice(List<Product> product , int price)
        {
            foreach (var item in product)
            {
                if (item.price.Equals(price))
                {
                    nameEnity.Add(item.name);
                }
            }
            return nameEnity;
        }

        // bai11
        /// <summary>
        /// Sorts the list of products by price in ascending order with input list Product
        /// </summary>
        public void SortByPrice(List<Product> product)
        {
            for (int i = 0; i < product.Count; i++)
            {
                for (int j = 0; j < product.Count - i - 1; j++)
                {
                    if (product[j].price > product[j + 1].price)
                    {
                        Product objTemp = product[j];
                        product[j] = product[j + 1];
                        product[j + 1] = objTemp;
                    }
                }
            }
        }

        // bai 12
        /// <summary>
        /// Sorts the list of products by name length in descending order with input list Product
        /// </summary>
        public void SortByName(List<Product> product)
        {
            for (int i = 1; i < product.Count; i++)
            {
                int j = i;
                while (j > 0 && product[j].name.Length > product[j - 1].name.Length)
                {
                    Product temp = product[j];
                    product[j] = product[j - 1];
                    product[j - 1] = temp;
                    j--;
                }
            }
        }

        // bài 13
        /// <summary>
        /// Sorts products by their category names in ascending order.
        /// </summary>
        public List<string> SortByCategoryName()
        {
            List<string> listProduct = new List<string>();

            for (int i = 1; i < categories.Count; i++)
            {
                Category key = categories[i];
                int j = i - 1;
                while (j >= 0 && string.Compare(categories[j].name, key.name) > 0)
                {
                    categories[j + 1] = categories[j];
                    j--;
                }

                categories[j + 1] = key;
            }

            foreach (var itemCategory in categories)
            {
                categoryDictionary[itemCategory.id] = itemCategory.name;
            }
            foreach (var category in categories)
            {
                foreach (var itemProduct in products)
                {
                    if (itemProduct.categoryId == category.id)
                    {
                        listProduct.Add(itemProduct.name);
                    }
                }
            }
            return listProduct;
        }


        //bai 14
        /// <summary>
        /// Maps products to their respective categories.
        /// </summary>
        public List<ProductWithCategory> MapProductByCategory()
        {
            foreach (var category in categories)
            {
                categoryDictionary[category.id] = category.name;
            }

            List<ProductWithCategory> result = new List<ProductWithCategory>();
            foreach (var product in products)
            {
                string categoryName = "dont'n know";
                if (categoryDictionary.ContainsKey(product.categoryId))
                {
                    categoryName = categoryDictionary[product.categoryId];
                }
                result.Add(new ProductWithCategory(product.name, product.price, product.quality, product.categoryId, categoryName));
            }

            return result;
        }


        // bài 15
        /// <summary>
        /// Finds the product with the minimum price with input List Product
        /// </summary>
        public string MinByPrice(List<Product> product)
        {
            Product result = null;
            float minPrice = float.MaxValue;

            foreach (var item in product)
            {
                if (item.price < minPrice)
                {
                    minPrice = item.price;
                    result = item;
                }
            }

            return result.name;
        }

        // bài 16
        /// <summary>
        /// Finds the product with the maximum price with input ListProduct
        /// </summary>
        public string MaxByPrice(List<Product> product)
        {
            Product result = null;
            float minPrice = float.MinValue;

            foreach (var item in product)
            {
                if (item.price > minPrice)
                {
                    minPrice = item.price;
                    result = item;
                }
            }

            return result.name;

        }

        // bài 21 sử dụng lãi kép
        /// <summary>
        /// Calculates future salary using compound interest recursively with input salary and year
        /// </summary>
        public float CallSalary(float salary, int year)
        {
            if (year == 0)
            {
                return salary;
            }
            return CallSalary(salary * 1.10f, year - 1);
        }

        /// <summary>
        /// Calculates future salary using compound interest without recursion with input salary and year
        /// </summary>
        public float CallSalaryNoDequy(float salary, int year)
        {
            return (float) (salary * Math.Pow((1 + 0.1f), year));
        }

        // bài 22 sử dụng lãi kép
        /// <summary>
        /// Calculates the number of months to reach a target amount using compound interest recursively with input month, rate and target (double the money)
        /// </summary>
        public int CallMonth(int month, float rate,float target)
        {
            float compounding = (1 + (rate / 1200));
            double result = Math.Pow(compounding, month);
            if (result >= target)
            {
                return month;
            }
            else
            {
                return CallMonth(month + 1 , rate , target);
            }
        }

        /// <summary>
        /// Calculates the number of months to double the money using compound interest without recursion with the money start and rate.
        /// </summary>
        public int CallMonthNoDequy(float money, float rate)
        {
            float target = money * 2;
            int i = 0;
            while (target > money)
            {
                money *= (1 + rate / 1200f);
                i++;
            }
            return i;
        }


        // bài 23
        /// <summary>
        /// Prints the menu items hierarchically based on parent-child relationships with the List Menu and parrentId,margin.
        /// </summary>
        public void PrintMenu(List<Menu> menu ,int parentId, string margin)
        {
            foreach (var item in menu)
            {
                if (item.idParent == parentId)
                {
                    Console.WriteLine($"{margin}{item.title}");
                    PrintMenu(menu , item.id, margin + "--");
                }
            }
        }

        /// <summary>
        /// Lists all product names.
        /// </summary>
        public List<string> ListProduct()
        {
            return products.Select(item => item.name).ToList();
        }

        /// <summary>
        /// Lists all category names.
        /// </summary>
        public List<string> ListCategory()
        {
            return categories.Select(item => item.name).ToList();
        }

        /// <summary>
        /// Prints information of all products.
        /// </summary>
        public void PrintProduct()
        {
            foreach(var item in products)
            {
                item.PrintInfor();
            }
        }
    }
}
