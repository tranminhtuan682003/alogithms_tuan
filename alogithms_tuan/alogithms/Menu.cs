using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace alogithms_tuan.alogithms
{
    public class Menu
    {
        public int id;
        public string title;
        public int idParent;

        public Menu(int id, string title, int idParent)
        {
            this.id = id;
            this.title = title;
            this.idParent = idParent;
        }

        public void PrintInfor()
        {
            Console.WriteLine(title);
        }
    }
}
