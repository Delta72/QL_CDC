﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QL_CDC.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Security.Claims;
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
                s.anhsp = db.HINHANH.Where(a => a.SP_MSSP == x.SP_MSSP).Select(a => a.HA_LINK).ToList();
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

        [Authorize(Roles = "sv")]
        public IActionResult ThemSanPham()
        {
            List<SelectListModel> L = new List<SelectListModel>();
            foreach(var x in db.LOAIMATHANG)
            {
                SelectListModel s = new SelectListModel();
                s.id = x.MH_MAMH;
                s.name = x.MH_TENMH;
                L.Add(s);
            }
            return View(L);
        }

        [HttpPost]
        public IActionResult CapNhatLoai(string id)
        {
            int n; int.TryParse(id, out n);
            List<SelectListModel> L = new List<SelectListModel>();
            foreach(var i in db.LOAISANPHAM)
            {
                if(i.MH_MAMH == n)
                {
                    SelectListModel s = new SelectListModel();
                    s.id = i.LOAI_MALOAI;
                    s.name = i.LOAI_TENLOAI;
                    L.Add(s);
                }
            }
            return Json(L);
        }

        [HttpPost]
        public IActionResult DangSanPham(ThemSanPhamModel model)
        {
            // Them san pham
            SANPHAM SP = new SANPHAM() {
                SP_MSSP = Guid.NewGuid().ToString(),
                LOAI_MALOAI = model.maloai,
                SV_MSSV = User.FindFirstValue(ClaimTypes.NameIdentifier),
                SP_TENSP = model.tensp,
                SP_NGAYDANG = DateTime.Today,
                SP_THOIGIANSUDUNG = model.tg,
                SP_GIA = model.gia,
                SP_CONLAI = model.sl,
                SP_DABAN = 0,
                SP_HANGSX = model.nsx,
                SP_MOTA = model.mota,
            };
            db.SANPHAM.Add(SP);
            db.SaveChanges();

            // Them hinh anh san pham
            foreach(var i in model.img)
            {
                HINHANH HA = new HINHANH()
                {
                    HA_MSHA = Guid.NewGuid().ToString(),
                    SP_MSSP = SP.SP_MSSP,
                    HA_LINK = UploadImage(i),
                };
                db.HINHANH.Add(HA);
                db.SaveChanges();
            }
            return Json("");
        }

        public string UploadImage(IFormFile img)
        {
            var filename = Guid.NewGuid().ToString() + img.FileName;
            var filepath = Directory.GetCurrentDirectory() + "\\wwwroot\\sanpham\\" + filename;
            using (var stream = new FileStream(filepath, FileMode.Create))
            {
                img.CopyTo(stream);
            }
            return filepath;
        }
    }
}
