using Microsoft.AspNetCore.Mvc;
using QL_CDC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_CDC.Controllers
{
    public class SanPhamController : Controller
    {
        QL_CDCContext db = new QL_CDCContext();
        public IActionResult Index()
        {
            List<SanPhamModel> SP = new List<SanPhamModel>();
            foreach(var x in db.SANPHAM)
            {
                SanPhamModel s = new SanPhamModel();
                s.masp = x.SP_MSSP;
                s.tensp = x.SP_TENSP;
                s.giagocsp = (double)x.SP_GIA;
                s.dongiasp = TinhDonGiaSanPham(x.SP_MSSP);
                s.thoigiansp = (int)x.SP_THOIGIANSUDUNG;
                s.danhgiasp = LayDanhGiaSanPham(x.SP_MSSP);
                s.soluongsp = (int)x.SP_CONLAI;
            }
            return View(SP);
        }

        public double TinhDonGiaSanPham(string mssp)
        {
            double dongia = 0;
            double phantram = db.KHUYENMAI.Where(a => a.SP_MSSP == mssp).Select(a => (double)a.KM_PHANTRAM).FirstOrDefault();
            double giagoc = db.SANPHAM.Where(a => a.SP_MSSP == mssp).Select(a => (double)a.SP_GIA).FirstOrDefault();
            dongia = giagoc * phantram;
            return dongia;
        }

        public double LayDanhGiaSanPham(string mssv)
        {
            double danhgia = 0;
            List<DANHGIASANPHAM> D = db.DANHGIASANPHAM.Where(a => a.SV_MSSV == mssv).ToList();
            if(D.Count > 0)
            {
                foreach (var x in D)
                {
                    danhgia += (double)x.DG_GIATRI;
                }
                danhgia /= D.Count;
            }
            return danhgia;
        }

        public IActionResult ThemSanPham()
        {
            return View();
        }
    }
}
