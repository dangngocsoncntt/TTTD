using LibModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrungTamTienDat.Areas.Admin.Controllers
{
    public class KhacController : Controller
    {
        //
        // GET: /Admin/Khac/

        #region Phản Hồi
        public ActionResult DanhSachPhanHoi()
        {
            List<PhanHoi> l_PhanHoi = new PhanHoi().GetList("", "");
            return View(l_PhanHoi);
        }

        [HttpPost]
        public JsonResult phanhoi_search(string IP, string HienThi)
        {
            List<PhanHoi> l_PhanHoi = new PhanHoi().GetList(IP, HienThi);
            return Json(l_PhanHoi, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public int phanhoi_sua(int ID, bool HienThi)
        {
            PhanHoi ph = new PhanHoi().FindByID(ID);
            ph.HienThi = HienThi;
            if (ph.Update() > 0) return 1;
            else return 0;
        }

        [HttpPost]
        public JsonResult phanhoi_xoa(string param)
        {
            if (param.Length > 0)
            {
                if (new PhanHoi().Delete(param) > 0)
                {
                    List<PhanHoi> l_PhanHoi = new PhanHoi().GetList("", "");
                    return Json(l_PhanHoi, JsonRequestBehavior.AllowGet);
                }
                else return null;
            }
            else return null;
        }
        #endregion
    }
}
