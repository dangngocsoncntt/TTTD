using LibModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrungTamTienDat.Models;

namespace TrungTamTienDat.Controllers
{
    public class ThuVienController : Controller
    {
        //
        // GET: /ThuVien/

        public ActionResult DanhSach()
        {
            List<Album> l_Album = new Album().GetList("");
            List<Anh> l_Anh = new Anh().GetList(2, 0);
            ViewModels vm = new ViewModels();
            vm.l_Album = l_Album;
            vm.l_Anh = l_Anh;
            return View(vm);
        }

    }
}
