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
    public partial class ModulesCategory : Form
    {
        public ModulesCategory()
        {
            InitializeComponent();
        }

        private void aK_CategoriesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.aK_CategoriesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this._2025DataSet);

        }

        private void ModulesCategory_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_2025DataSet.AK_Categories' table. You can move, or remove it, as needed.
            this.aK_CategoriesTableAdapter.Fill(this._2025DataSet.AK_Categories);

        }
    }
}
