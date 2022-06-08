using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
    public class TaiKhoanController : Controller
    {
        QL_CDCContext db = new QL_CDCContext();

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult DangNhap()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult TaskDangNhap(string tk, string mk)
        {
            var dn = false;
            SINHVIEN sv = db.SINHVIEN.Where(a => a.SV_MSSV == tk).FirstOrDefault();
            if(sv == null)
            {

            }
            else
            {
                dn = true;
                string role = "";
                if(sv.SV_ADMIN == true)
                {
                    role = "ad";
                }
                else
                {
                    role = "sv";
                }
                int gh = db.GIOHANG.Count(a => a.SV_MSSV == tk);
                var claims = new[] { 
                    new Claim(ClaimTypes.Name, sv.SV_TENHIENTHI), 
                    new Claim(ClaimTypes.NameIdentifier, sv.SV_MSSV),
                    new Claim(ClaimTypes.Role, role)};
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity));
            }
            return Json(dn);
        }

        public string MaHoaMatKhau(string mk)
        {
            string mkmh = "";
            return mkmh;
        }

        [Authorize]
        public async Task<IActionResult> DangXuat()
        {  
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","SanPham");
        }

        public IActionResult Test()
        {
            return View();
        }
    }
}
