using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsERP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string InsertFromObject(string table,JObject obj)
        {
            
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
            sql1 = sql1.Length > 0 ? sql1.Substring(0, sql1.Length - 1) : sql1;
            sql2 = sql2.Length > 0 ? sql2.Substring(0, sql2.Length - 1) : sql2;

            string sql = $"insert into [{table}]({sql1})values({sql2});";
            return sql;
        }
        string InsertFromObject(string table,string fkKey,object fkValue,JArray arr)
        {
            string sql1 = $"{fkKey},";
            string sql2 = "";
            //   all keys
            foreach (JProperty property in ((JObject)arr[0]).Properties())
            {
                string key = property.Name;
                if (property.Value.Type != JTokenType.Array)
                {
                    sql1 += $"{key},";                  
                }
            }
            sql1 = sql1.Length > 0 ? sql1.Substring(0, sql1.Length - 1) : sql1;
            //     all values
            for (int i = 0; i < arr.Count; i++)
            {
                sql2 += $"('{fkValue}',";
                foreach (JProperty property in ((JObject)arr[i]).Properties())
                {
                    JToken value = property.Value;
                    sql2 += $"'{value}',";
                }
                sql2 = sql2.Length > 0 ? sql2.Substring(0, sql2.Length - 1) : sql2;
                sql2 += "),";
            }
            sql2 = sql2.Length > 0 ? sql2.Substring(0, sql2.Length - 1) : sql2;
            
            string sql = $"insert into [{table}]({sql1})values{sql2};";
            return sql;
        }
        string UpdateFromObject(string table,string idKey ,object idValue, JObject obj)
        {

            string sql1 = "";
            foreach (JProperty property in obj.Properties())
            {
                string key = property.Name;
                JToken value = property.Value;
                if (property.Value.Type != JTokenType.Array)
                {
                    sql1 += $"{key}='{value}',";
                }
            }
            sql1 = sql1.Length > 0 ? sql1.Substring(0, sql1.Length - 1) : sql1;
            //sql2 = sql2.Length > 0 ? sql2.Substring(0, sql2.Length - 1) : sql2;

            string sql = $"update  [{table}] set {sql1} where {idKey}={idValue};";
            return sql;
        }
        string UpdateFromObject(string table, string fkKey, object fkValue, JArray arr)
        {
            string sql1 = "";
            string sql2 = "";
            string sql = "";
            sql1 = sql1.Length > 0 ? sql1.Substring(0, sql1.Length - 1) : sql1;
            //     all values
            for (int i = 0; i < arr.Count; i++)
            {
                sql2 = "";
                sql1 = $"update [{table}] set ";
                foreach (JProperty property in ((JObject)arr[i]).Properties())
                {
                    string key = property.Name;
                    JToken value = property.Value;
                    if (key.ToLower() != "id") sql1 += $"{key}= '{value}',";
                    else sql2 += $" where {fkKey}={fkValue} and id= {value};";
                }
                sql1 = sql1.Length > 0 ? sql1.Substring(0, sql1.Length - 1) : sql1;
                if (sql2.Contains("id")) sql += sql1 + sql2;
            }
            return sql;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                new Roles().Show();
            }
            catch (Exception)
            {

               // throw;
            }
           // JObject obj = JObject.Parse(textBox1.Text == null ? "{}" : textBox1.Text);
            /* for (int i = 0; i < obj["Work"].ToList().Count; i++)
            {
                textBox2.Text += InsertFromObject((JObject)obj["Work"][i]);
            }*/
            //textBox2.Text = InsertFromObject("Roles Line","RoleId","2",((JArray)obj["Work"]));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            JObject obj = JObject.Parse(textBox1.Text == null ? "{}" : textBox1.Text);
            textBox2.Text = InsertFromObject("Roles",obj);
            textBox2.Text += System.Environment.NewLine;
            textBox2.Text += InsertFromObject("Roles Line", "RoleId", "1", ((JArray)obj["Work"]));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            JObject obj = JObject.Parse(textBox1.Text == null ? "{}" : textBox1.Text);
            textBox2.Text = UpdateFromObject("Roles","Id",1, obj);
            textBox2.Text += System.Environment.NewLine; 
            textBox2.Text += UpdateFromObject("Roles Line", "RoleId", "1", ((JArray)obj["Work"]));
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Users().Show();
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Roles().Show();
        }

        private void modulesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Modules().Show(); 
        }

        private void sideBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Sidebar().Show();
        }
    }
}
 