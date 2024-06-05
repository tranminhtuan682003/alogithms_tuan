using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alogithms_tuan.alogithms
{
    public interface IEnity
    {
        string name { get; set; }
        int price { get; set; }
        int quality { get; set; }
        int categoryId { get; set; }
        int id {  get; set; }
        void PrintInfor();
    }
}
