using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_CDC.Models
{
    public class SanPhamModel
    {
        public string masp { get; set; }
        public string tensp { get; set; }
        public List<string> anhsp { get; set; }
        public double giagocsp { get; set; }
        public double dongiasp { get; set; }
        public int thoigiansp { get; set; }
        public double danhgiasp { get; set; }
        public int soluongsp { get; set; }
    }
}
