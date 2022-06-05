using System;
using System.Collections.Generic;

#nullable disable

namespace QL_CDC.Models
{
    public partial class LOAIMATHANG
    {
        public LOAIMATHANG()
        {
            LOAISANPHAM = new HashSet<LOAISANPHAM>();
        }

        public int MH_MAMH { get; set; }
        public string MH_TENMH { get; set; }

        public virtual ICollection<LOAISANPHAM> LOAISANPHAM { get; set; }
    }
}
