using Microsoft.AspNetCore.Authorization;
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
        #region
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

        [HttpPost]
        [Authorize]
        public IActionResult ThemNhieuSanPhamVaoGio(string mssp, string sl)
        {
            int slsp; int.TryParse(sl, out slsp);
            var mssv = User.FindFirstValue(ClaimTypes.NameIdentifier);
            GIOHANG find = db.GIOHANGs.Where(a => a.SP_MSSP == mssp && a.SV_MSSV == mssv).FirstOrDefault();
            if(find == null)
            {
                GIOHANG GH = new GIOHANG()
                {
                    SP_MSSP = mssp,
                    SV_MSSV = mssv,
                    GH_SOLUONG = slsp,
                };
                db.GIOHANGs.Add(GH);
                db.SaveChanges();
            }
            else
            {
                db.Entry(find).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                int soluongconlai = (int)db.SANPHAMs.Where(a => a.SP_MSSP == mssp).Select(a => a.SP_CONLAI).FirstOrDefault();
                int soluongdaco = (int)find.GH_SOLUONG;
                if(soluongconlai < soluongdaco + slsp)
                {
                    find.GH_SOLUONG = soluongconlai;
                }
                else
                {
                    find.GH_SOLUONG += slsp;
                }
                db.Entry(find).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            return Json(true);
        }

        public IActionResult GioHang()
        {
            return View();
        }
        #endregion
    }

}
