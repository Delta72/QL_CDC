using System;
using System.Collections.Generic;

#nullable disable

namespace QL_CDC.Models
{
    public partial class SINHVIEN
    {
        public SINHVIEN()
        {
            BINHLUANSANPHAM = new HashSet<BINHLUANSANPHAM>();
            CHATSV_MSSV_1Navigation = new HashSet<CHAT>();
            CHATSV_MSSV_2Navigation = new HashSet<CHAT>();
            DANHGIASANPHAM = new HashSet<DANHGIASANPHAM>();
            GIOHANG = new HashSet<GIOHANG>();
            HINHANH = new HashSet<HINHANH>();
            HOADONMUA = new HashSet<HOADONMUA>();
            SANPHAM = new HashSet<SANPHAM>();
        }

        public string SV_MSSV { get; set; }
        public string SV_MATKHAU { get; set; }
        public string SV_HOTEN { get; set; }
        public string SV_TENHIENTHI { get; set; }
        public DateTime? SV_NGAYTAOTK { get; set; }
        public DateTime? SV_LANHDCUOI { get; set; }
        public string SV_DIACHIGIAOHANG { get; set; }
        public string SV_SDT { get; set; }
        public string SV_EMAIL { get; set; }
        public bool? SV_TINHTRANG { get; set; }
        public bool? SV_ADMIN { get; set; }

        public virtual ICollection<BINHLUANSANPHAM> BINHLUANSANPHAM { get; set; }
        public virtual ICollection<CHAT> CHATSV_MSSV_1Navigation { get; set; }
        public virtual ICollection<CHAT> CHATSV_MSSV_2Navigation { get; set; }
        public virtual ICollection<DANHGIASANPHAM> DANHGIASANPHAM { get; set; }
        public virtual ICollection<GIOHANG> GIOHANG { get; set; }
        public virtual ICollection<HINHANH> HINHANH { get; set; }
        public virtual ICollection<HOADONMUA> HOADONMUA { get; set; }
        public virtual ICollection<SANPHAM> SANPHAM { get; set; }
    }
}
