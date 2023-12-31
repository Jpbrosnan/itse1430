/*
 * ITSE 1430
 * Product Database Project
 * Name: Jonathan Brosnan
 * Lab 4 Final
 * Last Updated: 12/06/23
 */
using Microsoft.VisualBasic.Devices;

namespace Nile.Windows
{
    /// <summary>
    /// Form used for the main startup screen of the program.
    /// </summary>
    public partial class MainForm : Form
    {

        public MainForm ()
        {
            InitializeComponent();
        }
        
        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            _gridProducts.AutoGenerateColumns = false;

            UpdateList();
        }

        #region Event Handlers

        private void OnFileExit ( object sender, EventArgs e )
        {
            Close();
        }

        private void OnProductAdd ( object sender, EventArgs e )
        {
            var child = new ProductDetailForm("Product Details");
            if (child ==  null)
                return;
            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {
                    //Save Product        
                    _database.Add(child.Product);
                    break;
                } catch (NotImplementedException)
                {
                    //I really cannot do anything about this but I'll try...
                    throw;
                } catch (InvalidOperationException)
                {
                    MessageBox.Show(this, "Product already exists", "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } catch (ArgumentException)
                {
                    MessageBox.Show(this, "Argument Product Error", "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } catch (Exception ex)
                {
                    //Error handling
                    MessageBox.Show(this, ex.Message, "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                };
            } while (true);


            UpdateList();
        }

        private void OnProductEdit ( object sender, EventArgs e )
        {
       
            var product = GetSelectedProduct();
            if (product != null)
                EditProduct(product);
            else
                MessageBox.Show(this, "No Product to Edit", "Edit Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            


        }

        private void OnProductDelete ( object sender, EventArgs e )
        {
            
            
            var product = GetSelectedProduct();
            if (product != null)
                DeleteProduct(product);
            else
                MessageBox.Show(this, "No Products to Delete", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            

        }

        private void OnEditRow ( object sender, DataGridViewCellEventArgs e )
        {
            var grid = sender as DataGridView;

            //Handle column clicks
            if (e.RowIndex < 0)
                return;

            var row = grid.Rows[e.RowIndex];
            var item = row.DataBoundItem as Product;

            if (item != null)
                EditProduct(item);
        }

        private void OnKeyDownGrid ( object sender, KeyEventArgs e )
        {
            if (e.KeyCode != Keys.Delete)
                return;

            var product = GetSelectedProduct();
            if (product != null)
                DeleteProduct(product);

            //Don't continue with key
            e.SuppressKeyPress = true;
        }

        //AboutBox
        private void helpAboutToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            var about = new AboutBox1();
            about.ShowDialog(this);
        }
        #endregion

        #region Private Members

        private void DeleteProduct ( Product product )
        {
           
            if (MessageBox.Show(this, $"Are you sure you want to delete '{product.Name}'?",
                                "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;


            try
            {
                _database.Remove(product.Id);
                UpdateList();

            } catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }

        private void EditProduct ( Product product )
        {
            

            var child = new ProductDetailForm();
            child.Product = product;
            
            
            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {
                    _database.Update(child.Product);
                    break;
                } catch (InvalidOperationException e)
                {
                    MessageBox.Show(this, e.Message, "Updated Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } catch (ArgumentException e)
                {
                    MessageBox.Show(this, e.Message, "Updated Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } catch (Exception ex)
                {
                    
                    MessageBox.Show(this, ex.Message, "Updated Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                };
            } while (true);

            UpdateList();
        }

        private Product GetSelectedProduct ()
        {
            if (_gridProducts.SelectedRows.Count > 0)
                return _gridProducts.SelectedRows[0].DataBoundItem as Product;

            return null;
        }

        private void UpdateList ()
        {
            
            IEnumerable<Product> products = null;
            try
            {
                products = _database.GetAll();
                products = from p in products
                         orderby p.Name, p.Price descending
                         select p;
            } catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Update List Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally
            {
                _bsProducts.DataSource = products?.ToArray(); 


            };

        }

        private readonly IProductDatabase _database = new Nile.Stores.SqlProductDatabase(Program.GetConnectionString("ProductDatabase"));
        #endregion

    }
}
