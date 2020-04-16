using LibModels;
using LibModels.common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrungTamTienDat.Areas.Admin.Controllers
{
    public class BaiVietController : Controller
    {
        //
        // GET: /ChuDe/
        #region Danh sách bài viết
        public ActionResult DanhSachBaiViet()
        {
            List<BaiViet> l_BaiViet = new BaiViet().GetList("", "", "", 0);
            return View(l_BaiViet);
        }

        [HttpPost]
        public JsonResult baiviet_search(string TieuDe, string NgayDangMin, string NgayDangMax, byte ChuDeID)
        {
            List<BaiViet> l_BaiViet = new BaiViet().GetList(TieuDe, NgayDangMin, NgayDangMax, ChuDeID);
            return Json(l_BaiViet, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult baiviet_xoa(string param)
        {
            if (param.Length > 0)
            {
                List<string> l_path = new Anh().GetPath2(param);
                if (new BaiViet().Delete(param) > 0)
                {
                    deleteFiles(l_path);

                    List<BaiViet> l_BaiViet = new BaiViet().GetList("", "", "", 0);
                    return Json(l_BaiViet, JsonRequestBehavior.AllowGet);
                }
                else return null;
            }
            else return null;
        }
        #endregion

        #region Cập nhật bài viết
        public ActionResult CapNhatBaiViet(string id)
        {
            BaiViet bv = null;
            if (id != null)
            {
                bv = new BaiViet().FindByID(Int32.Parse(id));
            }
            return View(bv);
        }

        [HttpPost]
        public int baiviet_capnhat(short ID, string TieuDe, string SoLuoc, string NoiDung, byte ChuDeID, int LopHocID, string URL)
        {
            if (ID == 0)
            {
                BaiViet bv = new BaiViet();
                bv.TieuDe = TieuDe;
                bv.SoLuoc = SoLuoc;
                bv.NoiDung = NoiDung;
                bv.LopHocID = LopHocID;
                bv.ChuDeID = ChuDeID;
                bv.IP = CommonFunc.getIPAddress();
                bv.URL = URL;
                bv.LuotXem = 0;
                bv.NgayDang = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                return bv.Add();
            }
            else
            {
                BaiViet bv = new BaiViet().FindByID(ID);
                if (!URL.Equals(bv.URL))
                {
                    deleteFile(bv.URL);
                }
                bv.TieuDe = TieuDe;
                bv.SoLuoc = SoLuoc;
                bv.NoiDung = NoiDung;
                bv.ChuDeID = ChuDeID;
                bv.LopHocID = LopHocID;
                bv.URL = URL;
                return bv.Update();
            }
        }

        [HttpPost]
        public string uploadFile()
        {
            var file = Request.Files[0];

            string prefix = DateTime.Now.ToString("ddMMyyyy_HHmmssfff", CultureInfo.InvariantCulture);
            var fileName = prefix + Path.GetExtension(file.FileName);

            var path = Path.Combine(Server.MapPath("~/images/upload/bai_viet/"), fileName);
            file.SaveAs(path);

            return "/images/upload/bai_viet/" + fileName;
        }

        [HttpPost]
        public int deleteFile(string path)
        {
            var path1 = Path.Combine(Server.MapPath("~" + path));
            FileInfo file = new FileInfo(path1);
            if (file.Exists)
            {
                file.Delete();
                return 1;
            }
            return 0;
        }
        #endregion

        #region Chủ đề
        public ActionResult DanhSachChuDe()
        {
            List<ChuDe> l_ChuDe = new ChuDe().GetList("");
            return View(l_ChuDe);
        }

        [HttpPost]
        public int chude_capnhat(byte ID, string TenChuDe, string MoTa)
        {
            if (ID == 0)
            {
                ChuDe cd = new ChuDe();
                cd.TenChuDe = TenChuDe;
                cd.MoTa = MoTa;
                return cd.Add();
            }
            else
            {
                ChuDe cd = new ChuDe().FindByID(ID);
                return cd.Update();
            }
        }

        [HttpPost]
        public int chude_xoa(byte ID)
        {
            string list = ID.ToString();
            if (new ChuDe().Delete(list) > 0) return 1;
            return 0;
        }
        #endregion

        public void deleteFiles(List<string> l_path)
        {
            if (l_path.Count > 0)
            {
                foreach (string path in l_path)
                {
                    string path1 = Path.Combine(Server.MapPath("~" + path));
                    FileInfo file = new FileInfo(path1);
                    if (file.Exists)
                    {
                        file.Delete();
                    }
                }
            }
        }
    }
}
