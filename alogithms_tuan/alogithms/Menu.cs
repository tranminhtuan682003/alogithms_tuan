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
        private int id;
        private string title;
        private int idParent;

        public Menu(int id, string title, int idParent)
        {
            this.id = id;
            this.title = title;
            this.idParent = idParent;
        }

        public void PrintInfor()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("id : " + id);
            Console.WriteLine("title : " + title);
            Console.WriteLine("idparent : " + idParent);
            Console.WriteLine("----------------------------");
        }
    }
}
