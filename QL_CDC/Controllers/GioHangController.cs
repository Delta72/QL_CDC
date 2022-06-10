using Microsoft.AspNetCore.Mvc;
using QL_CDC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QL_CDC.Controllers
{
    public class GioHangController : Controller
    {
        QL_CDCContext db = new QL_CDCContext();
        public IActionResult HienSanPhamTrongGio()
        {
            var sp = 0;
            if (User.Identity.IsAuthenticated)
            {
                string tk = User.FindFirstValue(ClaimTypes.NameIdentifier);
                sp = db.GIOHANGs.Count(a => a.SV_MSSV == tk);
            }
            return Json(sp);
        }

        public IActionResult GioHang()
        {
            return View();
        }
    }

}
