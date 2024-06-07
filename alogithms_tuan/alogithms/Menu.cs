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

        /// <summary>
        /// constructor of class Menu.
        /// </summary>
        public Menu(int id, string title, int idParent)
        {
            this.id = id;
            this.title = title;
            this.idParent = idParent;
        }

        /// <summary>
        /// funciton PrinInfor to print ìnormation of Menu
        /// </summary>
        public void PrintInfor()
        {
            Console.WriteLine(title);
        }
    }
}
