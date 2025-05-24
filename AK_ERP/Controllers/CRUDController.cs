using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using AK_HR.Models;

namespace AK_HR.Controllers
{
    public class CRUDController : Controller
    {
        private Entities db = new Entities();
        // GET: CRUD
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult simplest()
        {
            return View();
        }
        public ActionResult Form(string dataObject)
        {
            JObject obj = JObject.Parse(dataObject==null?"{}":dataObject);
            string sql1 = "";
            string sql2 = "";
            foreach (JProperty property in obj.Properties())
            {
                string key = property.Name;
                JToken value = property.Value;
                if (property.Value.Type != JTokenType.Array)
                {
                    sql1 += $"{key},";
                    sql2 += $"'{value}',";
                }
            }
            sql1 = sql1.Substring(0,sql1.Length-1);
            sql2 = sql2.Substring(0,sql2.Length-1);
            
            string sql = $"insert into data({sql1})values({sql2})";

            return Content(sql, "application/json");
        }
        //ai conversion
        public ActionResult InsertRole(string dataObject)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var obj = JObject.Parse(dataObject ?? "{}");

                    // 1. Insert the main role
                    var role = new AK_Roles();

                    foreach (JProperty property in obj.Properties())
                    {
                        if (property.Name != "Roles_Lines" && property.Value.Type != JTokenType.Array)
                        {
                            var propInfo = role.GetType().GetProperty(property.Name);
                            if (propInfo != null)
                            {
                                propInfo.SetValue(role, Convert.ChangeType(property.Value.ToString(), propInfo.PropertyType));
                            }
                        }
                    }

                    db.AK_Roles.Add(role);
                    db.SaveChanges(); // This generates the role_id

                    // 2. Insert role lines if they exist
                    if (obj["Roles_Lines"] != null && obj["Roles_Lines"].Type == JTokenType.Array)
                    {
                        var roleLines = new List<AK_Roles_lines>();

                        foreach (var line in obj["Roles_Lines"])
                        {
                            var roleLine = new AK_Roles_lines
                            {
                                role_id = role.Id // Assuming this is the FK property name
                            };

                            foreach (JProperty lineProperty in line)
                            {
                                if (lineProperty.Value.Type != JTokenType.Array)
                                {
                                    var propInfo = roleLine.GetType().GetProperty(lineProperty.Name);
                                    if (propInfo != null)
                                    {
                                        propInfo.SetValue(roleLine, Convert.ChangeType(lineProperty.Value.ToString(), propInfo.PropertyType));
                                    }
                                }
                            }

                            roleLines.Add(roleLine);
                        }

                        db.AK_Roles_lines.AddRange(roleLines);
                        db.SaveChanges();
                    }

                    transaction.Commit();
                    return Json(new { success = true, role_id = role.Id },JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return Json(new { success = false, error = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
        }
        /********************** helpers ****************************/
        public ActionResult Read(string sql)
                {
                    return Content(JsonConvert.SerializeObject(static_class.getbysql(sql).Tables[1], Formatting.Indented), "application/json");
                }
        public DataSet ReadSql(string sql = "")
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
            DataSet dataSet = new DataSet();
            try
            {
                SqlDataAdapter data = new SqlDataAdapter(sql, connection);
                data.Fill(dataSet, "data");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dataSet;
        }
        /***************************** paging ******************************/
        public string ReadSql(int pageNo = 0, int pageSize = 0, string sql = "")
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
            string json = "{}";
            try
            {
                SqlDataAdapter data = new SqlDataAdapter(sql, connection);
                DataSet dataSet = new DataSet();
                data.Fill(dataSet, (pageNo - 1) < 0 ? 0 : (pageNo - 1) * pageSize, pageSize, "data");
                json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
            }
            catch (Exception ex)
            {
                json = "{error :\"" + ex.Message + "\",data:[]}";
            }
            return json;
        }
        public string GetTable(int pageNo = 0, int pageSize = 0, string table = "")
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString);

            string dataSQL = "SELECT * FROM " + table;
            string metaSQL = "SELECT count(*)count FROM " + table;

            // Assumes that connection is a valid SqlConnection object.  
            SqlDataAdapter meta = new SqlDataAdapter(metaSQL, connection);
            SqlDataAdapter data = new SqlDataAdapter(dataSQL, connection);

            DataSet dataSet = new DataSet();
            meta.Fill(dataSet, "meta");
            data.Fill(dataSet, (pageNo - 1) < 0 ? 0 : (pageNo - 1) * pageSize, pageSize, "data");

            //serialize the data 
            string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
            return json;
        }
       
        public ActionResult GetByTable(int pageNo = 0, int pageSize = 0, string table = "")
        {
            return Content(GetTable(pageNo, pageSize, table), "application/json; charset=utf-8");
        }
        public ActionResult GetBySql(int pageNo = 0, int pageSize = 0, string sql = "")
        {
            return Content(ReadSql(pageNo, pageSize, sql), "application/json; charset=utf-8");
        }
        /********************* api json **************************/
       
        /*********************** db context **************/
        public DataTable getData(string cmdText)
        {

            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(cmdText, con))
                    {
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ahmed kamal=" + ex.Message);
                return null;
            }
            return dt;
        }
        public DataTable getData(SqlCommand cmd)
        {

            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString))
                {

                    using (cmd)
                    {
                        cmd.Connection = con;
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ahmed kamal=" + ex.Message);
                return null;
            }
            return dt;
        }
        public string toJSON(DataTable table)
        {
            return JsonConvert.SerializeObject(table);
        }
        public int exec(SqlCommand com)
        {
            string cs = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    com.Connection = con;
                    com.ExecuteNonQuery();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ahmed kamal=" + ex.Message);
                return 0;
            }
        }
    }
}