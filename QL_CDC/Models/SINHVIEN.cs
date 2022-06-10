using System;
using System.Collections.Generic;

#nullable disable

namespace QL_CDC.Models
{
    public partial class SINHVIEN
    {
        public SINHVIEN()
        {
            BINHLUANSANPHAMs = new HashSet<BINHLUANSANPHAM>();
            CHATSV_MSSV_1Navigations = new HashSet<CHAT>();
            CHATSV_MSSV_2Navigations = new HashSet<CHAT>();
            DANHGIASANPHAMs = new HashSet<DANHGIASANPHAM>();
            GIOHANGs = new HashSet<GIOHANG>();
            HINHANHs = new HashSet<HINHANH>();
            HOADONMUAs = new HashSet<HOADONMUA>();
            SANPHAMs = new HashSet<SANPHAM>();
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

        public virtual ICollection<BINHLUANSANPHAM> BINHLUANSANPHAMs { get; set; }
        public virtual ICollection<CHAT> CHATSV_MSSV_1Navigations { get; set; }
        public virtual ICollection<CHAT> CHATSV_MSSV_2Navigations { get; set; }
        public virtual ICollection<DANHGIASANPHAM> DANHGIASANPHAMs { get; set; }
        public virtual ICollection<GIOHANG> GIOHANGs { get; set; }
        public virtual ICollection<HINHANH> HINHANHs { get; set; }
        public virtual ICollection<HOADONMUA> HOADONMUAs { get; set; }
        public virtual ICollection<SANPHAM> SANPHAMs { get; set; }
    }
}
