using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_CDC.Controllers
{
    public class CuaHangController : Controller
    {
        public IActionResult DanhSachSanPham()
        {
            return View();
        }

    }
}
