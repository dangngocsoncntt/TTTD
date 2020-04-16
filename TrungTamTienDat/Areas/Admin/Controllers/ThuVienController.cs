using LibModels;
using LibModels.common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrungTamTienDat.Areas.Admin.Models;

namespace TrungTamTienDat.Areas.Admin.Controllers
{
    public class ThuVienController : Controller
    {
        //
        // GET: /ThuVien/
        #region Danh sách ảnh thư viện
        public ActionResult DanhSachAnh()
        {
            List<Anh> l_Anh = new Anh().GetList(0, 0);
            return View(l_Anh);
        }

        [HttpPost]
        public JsonResult anh_search(short AlbumID)
        {
            List<Anh> l_Anh = new Anh().GetList(0, AlbumID);
            return Json(l_Anh, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult anh_xoa(string param)
        {
            if (param.Length > 0)
            {
                List<string> l_path = new Anh().GetPath(param);
                if (new Anh().Delete(param) > 0)
                {
                    deleteFiles(l_path);

                    List<Anh> l_Anh = new Anh().GetList(0, 0);
                    return Json(l_Anh, JsonRequestBehavior.AllowGet);
                }
                else return null;
            }
            else return null;
        }
        #endregion

        #region Upload ảnh
        public ActionResult UploadAnh()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadAction(AnyModel model, List<HttpPostedFileBase> fileUpload, short AlbumID)
        {
            string mes = "";
            if (fileUpload.Count > 0)
            {
                List<string> l_path = new List<string>();
                string prefix = DateTime.Now.ToString("ddMMyyyy_HHmmssfff",CultureInfo.InvariantCulture);
                int i = 0;
                //Datatable
                DataTable dt = new DataTable();
                dt.Columns.Add("TenFile");
                dt.Columns.Add("KieuAnh");
                dt.Columns.Add("URL");
                dt.Columns.Add("LoaiAnhID");
                // Handling Attachments - 
                foreach (HttpPostedFileBase item in fileUpload)
                {
                    if (item != null && Array.Exists(model.FilesToBeUploaded.Split(','), s => s.Equals(item.FileName)) && CommonFunc.IsImage(item))
                    {
                        i++;
                        //Save or do your action -  Each Attachment ( HttpPostedFileBase item ) 
                        var fileName = prefix + "_" + i.ToString() + Path.GetExtension(item.FileName);
                        var path = Path.Combine(Server.MapPath("~/images/upload/album/" + AlbumID.ToString()), fileName);
                        FileInfo file = new FileInfo(path);
                        if (!file.Exists)
                        {
                            l_path.Add("/images/upload/album/" + AlbumID.ToString() + "/" + fileName);
                            item.SaveAs(path);
                            // Add row into datatable
                            dt.Rows.Add(fileName, null, "/images/upload/album/" + AlbumID.ToString() + "/" + fileName, 2);
                        }
                    }
                }
                if (new Anh().Add(dt, AlbumID, "", "") <= 0)
                {
                    deleteFiles(l_path);
                    mes += "Upload không thành công!";
                }
                else
                {
                    mes += "Upload ảnh thành công!";
                }
            }
            return View("UploadAnh");
        }

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
        #endregion

        #region Album
        public ActionResult DanhSachAlbum()
        {
            List<Album> l_Album = new Album().GetList("");
            return View(l_Album);
        }

        [HttpPost]
        public int album_capnhat(short ID, string TenAlbum, string MoTa)
        {
            if (ID == 0)
            {
                Album a = new Album();
                a.TenAlbum = TenAlbum;
                a.MoTa = MoTa;
                a.NgayTao = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

                int i = a.Add();
                if (i > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/images/upload/album/"), i.ToString());
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    return i;
                }
                return 0;
            }
            else
            {
                Album a = new Album().FindByID(ID);
                return a.Update();
            }
        }

        [HttpPost]
        public int album_xoa(short ID)
        {
            string list = ID.ToString();
            if (new Album().Delete(list) > 0)
            {
                var path = Path.Combine(Server.MapPath("~/images/upload/album/"), ID.ToString());
                if (Directory.Exists(path))
                {
                    Directory.Delete(path);
                }
                return 1;
            }
            return 0;
        }
        #endregion
    }
}
