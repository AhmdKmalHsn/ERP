using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsERP
{
    public partial class Sidebar : Form
    {
        public Sidebar()
        {
            InitializeComponent();
        }

        private void aK_SidebarBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.aK_SidebarBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this._2025DataSet);

        }

        private void Sidebar_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_2025DataSet.AK_Sidebar' table. You can move, or remove it, as needed.
            this.aK_SidebarTableAdapter.Fill(this._2025DataSet.AK_Sidebar);

        }
    }
}
