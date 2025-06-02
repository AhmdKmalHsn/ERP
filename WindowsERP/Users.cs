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
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        private void ak_UsersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.ak_UsersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this._2025DataSet);

        }

        private void Users_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_2025DataSet.AK_Roles' table. You can move, or remove it, as needed.
            this.aK_RolesTableAdapter.Fill(this._2025DataSet.AK_Roles);
            // TODO: This line of code loads data into the '_2025DataSet.Ak_Users' table. You can move, or remove it, as needed.
            this.ak_UsersTableAdapter.Fill(this._2025DataSet.Ak_Users);

        }
    }
}
