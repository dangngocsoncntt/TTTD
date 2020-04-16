using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibModels;
using TrungTamTienDat.Models;
using LibModels.common;
using System.Globalization;
using System.Web.Configuration;

namespace TrungTamTienDat.Controllers
{
    public class TrangChuController : Controller
    {
        public ActionResult Index()
        {
            List<PhanHoi> l_PhanHoi = new PhanHoi().GetList("", "1");
            List<GiaoVien> l_GiaoVien = new GiaoVien().GetFamousList();
            List<BaiViet> l_BaiViet = new BaiViet().GetRecentList();

            ViewModels vm = new ViewModels();
            vm.l_GiaoVien = l_GiaoVien;
            vm.l_BaiViet = l_BaiViet;
            vm.l_PhanHoi = l_PhanHoi;
            return View(vm);
        }

        public ActionResult GioiThieu()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult LienHe()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public int phanhoi_tao(string HoTen, byte Tuoi, string DiaChi, string TieuDe, string NoiDung)
        {
            PhanHoi ph = new PhanHoi();
            ph.TieuDe = TieuDe;
            ph.HoTen = HoTen;
            ph.DiaChi = DiaChi;
            ph.NoiDung = NoiDung;
            ph.Tuoi = Tuoi;
            ph.IP = CommonFunc.getIPAddress();
            return ph.Add();
        }

        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public int login(string UserName, string Password)
        {
            TaiKhoan tk = new TaiKhoan().Login(UserName, md5.getMd5(Password));
            int flag = 0;
            if (tk.Username != null)
            {
                tk.LastLogin = DateTime.Now.ToString();
                tk.IP = Request.UserHostAddress;
                if (tk.Update() > 0)
                {
                    Session.Timeout = Int32.Parse(WebConfigurationManager.AppSettings["DURATION_TIMEOUT"]);
                    Session["Username"] = tk.Username;
                    Session["Password"] = tk.Password;
                    flag = 1;
                }
                else flag = 2;
            }
            return flag;
        }
    }
}
