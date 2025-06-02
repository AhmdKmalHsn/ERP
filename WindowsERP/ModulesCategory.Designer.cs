namespace WindowsERP
{
    partial class ModulesCategory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModulesCategory));
            this._2025DataSet = new WindowsERP._2025DataSet();
            this.aK_CategoriesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aK_CategoriesTableAdapter = new WindowsERP._2025DataSetTableAdapters.AK_CategoriesTableAdapter();
            this.tableAdapterManager = new WindowsERP._2025DataSetTableAdapters.TableAdapterManager();
            this.aK_CategoriesBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.aK_CategoriesBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.aK_CategoriesDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this._2025DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aK_CategoriesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aK_CategoriesBindingNavigator)).BeginInit();
            this.aK_CategoriesBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aK_CategoriesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // _2025DataSet
            // 
            this._2025DataSet.DataSetName = "_2025DataSet";
            this._2025DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // aK_CategoriesBindingSource
            // 
            this.aK_CategoriesBindingSource.DataMember = "AK_Categories";
            this.aK_CategoriesBindingSource.DataSource = this._2025DataSet;
            // 
            // aK_CategoriesTableAdapter
            // 
            this.aK_CategoriesTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.AK_CategoriesTableAdapter = this.aK_CategoriesTableAdapter;
            this.tableAdapterManager.AK_loginsTableAdapter = null;
            this.tableAdapterManager.AK_ModulesTableAdapter = null;
            this.tableAdapterManager.AK_Roles_linesTableAdapter = null;
            this.tableAdapterManager.AK_RolesTableAdapter = null;
            this.tableAdapterManager.AK_SidebarTableAdapter = null;
            this.tableAdapterManager.Ak_UsersTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.UpdateOrder = WindowsERP._2025DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // aK_CategoriesBindingNavigator
            // 
            this.aK_CategoriesBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.aK_CategoriesBindingNavigator.BindingSource = this.aK_CategoriesBindingSource;
            this.aK_CategoriesBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.aK_CategoriesBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.aK_CategoriesBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.aK_CategoriesBindingNavigatorSaveItem});
            this.aK_CategoriesBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.aK_CategoriesBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.aK_CategoriesBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.aK_CategoriesBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.aK_CategoriesBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.aK_CategoriesBindingNavigator.Name = "aK_CategoriesBindingNavigator";
            this.aK_CategoriesBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.aK_CategoriesBindingNavigator.Size = new System.Drawing.Size(492, 25);
            this.aK_CategoriesBindingNavigator.TabIndex = 0;
            this.aK_CategoriesBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 15);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 6);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 6);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // aK_CategoriesBindingNavigatorSaveItem
            // 
            this.aK_CategoriesBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.aK_CategoriesBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("aK_CategoriesBindingNavigatorSaveItem.Image")));
            this.aK_CategoriesBindingNavigatorSaveItem.Name = "aK_CategoriesBindingNavigatorSaveItem";
            this.aK_CategoriesBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 23);
            this.aK_CategoriesBindingNavigatorSaveItem.Text = "Save Data";
            this.aK_CategoriesBindingNavigatorSaveItem.Click += new System.EventHandler(this.aK_CategoriesBindingNavigatorSaveItem_Click);
            // 
            // aK_CategoriesDataGridView
            // 
            this.aK_CategoriesDataGridView.AutoGenerateColumns = false;
            this.aK_CategoriesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.aK_CategoriesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.aK_CategoriesDataGridView.DataSource = this.aK_CategoriesBindingSource;
            this.aK_CategoriesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aK_CategoriesDataGridView.Location = new System.Drawing.Point(0, 25);
            this.aK_CategoriesDataGridView.Name = "aK_CategoriesDataGridView";
            this.aK_CategoriesDataGridView.Size = new System.Drawing.Size(492, 239);
            this.aK_CategoriesDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn2.HeaderText = "name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // ModulesCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 264);
            this.Controls.Add(this.aK_CategoriesDataGridView);
            this.Controls.Add(this.aK_CategoriesBindingNavigator);
            this.Name = "ModulesCategory";
            this.Text = "ModulesCategory";
            this.Load += new System.EventHandler(this.ModulesCategory_Load);
            ((System.ComponentModel.ISupportInitialize)(this._2025DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aK_CategoriesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aK_CategoriesBindingNavigator)).EndInit();
            this.aK_CategoriesBindingNavigator.ResumeLayout(false);
            this.aK_CategoriesBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aK_CategoriesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private _2025DataSet _2025DataSet;
        private System.Windows.Forms.BindingSource aK_CategoriesBindingSource;
        private _2025DataSetTableAdapters.AK_CategoriesTableAdapter aK_CategoriesTableAdapter;
        private _2025DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator aK_CategoriesBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton aK_CategoriesBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView aK_CategoriesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}