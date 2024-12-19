using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web.SessionState;

namespace WebGiaoHang
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Application["member"] = new ArrayList();
            Application["giohang"] = new ArrayList();


        }
        void Session_Start(object sender, EventArgs e)
        {
            Session["user"] = new Member();
            Session["user"] = null;
            Session["nameImg"] = null;
            Session["imgSP"] = null;
        }
    }
}