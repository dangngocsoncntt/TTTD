using LibModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrungTamTienDat.Controllers
{
    public class GiaoVienController : Controller
    {
        //
        // GET: /GiaoVien/

        public ActionResult DanhSach()
        {
            List<GiaoVien> l_GiaoVien = new GiaoVien().GetPaginationList(1, 6);
            return View(l_GiaoVien);
        }

        public ActionResult ChiTiet(string id)
        {
            GiaoVien gv = new GiaoVien().FindByID(Int16.Parse(id));
            return View(gv);
        }

        [HttpPost]
        public JsonResult giaovien_phantrang(short PageNum)
        {
            List<GiaoVien> l_GiaoVien = new GiaoVien().GetPaginationList(PageNum, 6);
            return Json(l_GiaoVien, JsonRequestBehavior.AllowGet);
        }
    }
}
