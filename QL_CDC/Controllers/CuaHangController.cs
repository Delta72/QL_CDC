using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using QL_CDC.Models;
using System.Security.Claims;

namespace QL_CDC.Controllers
{
    public class CuaHangController : Controller
    {
        QL_CDCContext db = new QL_CDCContext();

        [Authorize]
        public IActionResult DanhSachSanPham()
        {
            List<SanPhamModel> SP = new List<SanPhamModel>();
            foreach(var item in db.SANPHAMs.Where(a => a.SV_MSSV == User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                SanPhamModel sp = new SanPhamModel() {
                    masp = item.SP_MSSP,
                    tensp = item.SP_TENSP,
                    anhsp = db.HINHANHs.Where(a => a.SP_MSSP == item.SP_MSSP).Select(a => a.HA_LINK).ToList(),
                    giagocsp = (double)item.SP_GIA,
                    ngaydangsp = ((DateTime)item.SP_NGAYDANG).ToString("dd/MM/yyyy"),
                    soluongsp = (int)item.SP_CONLAI,
                };
                SP.Add(sp);
            }
            return View(SP);
        }

    }
}
