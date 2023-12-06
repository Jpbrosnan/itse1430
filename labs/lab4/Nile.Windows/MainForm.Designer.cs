namespace Nile.Windows
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
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
        private void InitializeComponent ()
        {
            components=new System.ComponentModel.Container();
            var dataGridViewCellStyle3 = new DataGridViewCellStyle();
            _mainMenu=new MenuStrip();
            fileToolStripMenuItem=new ToolStripMenuItem();
            _miFileExit=new ToolStripMenuItem();
            productToolStripMenuItem=new ToolStripMenuItem();
            _miProductAdd=new ToolStripMenuItem();
            _miProductEdit=new ToolStripMenuItem();
            toolStripSeparator1=new ToolStripSeparator();
            _miProductDelete=new ToolStripMenuItem();
            toolStripMenuItem1=new ToolStripMenuItem();
            _gridProducts=new DataGridView();
            colId=new DataGridViewTextBoxColumn();
            colName=new DataGridViewTextBoxColumn();
            colDescription=new DataGridViewTextBoxColumn();
            colPrice=new DataGridViewTextBoxColumn();
            colDiscontinued=new DataGridViewCheckBoxColumn();
            _bsProducts=new BindingSource(components);
            helpAboutToolStripMenuItem=new ToolStripMenuItem();
            _mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_gridProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_bsProducts).BeginInit();
            SuspendLayout();
            // 
            // _mainMenu
            // 
            _mainMenu.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, productToolStripMenuItem, toolStripMenuItem1 });
            _mainMenu.Location=new Point(0, 0);
            _mainMenu.Name="_mainMenu";
            _mainMenu.Padding=new Padding(7, 2, 0, 2);
            _mainMenu.Size=new Size(965, 24);
            _mainMenu.TabIndex=0;
            _mainMenu.Text="menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _miFileExit });
            fileToolStripMenuItem.Name="fileToolStripMenuItem";
            fileToolStripMenuItem.Size=new Size(37, 20);
            fileToolStripMenuItem.Text="&File";
            // 
            // _miFileExit
            // 
            _miFileExit.Name="_miFileExit";
            _miFileExit.ShortcutKeys=Keys.Alt|Keys.F4;
            _miFileExit.Size=new Size(135, 22);
            _miFileExit.Text="E&xit";
            _miFileExit.Click+=OnFileExit;
            // 
            // productToolStripMenuItem
            // 
            productToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _miProductAdd, _miProductEdit, toolStripSeparator1, _miProductDelete });
            productToolStripMenuItem.Name="productToolStripMenuItem";
            productToolStripMenuItem.Size=new Size(61, 20);
            productToolStripMenuItem.Text="&Product";
            // 
            // _miProductAdd
            // 
            _miProductAdd.Name="_miProductAdd";
            _miProductAdd.ShortcutKeys=Keys.Insert;
            _miProductAdd.Size=new Size(131, 22);
            _miProductAdd.Text="&Add";
            _miProductAdd.Click+=OnProductAdd;
            // 
            // _miProductEdit
            // 
            _miProductEdit.Name="_miProductEdit";
            _miProductEdit.Size=new Size(131, 22);
            _miProductEdit.Text="&Edit";
            _miProductEdit.Click+=OnProductEdit;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name="toolStripSeparator1";
            toolStripSeparator1.Size=new Size(128, 6);
            // 
            // _miProductDelete
            // 
            _miProductDelete.Name="_miProductDelete";
            _miProductDelete.ShortcutKeys=Keys.Delete;
            _miProductDelete.Size=new Size(131, 22);
            _miProductDelete.Text="&Delete";
            _miProductDelete.Click+=OnProductDelete;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { helpAboutToolStripMenuItem });
            toolStripMenuItem1.Name="toolStripMenuItem1";
            toolStripMenuItem1.Size=new Size(82, 20);
            toolStripMenuItem1.Text="Help\\About";
            // 
            // _gridProducts
            // 
            _gridProducts.AllowUserToAddRows=false;
            _gridProducts.AllowUserToDeleteRows=false;
            _gridProducts.AllowUserToResizeRows=false;
            dataGridViewCellStyle3.BackColor=Color.FromArgb(224, 224, 224);
            _gridProducts.AlternatingRowsDefaultCellStyle=dataGridViewCellStyle3;
            _gridProducts.AutoGenerateColumns=false;
            _gridProducts.ColumnHeadersHeightSizeMode=DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _gridProducts.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colDescription, colPrice, colDiscontinued });
            _gridProducts.DataSource=_bsProducts;
            _gridProducts.Dock=DockStyle.Fill;
            _gridProducts.Location=new Point(0, 24);
            _gridProducts.Margin=new Padding(4, 3, 4, 3);
            _gridProducts.Name="_gridProducts";
            _gridProducts.ReadOnly=true;
            _gridProducts.RowHeadersVisible=false;
            _gridProducts.RowHeadersWidthSizeMode=DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            _gridProducts.SelectionMode=DataGridViewSelectionMode.FullRowSelect;
            _gridProducts.Size=new Size(965, 412);
            _gridProducts.TabIndex=1;
            _gridProducts.CellDoubleClick+=OnEditRow;
            _gridProducts.KeyDown+=OnKeyDownGrid;
            // 
            // colId
            // 
            colId.DataPropertyName="Id";
            colId.HeaderText="Id";
            colId.Name="colId";
            colId.ReadOnly=true;
            colId.Visible=false;
            // 
            // colName
            // 
            colName.DataPropertyName="Name";
            colName.HeaderText="Name";
            colName.Name="colName";
            colName.ReadOnly=true;
            colName.Width=200;
            // 
            // colDescription
            // 
            colDescription.AutoSizeMode=DataGridViewAutoSizeColumnMode.Fill;
            colDescription.DataPropertyName="Description";
            colDescription.HeaderText="Description";
            colDescription.Name="colDescription";
            colDescription.ReadOnly=true;
            // 
            // colPrice
            // 
            colPrice.DataPropertyName="Price";
            colPrice.HeaderText="Price";
            colPrice.Name="colPrice";
            colPrice.ReadOnly=true;
            // 
            // colDiscontinued
            // 
            colDiscontinued.DataPropertyName="IsDiscontinued";
            colDiscontinued.HeaderText="Discontinued";
            colDiscontinued.Name="colDiscontinued";
            colDiscontinued.ReadOnly=true;
            // 
            // _bsProducts
            // 
            _bsProducts.AllowNew=false;
            // 
            // helpAboutToolStripMenuItem
            // 
            helpAboutToolStripMenuItem.Name="helpAboutToolStripMenuItem";
            helpAboutToolStripMenuItem.ShortcutKeys=Keys.F1;
            helpAboutToolStripMenuItem.Size=new Size(180, 22);
            helpAboutToolStripMenuItem.Text="Help\\About";
            helpAboutToolStripMenuItem.Click+=helpAboutToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(965, 436);
            Controls.Add(_gridProducts);
            Controls.Add(_mainMenu);
            MainMenuStrip=_mainMenu;
            Margin=new Padding(4, 3, 4, 3);
            MaximizeBox=false;
            Name="MainForm";
            Text="Nile";
            _mainMenu.ResumeLayout(false);
            _mainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_gridProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)_bsProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip _mainMenu;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem _miFileExit;
        private ToolStripMenuItem productToolStripMenuItem;
        private ToolStripMenuItem _miProductAdd;
        private ToolStripMenuItem _miProductEdit;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem _miProductDelete;
        private DataGridView _gridProducts;
        private BindingSource _bsProducts;
        //private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn isDiscontinuedDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colDescription;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewCheckBoxColumn colDiscontinued;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem helpAboutToolStripMenuItem;
    }
}

