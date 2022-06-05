using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QL_CDC.Models
{
    public class DangNhapModel
    {
        [Required(ErrorMessage = "Vui lòng nhập tài khoản")]
        [MaxLength(8)]
        public string taikhoan { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [MaxLength(24)]
        public string matkhau { get; set; }
    }
}
