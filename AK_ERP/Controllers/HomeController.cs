using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.IO;
using System.Runtime.Remoting.Contexts;

namespace AK_HR.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //repeat state 
            if (Request.Cookies["token"] == null)
            {
               return RedirectToAction("log", "home");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Log()
        {
            // this the only stat because it is in log page 
            if (Request.Cookies["token"] == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("index", "home");
            }
        }

        /**************************************/
        public ActionResult AK_LogIn(string username = "", string password = "")
        {
            string clientIP = Request.UserHostAddress;
            string sql = @"SELECT u.Id userId,*
                           from AK_Users u 
                           where u.UserName='" + username + "' and u.password='" + password + "'";
            string output = "[{\"status\" : \"error\" ,\"message\" : \"user name or password is error\"}]";
            var ds = static_class.getbysql(sql);
            if (ds.Tables["status"].Rows[0][0].ToString() == "success")
            {
                //output = JsonConvert.SerializeObject(ds, Formatting.Indented);
                if (ds.Tables["data"].Rows.Count > 0)
                {
                    Guid g = Guid.NewGuid();
                    string GuidString = Convert.ToBase64String(g.ToByteArray());
                    GuidString = GuidString.Replace("=", "");
                    GuidString = GuidString.Replace("+", "");
                    DataSet update;
                    if (ds.Tables["data"].Rows[0]["login_permit"].ToString() == "")
                    {
                        update = static_class.updatebysql(
                                @"update AK_Users set login_at ='" + DateTime.Now +
                                "',login_to ='" + DateTime.Now.AddMinutes(24 * 60) +
                                "',token ='" + GuidString +
                                "' where id=" + ds.Tables["data"].Rows[0]["Id"]
                                );
                    }
                    else
                    {
                        update = static_class.updatebysql(
                                @"update AK_Users set login_at='" + DateTime.Now +
                                "',login_to='" + DateTime.Now.AddMinutes(Convert.ToInt32(ds.Tables["data"].Rows[0]["login_permit"])) +
                                "',token ='" + GuidString +
                                "' where id=" + ds.Tables["data"].Rows[0]["Id"]
                                );
                    }
                    static_class.insertbysql(
                                @"INSERT INTO dbo.AK_logins
                                (
                                  userid
                                 ,username
                                 ,login_from
                                 ,token
                                )
                                VALUES
                                ('" +
                                 ds.Tables["data"].Rows[0]["Id"] + "','" +
                                 ds.Tables["data"].Rows[0]["UserName"] + "','" +
                                 Request.UserHostAddress + "','" +
                                 GuidString + "'" +
                                 ");"
                                );

                    HttpCookie token = new HttpCookie("token", GuidString);
                    HttpCookie userName = new HttpCookie("UserName", ds.Tables["data"].Rows[0]["UserName"].ToString());
                    token.Expires = DateTime.Now.AddDays(1);
                    userName.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(token);
                    Response.Cookies.Add(userName);
                    output = JsonConvert.SerializeObject(update.Tables[0]);
                }
            }

            //return Content(/*, "application/json"*/); 
            return Content(output, "application/json");
        }
        public ActionResult AK_LogOut()
        {
            Response.Cookies["userName"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["token"].Expires = DateTime.Now.AddDays(-1);
            return RedirectToAction("log", "home");
        }
        public ActionResult test()
        {
            DataSet ds;
            try
            {
                ds = static_class.is_Authrize("shifts", Request.Cookies.Get("token").Value, "p_access");
            }
            catch (Exception)
            {
                return RedirectToAction("Log", "Home");
            }
            if (ds.Tables[0].Rows[0]["status"].ToString() == "error")
            {
                return View("_NotAuthorized");
            }
            else
            {
                ViewBag.perms = static_class.o_Authrizes(Request.Cookies.Get("token").Value);//.AsEnumerable().ToList();
                return View();
            }
            // return Content(JsonConvert.SerializeObject(ds), "application/json");
        }
        public ActionResult meals()
        {
            DataSet ds = static_class.is_Authrize("meals", Request.Cookies.Get("token").Value, "p_access");
            if (ds.Tables[0].Rows[0]["status"].ToString() == "error")
                return View("_NotAuthorized"); //Content(JsonConvert.SerializeObject(ds.Tables[0]), "application/json");

            else
                return View(ds);
        }
        public ActionResult LogOut()
        {
            Response.Cookies["TempShifts"].Expires = DateTime.Now.AddDays(-1);

            return RedirectToAction("log");
        }
        
        /* upload image */
        [HttpPost]
        public ActionResult UploadFiles()
        {
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                        //string filename = Path.GetFileName(Request.Files[i].FileName);  

                        HttpPostedFileBase file = files[i];
                        string fname = file.FileName;

                        // Get the complete folder path and store the file inside it.  
                        fname = Path.Combine(Server.MapPath("~/Uploads/"), fname);
                        file.SaveAs(fname);
                    }
                    // Returns message that successfully uploaded  
                    return Json("File Uploaded Successfully!");
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }
    }
}