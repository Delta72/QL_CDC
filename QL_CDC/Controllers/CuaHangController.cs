using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using QL_CDC.Models;
using System.Security.Claims;
using System.Dynamic;

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
                    luotxemsp = (int)item.SP_LUOTXEM,
                };
                SP.Add(sp);
            }
            return View(SP);
        }

        [Authorize]
        public IActionResult SuaSanPham(string id)
        {
            SANPHAM SP = db.SANPHAMs.Where(a => a.SP_MSSP == id).FirstOrDefault();
            dynamic model = new ExpandoObject();

            List<SelectListModel> L = new List<SelectListModel>();
            foreach (var x in db.LOAIMATHANGs)
            {
                SelectListModel s = new SelectListModel();
                s.id = x.MH_MAMH;
                s.name = x.MH_TENMH;
                L.Add(s);
            }
            model.mh = L;

            List<SelectListModel> L2 = new List<SelectListModel>();
            foreach (var x in db.LOAISANPHAMs.Where(a => a.LOAI_MALOAI == SP.LOAI_MALOAI))
            {
                SelectListModel s = new SelectListModel();
                s.id = x.LOAI_MALOAI;
                s.name = x.LOAI_TENLOAI;
                L2.Add(s);
            }
            model.ml = L2;

            SanPhamModel sp = new SanPhamModel() {
                masp = SP.SP_MSSP,
                tensp = SP.SP_TENSP,
                maloai = SP.LOAI_MALOAI,
                giagocsp = (double)SP.SP_GIA,
                thoigiansp = (int)SP.SP_THOIGIANSUDUNG,
                soluongsp = (int)SP.SP_CONLAI,
                nsx = SP.SP_HANGSX,
                motasp = SP.SP_MOTA,
                anhsp = new List<string>(),
                mamh = db.LOAIMATHANGs.Where(a => a.MH_MAMH == SP.LOAI_MALOAINavigation.MH_MAMH).Select(a => a.MH_MAMH).FirstOrDefault(),
            };
            foreach(var str in db.HINHANHs.Where(a => a.SP_MSSP == sp.masp))
            {
                sp.anhsp.Add(str.HA_LINK);
            }
            model.sp = sp;

            return View(model);
        }

        [Authorize]
        public IActionResult LuuSuaSanPham(ThemSanPhamModel model)
        {
            SANPHAM S = db.SANPHAMs.Where(a => a.SP_MSSP == model.masp).FirstOrDefault();

            return RedirectToAction("SuaSanPham", new { id = S.SP_MSSP});
        }
    }
}
