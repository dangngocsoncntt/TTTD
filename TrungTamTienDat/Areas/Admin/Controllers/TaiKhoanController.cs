using LibModels;
using LibModels.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace TrungTamTienDat.Areas.Admin.Controllers
{
    public class TaiKhoanController : Controller
    {
        //
        // GET: /TaiKhoan/

        public ActionResult Index()
        {
            return View();
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

        [HttpPost]
        public void logout(string UserName, string Password)
        {
            Session.RemoveAll();
        }


        public int edit(string Password, string OldPassword)
        {
            if (Session["Password"] != null && !Session["Password"].ToString().Equals(""))
            {
                if (md5.getMd5(OldPassword).Equals(Session["Password"].ToString()))
                {
                    TaiKhoan tk = new TaiKhoan().Login(Session["Username"].ToString(), Session["Password"].ToString());
                    tk.Password = md5.getMd5(Password);
                    if (tk.Update() > 0)
                    {
                        Session.RemoveAll();
                        return 1;
                    }
                    else return 0;
                }
                else return -1;
            }
            return -1;
        }
    }
}
