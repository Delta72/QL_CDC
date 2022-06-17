using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
using QL_CDC.Models;
using System.Security.Claims;

namespace QL_CDC.Controllers
{
    public class ChatController : Controller
    {
        QL_CDCContext db = new QL_CDCContext();
        public IActionResult HienDanhSach()
        {
            List<ChatModel> C = new List<ChatModel>();
            var name = User.FindFirstValue(ClaimTypes.NameIdentifier);
            foreach(var item in db.CHATs.Where(x => x.SV_MSSV_G == name).Select(x => x.SV_MSSV_N).Distinct())
            {
                ChatModel c = new ChatModel();
                c.MaNguoiGui = name;
                c.MaNguoiNhan = item.ToString();
                c.TenShop = db.SINHVIENs.Where(a => a.SV_MSSV == c.MaNguoiNhan).Select(a => a.SV_TENHIENTHI).First();

                CHAT CH = new CHAT();
                CHAT C1 = db.CHATs.OrderBy(a => a.CHAT_THOIGIAN).Where(a => a.SV_MSSV_G == name && a.SV_MSSV_N == item).LastOrDefault();
                CHAT C2 = db.CHATs.OrderBy(a => a.CHAT_THOIGIAN).Where(a => a.SV_MSSV_N == name && a.SV_MSSV_G == item).LastOrDefault();
                if((C2 != null) && (C2.CHAT_THOIGIAN > C1.CHAT_THOIGIAN))
                {
                    CH = C2;
                }
                else
                {
                    CH = C1;
                }
                c.TinCuoi = new TinNhan()
                {
                    noidung = CH.CHAT_NOIDUNG,
                    thoigian = ((DateTime)CH.CHAT_THOIGIAN).ToString("dd/MM/yy"),
                    dadoc = (bool)CH.CHAT_DADOC,
                };

                c.img = db.HINHANHs.Where(a => a.SV_MSSV == item.ToString()).Select(a => a.HA_LINK).FirstOrDefault();
                C.Add(c);
            }
            return Json(C.OrderByDescending(x => x.TinCuoi.thoigian_dt));
        }

        public IActionResult ChiTietTinNhan(string msv)
        {
            var name = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<TinNhan> TN = new List<TinNhan>();
            foreach (var i in db.CHATs.Where(a => a.SV_MSSV_G == name || a.SV_MSSV_N == name))
            {
                if(i.SV_MSSV_N == msv || i.SV_MSSV_G == msv)
                {
                    TinNhan t = new TinNhan()
                    {
                        noidung = i.CHAT_NOIDUNG,
                        thoigian = ((DateTime)i.CHAT_THOIGIAN).ToString("dd/MM/yy HH:mm"),
                        thoigian_dt = i.CHAT_THOIGIAN,
                        dadoc = (bool)i.CHAT_DADOC,
                    };
                    if (i.SV_MSSV_G == name) t.latinguidi = true;
                    TN.Add(t);

                    db.Entry(i).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                    i.CHAT_DADOC = true;
                    db.Entry(i).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
            }
            db.SaveChanges();
            return Json(TN.OrderBy(x => x.thoigian_dt));
        }

        public IActionResult SoTinNhanChuaDoc()
        {
            int s = 0;
            foreach(var i in db.CHATs.Where(a => a.SV_MSSV_N == User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                if((bool)i.CHAT_DADOC == false)
                {
                    s++;
                }
            }
            return Json(s);
        }
    }
}
