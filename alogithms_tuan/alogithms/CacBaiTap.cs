using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace alogithms_tuan.alogithms
{
    public class CacBaiTap
    {
        private Dictionary<string, List<IEnity>> mydatabase;
        private static CacBaiTap instance;

        public static CacBaiTap Instance()
        {
            if(instance == null)
            {
                instance = new CacBaiTap();
            }
            return instance;
        }

        private CacBaiTap()
        {
            mydatabase = new Dictionary<string, List<IEnity>>();
        }

        public void InsertTable(IEnity obj)
        {
            if (!mydatabase.ContainsKey(obj.GetType().Name))
            {
                mydatabase[obj.GetType().Name] = new List<IEnity>();
            }
            mydatabase[obj.GetType().Name].Add(obj);
        }
        
        // bài 4
        public void FindProduct(string tableName,string nameRow)
        {
            foreach(var item in mydatabase[tableName])
            {
                if(item.name == nameRow)
                {
                    item.PrintInfor();
                }
            }
        }

        // bài 5
        public void FindProductByCategory(string tableName,int categoryId)
        {
            foreach(var item in mydatabase[tableName])
            {
                if(item.categoryId == categoryId)
                {
                    item.PrintInfor();
                }
            }
        }

        // bài 6
        public void FindProductByPrice(string tableName, int price)
        {
            foreach (var item in mydatabase[tableName])
            {
                if (item.price == price)
                {
                    item.PrintInfor();
                }
            }
        }
        
        // bài 11
        public void SortByPrice(string tableName)
        {
            object objTemp;
            for (int i = 0;i < mydatabase[tableName].Count;i++)
            {
                for(int j = 0; j < mydatabase[tableName].Count - i - 1; j++)
                {
                    if (mydatabase[tableName][j].price > mydatabase[tableName][j + 1].price)
                    {
                        objTemp = mydatabase[tableName][j];
                        mydatabase[tableName][j] = mydatabase[tableName][j+1];
                        mydatabase[tableName][j + 1] = (IEnity)objTemp;
                    }
                }
            }
        }

        // bài 12
        public void SortByName(string tableName)
        {
            int totalIndex = mydatabase[tableName].Count;
            object temp;
            for (int i = 1; i < totalIndex; i++)
            {
                int j = i;
                while (j > 0 && mydatabase[tableName][j].name.Length > mydatabase[tableName][j - 1].name.Length)
                {
                    temp = mydatabase[tableName][j];
                    mydatabase[tableName][j] = mydatabase[tableName][j - 1];
                    mydatabase[tableName][j - 1] = (IEnity)temp;
                    j--;
                }
            }
        }

        // bài 13
        public void sortByCategoryName()
        {
            // coming soon
        }

        // bài 14
        public void mapProductByCategory(string Product,string Category)
        {
            foreach(var product in mydatabase[Product])
            {
                foreach (var category in mydatabase[Category])
                {
                    if (product.id == category.id)
                    {
                        category.PrintInfor();
                        product.PrintInfor();
                    }
                }
            }


        }

        // bài 15
        public void MinByPrice(string tableName)
        {
            this.SortByPrice(tableName);                                                        
            mydatabase[tableName][0].PrintInfor();
        }

        // bài 16
        public void MaxByPrice(string tableName)
        {
            this.SortByPrice(tableName);
            mydatabase[tableName][mydatabase[tableName].Count - 1].PrintInfor();
        }

        // bài 21
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

        // bài 22

        public int CallMonth(float money, int rate, int month)
        {
            float target = money * 2;
            money *= (1 + rate / 1200f);
            float epsilon = 0.0001f;

            if (Math.Abs(money - target) < epsilon)
            {
                return month;
            }
            return CallMonth(money, rate, month + 1);
        }


        public int CallMonthNoDequy(float money, int rate)
        {
            float target = money * 2;
            int month = 0;
            while (money < target && month < 1000)
            {
                money *= (1 + rate / 1200f); 
                month++;
            }
            if (money >= target)
            {
                return month;
            }
            return -1;
        }

        public void AddEnity()
        {
            this.InsertTable(new Product("CPU", 750, 10, 1));
            this.InsertTable(new Product("RAM", 50, 2, 2));
            this.InsertTable(new Product("HDD", 70, 1, 2));
            this.InsertTable(new Product("Main", 400, 3, 1));
            this.InsertTable(new Product("KeyBoard", 30, 8, 4));
            this.InsertTable(new Product("Mouse", 25, 50, 4));
            this.InsertTable(new Product("VGA", 60, 35, 3));
            this.InsertTable(new Product("Monitor", 120, 28, 2));
            this.InsertTable(new Product("Case", 120, 28, 5));


            this.InsertTable(new Category(1, "Computer"));
            this.InsertTable(new Category(2, "Memory"));
            this.InsertTable(new Category(3, "Card"));
            this.InsertTable(new Category(4, "Accessory"));
        }
        public void PrintDatabase()
        {
            foreach(var item in mydatabase.Keys)
            {
                foreach (var enity in mydatabase[item])
                {
                    enity.PrintInfor();
                }
            }
        }

        public void PrintTable(string nameTable)
        {
            for(int i = 0; i < mydatabase[nameTable].Count; i++)
            {
                mydatabase[nameTable][i].PrintInfor();
            }
        }

    }
}
