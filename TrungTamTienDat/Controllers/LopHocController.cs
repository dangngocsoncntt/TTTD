using LibModels;
using LibModels.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrungTamTienDat.Models;

namespace TrungTamTienDat.Controllers
{
    public class LopHocController : Controller
    {
        //
        // GET: /LopHoc/

        public ActionResult DanhSach()
        {
            string username = Session["Username"] == null ? "" : Session["Username"].ToString();
            List<LopHoc> l_LopHoc = new LopHoc().GetList("", 0, "1", 0, username);
            List<MonHoc> l_MonHoc = new MonHoc().GetList();
            ViewModels vm = new ViewModels();
            vm.l_LopHoc = l_LopHoc;
            vm.l_MonHoc = l_MonHoc;
            return View(vm);
        }

        public ActionResult DanhSachBaiViet(string id)
        {
            List<BaiViet> l_BaiViet = new BaiViet().GetPaginationList(1, 6, 0, int.Parse(id));
            return View(l_BaiViet);
        }

        [HttpPost]
        public JsonResult baiviet_phantrang(short PageNum, byte ChuDeID, int LopHocID)
        {
            List<BaiViet> l_BaiViet = new BaiViet().GetPaginationList(PageNum, 6, ChuDeID, LopHocID);
            return Json(l_BaiViet, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ChiTiet(string id)
        {
            LopHoc lh = new LopHoc().FindByID(Int16.Parse(id));
            return View(lh);
        }

        [HttpPost]
        public int hocvien_dangky(string HoTen, byte Tuoi, string DiaChi, string Email, string SDT, short LopHocID, string Username, string Password)
        {
            DangKy dk = new DangKy();
            dk.DiaChi = DiaChi;
            dk.HoTen = HoTen;
            dk.SDT = SDT;
            dk.Email = Email;
            dk.Tuoi = Tuoi;
            dk.LopHocID = LopHocID;
            dk.Username = Username;
            dk.Password = md5.getMd5(Password); 
            dk.IP = CommonFunc.getIPAddress();
            return dk.Add();
        }

        [HttpPost]
        public JsonResult lophoc_search(byte MonHocID, byte Khoi)
        {
            string username = Session["Username"] == null ? "" : Session["Username"].ToString();
            List<LopHoc> l_LopHoc = new LopHoc().GetList("", MonHocID, "1", Khoi, username);
            return Json(l_LopHoc, JsonRequestBehavior.AllowGet);
        }
    }
}
