using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_CDC.Models
{
    public class SinhVienModel
    {
        public string MSSV { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string TenHienThi { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public DateTime NgayHDCuoi { get; set; }
        public bool TinhTrang { get; set; }
    }
}
