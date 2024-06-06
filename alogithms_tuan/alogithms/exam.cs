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

        private Exam()
        {
            products = new List<Product>();
            categories = new List<Category>();
            menus = new List<Menu>();
            nameEnity = new List<string>();
            categoryDictionary = new Dictionary<int, string>();
        }

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
        public List<string> FindProductByName(string name)
        {
            List<string> nameProduct = new List<string>();
            foreach (var item in products)
            {
                if (item.name.Equals(name))
                {
                    nameProduct.Add(item.name);
                }
            }
            return nameProduct;
        }

        //bai5
        public List<string> FindProductByCategory(int categoryId)
        {
            foreach (var item in products)
            {
                if (item.categoryId.Equals(categoryId))
                {
                    nameEnity.Add(item.name);
                }
            }
            return nameEnity;
        }

        //bai6
        public List<string> FindProductByPrice(int price)
        {
            foreach (var item in products)
            {
                if (item.price.Equals(price))
                {
                    nameEnity.Add(item.name);
                }
            }
            return nameEnity;
        }

        // bai11
        public void SortByPrice()
        {
            for (int i = 0; i < products.Count; i++)
            {
                for (int j = 0; j < products.Count - i - 1; j++)
                {
                    if (products[j].price > products[j + 1].price)
                    {
                        Product objTemp = products[j];
                        products[j] = products[j + 1];
                        products[j + 1] = objTemp;
                    }
                }
            }
        }

        // bai 12
        public void SortByName()
        {
            for (int i = 1; i < products.Count; i++)
            {
                int j = i;
                while (j > 0 && products[j].name.Length > products[j - 1].name.Length)
                {
                    Product temp = products[j];
                    products[j] = products[j - 1];
                    products[j - 1] = temp;
                    j--;
                }
            }
        }

        // bài 13
        public void sortByCategoryName()
        {
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

        }

        //bai 14
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
        public string MinByPrice()
        {
            Product result = null;
            float minPrice = float.MaxValue;

            foreach (var product in products)
            {
                if (product.price < minPrice)
                {
                    minPrice = product.price;
                    result = product;
                }
            }

            return result.name;
        }

        // bài 16
        public string MaxByPrice()
        {
            Product result = null;
            float minPrice = float.MinValue;

            foreach (var product in products)
            {
                if (product.price > minPrice)
                {
                    minPrice = product.price;
                    result = product;
                }
            }

            return result.name;

        }

        // bài 21 sử dụng lãi kép
        public float CallSalary(float salary, int year)
        {
            if (year == 0)
            {
                return salary;
            }
            return CallSalary(salary * 1.10f, year - 1);
        }

        public float CallSalaryNoDequy(float salary, int year)
        {
            return (float) (salary * Math.Pow((1 + 0.1f), year));
        }

        // bài 22 sử dụng lãi kép

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
        public void PrintMenu(int parentId, string margin)
        {
            foreach (var menu in menus)
            {
                if (menu.idParent == parentId)
                {
                    Console.WriteLine($"{margin}{menu.title}");
                    PrintMenu(menu.id, margin + "\t");
                }
            }
        }

        //Return Product and category
        public List<string> ListProduct()
        {
            return products.Select(item => item.name).ToList();
        }
        public List<string> ListCategory()
        {
            return categories.Select(item => item.name).ToList();
        }

        //printProduct
        public void PrintProduct()
        {
            foreach(var item in products)
            {
                item.PrintInfor();
            }
        }
    }
}
