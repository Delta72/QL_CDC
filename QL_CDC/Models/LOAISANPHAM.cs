using System;
using System.Collections.Generic;

#nullable disable

namespace QL_CDC.Models
{
    public partial class LOAISANPHAM
    {
        public LOAISANPHAM()
        {
            SANPHAMs = new HashSet<SANPHAM>();
        }

        public int LOAI_MALOAI { get; set; }
        public int MH_MAMH { get; set; }
        public string LOAI_TENLOAI { get; set; }

        public virtual LOAIMATHANG MH_MAMHNavigation { get; set; }
        public virtual ICollection<SANPHAM> SANPHAMs { get; set; }
    }
}
