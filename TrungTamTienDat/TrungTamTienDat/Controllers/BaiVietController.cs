using LibModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrungTamTienDat.Controllers
{
    public class BaiVietController : Controller
    {
        //
        // GET: /BaiViet/

        public ActionResult DanhSach(string id)
        {
            byte ChuDeID = (id == null) ? (byte)0 : Byte.Parse(id);
            List<BaiViet> l_BaiViet = new BaiViet().GetPaginationList(1, 6, ChuDeID, 0);
            return View(l_BaiViet);
        }

        public ActionResult ChiTiet(string id)
        {
            BaiViet bv = new BaiViet().FindByID(Int32.Parse(id));
            return View(bv);
        }

        [HttpPost]
        public JsonResult baiviet_phantrang(short PageNum, byte ChuDeID)
        {
            List<BaiViet> l_BaiViet = new BaiViet().GetPaginationList(PageNum, 6, ChuDeID, 0);
            return Json(l_BaiViet, JsonRequestBehavior.AllowGet);
        }
    }
}
