using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace AK_HR.Controllers
{
    public class CRUDController : Controller
    {
        // GET: CRUD
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult simplest()
        {
            return View();
        }
        public ActionResult Form(string data)
        {
            JObject obj = JObject.Parse(data==null?"{}":data);
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
        public ActionResult GetSQL(string t="",string json="")
        {
             json = "{'a':'aaa','b':'bbb','c':'ccc'}";
            
            JObject resJson = JObject.Parse(json);
            resJson["name"] = "ahmed kamal";
            var v = resJson.CreateReader();
            
            return Content(resJson["name"].ToString(), "application/json; charset=utf-8");
        }
        /************************ test area ************************/
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