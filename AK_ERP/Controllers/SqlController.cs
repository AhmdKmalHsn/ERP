using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AK_HR.Controllers
{
    public class SqlController : Controller
    {
        // GET: Sql
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Read(string sql)
        {
            return Content(JsonConvert.SerializeObject(static_class.getbysql(sql).Tables[1], Formatting.Indented), "application/json");
        }
    }
}