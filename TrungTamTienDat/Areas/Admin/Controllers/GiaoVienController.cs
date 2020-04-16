using LibModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrungTamTienDat.Areas.Admin.Controllers
{
    public class GiaoVienController : Controller
    {
        //
        // GET: /Admin/GiaoVien/

        #region Danh sách giáo viên
        public ActionResult DanhSachGiaoVien()
        {
            List<GiaoVien> l_GiaoVien = new GiaoVien().GetList("", 0);
            return View(l_GiaoVien);
        }

        [HttpPost]
        public JsonResult giaovien_search(string HoTen, byte MonHocID)
        {
            List<GiaoVien> l_GiaoVien = new GiaoVien().GetList(HoTen, MonHocID);
            return Json(l_GiaoVien, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult giaovien_xoa(string param)
        {
            if (param.Length > 0)
            {
                List<string> l_path = new Anh().GetPath3(param);
                if (new GiaoVien().Delete(param) > 0)
                {
                    deleteFiles(l_path);

                    List<GiaoVien> l_GiaoVien = new GiaoVien().GetList("", 0);
                    return Json(l_GiaoVien, JsonRequestBehavior.AllowGet);
                }
                else return null;
            }
            else return null;
        }
        #endregion

        #region Cập nhật giáo viên
        public ActionResult CapNhatGiaoVien(string id)
        {
            GiaoVien gv = null;
            if (id != null)
            {
                gv = new GiaoVien().FindByID(Int16.Parse(id));
            }
            return View(gv);
        }

        [HttpPost]
        public int giaovien_capnhat(short ID, string HoTen, byte Tuoi, string HocVi, string NoiCongTac, string SoLuoc, string ChiTiet, string URL, string Facebook, string Twitter, string listMH)
        {
            DataTable dt = new DataTable();
            if(listMH.Length > 0) 
            {
                string[] arr = listMH.Split(',');
                if (arr.Length > 0)
                {
                    dt.Columns.Add("GiaoVienID");
                    dt.Columns.Add("MonHocID");
                    foreach (string s in arr)
                    {
                        dt.Rows.Add(0, s);
                    }
                }
            }

            if (ID == 0)
            {
                GiaoVien gv = new GiaoVien();
                gv.HoTen = HoTen;
                gv.Tuoi = Tuoi;
                gv.HocVi = HocVi;
                gv.NoiCongTac = NoiCongTac;
                gv.SoLuoc = SoLuoc;
                gv.ChiTiet = ChiTiet;
                gv.URL = URL;
                gv.Facebook = Facebook;
                gv.Twitter = Twitter;

                return gv.Add(dt);
            }
            else
            {
                GiaoVien gv = new GiaoVien().FindByID(ID);
                if (!URL.Equals(gv.URL))
                {
                    deleteFile(gv.URL);
                }
                gv.HoTen = HoTen;
                gv.Tuoi = Tuoi;
                gv.HocVi = HocVi;
                gv.NoiCongTac = NoiCongTac;
                gv.SoLuoc = SoLuoc;
                gv.ChiTiet = ChiTiet;
                gv.URL = URL;
                gv.Facebook = Facebook;
                gv.Twitter = Twitter;

                return gv.Update(dt);
            }
        }

        [HttpPost]
        public string uploadFile()
        {
            var file = Request.Files[0];

            string prefix = DateTime.Now.ToString("ddMMyyyy_HHmmssfff", CultureInfo.InvariantCulture);
            var fileName = prefix + Path.GetExtension(file.FileName);

            var path = Path.Combine(Server.MapPath("~/images/upload/giao_vien/"), fileName);
            file.SaveAs(path);

            return "/images/upload/giao_vien/" + fileName;
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
