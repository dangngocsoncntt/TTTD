using LibModels;
using LibModels.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrungTamTienDat.Areas.Admin.Controllers
{
    public class LopHocController : Controller
    {
        //
        // GET: /Admin/LopHoc/
        #region Danh sách học viên
        public ActionResult DanhSachHocVien()
        {
            List<DangKy> l_HocVien = new DangKy().GetList("", 0, "", "");
            return View(l_HocVien);
        }

        [HttpPost]
        public JsonResult hocvien_search(short LopHocID, string TenHocVien)
        {
            List<DangKy> l_HocVien = new DangKy().GetList("", LopHocID, TenHocVien, "");
            return Json(l_HocVien, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult hocvien_xoa(string param)
        {
            if (param.Length > 0)
            {
                if (new DangKy().Delete(param) > 0)
                {
                    List<DangKy> l_HocVien = new DangKy().GetList("", 0, "", "");
                    return Json(l_HocVien, JsonRequestBehavior.AllowGet);
                }
                else return null;
            }
            else return null;
        }
        #endregion

        #region Danh sách lớp học
        public ActionResult DanhSachLopHoc()
        {
            string username = Session["Username"] == null ? "" : Session["Username"].ToString();
            List<LopHoc> l_LopHoc = new LopHoc().GetList("", 0, "", 0, username);
            return View(l_LopHoc);
        }

        [HttpPost]
        public JsonResult lophoc_search(string TenLopHoc, byte MonHocID, string NhanHocVien, byte Khoi)
        {
            string username = Session["Username"] == null ? "" : Session["Username"].ToString();
            List<LopHoc> l_LopHoc = new LopHoc().GetList(TenLopHoc, MonHocID, NhanHocVien, Khoi, username);
            return Json(l_LopHoc, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult lophoc_xoa(string param)
        {
            if (param.Length > 0)
            {
                if (new LopHoc().Delete(param) > 0)
                {
                    string username = Session["Username"] == null ? "" : Session["Username"].ToString();
                    List<LopHoc> l_LopHoc = new LopHoc().GetList("", 0, "", 0, username);
                    return Json(l_LopHoc, JsonRequestBehavior.AllowGet);
                }
                else return null;
            }
            else return null;
        }

        [HttpPost]
        public JsonResult dangky_xoa(string param)
        {
            if (param.Length > 0)
            {
                if (new LopHoc().Delete(param) > 0)
                {
                    List<DangKy> l_HocVien = new DangKy().GetList("", 0, "", "");
                    return Json(l_HocVien, JsonRequestBehavior.AllowGet);
                }
                else return null;
            }
            else return null;
        }

        [HttpPost]
        public JsonResult dangky_kichhoat(string param)
        {
            if (param.Length > 0)
            {
                if (new LopHoc().Activate(param) > 0)
                {
                    List<DangKy> l_DangKy = new DangKy().GetList(param, 0, "", "");
                    if (l_DangKy != null && l_DangKy.Count > 0)
                    {
                        foreach(var item in l_DangKy)
                        {
                            CommonFunc.SendMail("buimai.cntt@gmail.com", "quy_than", item.Email, "Thông báo đăng ký học thành công", "Thông báo đăng ký học thành công", "Thông báo đăng ký học thành công");
                        }
                    }
                    List<DangKy> l_HocVien = new DangKy().GetList("", 0, "", "");
                    return Json(l_HocVien, JsonRequestBehavior.AllowGet);
                }
                else return null;
            }
            else return null;
        }
        #endregion

        #region Cập nhật lớp học
        public ActionResult CapNhatLopHoc(string id)
        {
            LopHoc lh = null;
            if (id != null)
            {
                lh = new LopHoc().FindByID(Int16.Parse(id));
            }
            return View(lh);
        }

        [HttpPost]
        public int lophoc_capnhat(short ID, string TenLopHoc, string NgayNhan, string HanChot, string NgayNhapHoc, byte MonHocID, string LichHoc, string MoTa, decimal HocPhi, byte LoaiHocPhiID, bool NhanHocVien, byte Khoi)
        {
            if (ID == 0)
            {
                LopHoc lh = new LopHoc();
                lh.TenLopHoc = TenLopHoc;
                lh.NgayNhan = NgayNhan;
                lh.HanChot = HanChot;
                lh.NgayNhapHoc = NgayNhapHoc;
                lh.MonHocID = MonHocID;
                lh.LichHoc = LichHoc;
                lh.MoTa = MoTa;
                lh.HocPhi = HocPhi;
                lh.LoaiHocPhiID = LoaiHocPhiID;
                lh.NhanHocVien = NhanHocVien;
                lh.Khoi = Khoi;
                return lh.Add();
            }
            else
            {
                LopHoc lh = new LopHoc().FindByID(ID);
                lh.TenLopHoc = TenLopHoc;
                lh.NgayNhan = NgayNhan;
                lh.HanChot = HanChot;
                lh.NgayNhapHoc = NgayNhapHoc;
                lh.MonHocID = MonHocID;
                lh.LichHoc = LichHoc;
                lh.MoTa = MoTa;
                lh.HocPhi = HocPhi;
                lh.LoaiHocPhiID = LoaiHocPhiID;
                lh.NhanHocVien = NhanHocVien;
                lh.Khoi = Khoi;
                return lh.Update();
            }
        }
        #endregion
    }
}
