using System;
using System.Collections.Generic;

#nullable disable

namespace QL_CDC.Models
{
    public partial class SANPHAM
    {
        public SANPHAM()
        {
            BINHLUANSANPHAM = new HashSet<BINHLUANSANPHAM>();
            CHITIETHOADON = new HashSet<CHITIETHOADON>();
            DANHGIASANPHAM = new HashSet<DANHGIASANPHAM>();
            GIOHANG = new HashSet<GIOHANG>();
            HINHANH = new HashSet<HINHANH>();
            KHUYENMAI = new HashSet<KHUYENMAI>();
        }

        public string SP_MSSP { get; set; }
        public int LOAI_MALOAI { get; set; }
        public string SV_MSSV { get; set; }
        public string SP_TENSP { get; set; }
        public DateTime? SP_NGAYDANG { get; set; }
        public int? SP_THOIGIANSUDUNG { get; set; }
        public double? SP_GIA { get; set; }
        public int? SP_CONLAI { get; set; }
        public int? SP_DABAN { get; set; }
        public string SP_HANGSX { get; set; }
        public string SP_MOTA { get; set; }

        public virtual LOAISANPHAM LOAI_MALOAINavigation { get; set; }
        public virtual SINHVIEN SV_MSSVNavigation { get; set; }
        public virtual ICollection<BINHLUANSANPHAM> BINHLUANSANPHAM { get; set; }
        public virtual ICollection<CHITIETHOADON> CHITIETHOADON { get; set; }
        public virtual ICollection<DANHGIASANPHAM> DANHGIASANPHAM { get; set; }
        public virtual ICollection<GIOHANG> GIOHANG { get; set; }
        public virtual ICollection<HINHANH> HINHANH { get; set; }
        public virtual ICollection<KHUYENMAI> KHUYENMAI { get; set; }
    }
}
