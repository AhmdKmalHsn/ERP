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
    public partial class Roles : Form
    {
        public Roles()
        {
            InitializeComponent();
        }

        private void aK_RolesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.aK_RolesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this._2025DataSet);

        }

        private void Roles_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_2025DataSet.AK_Modules' table. You can move, or remove it, as needed.
            this.aK_ModulesTableAdapter.Fill(this._2025DataSet.AK_Modules);
            // TODO: This line of code loads data into the '_2025DataSet.AK_Roles_lines' table. You can move, or remove it, as needed.
            this.aK_Roles_linesTableAdapter.Fill(this._2025DataSet.AK_Roles_lines);
            // TODO: This line of code loads data into the '_2025DataSet.AK_Roles' table. You can move, or remove it, as needed.
            this.aK_RolesTableAdapter.Fill(this._2025DataSet.AK_Roles);

        }
    }
}
