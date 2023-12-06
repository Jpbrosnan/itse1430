/*
 * ITSE 1430
 * Product Database Project
 * Name: Jonathan Brosnan
 * Lab 4 Final
 * Last Updated: 12/06/23
 */
using System.ComponentModel;



namespace Nile.Windows
{
    /// <summary>
    /// Form used for product create/edit functionality.
    /// </summary>
    public partial class ProductDetailForm : Form
    {
        #region Construction

        public ProductDetailForm () //: base()
        {
            InitializeComponent();            
        }
        
        public ProductDetailForm ( string title ) : this()
        {
            Text = title;
        }

        public ProductDetailForm( string title, Product product ) : this(title)
        {
            Product = product;
        }
        #endregion
        
        /// <summary>Gets or sets the product being shown.</summary>
        public Product Product { get; set; }

        /// <summary>
        /// Called to init form just before it is shown.
        /// </summary>
        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            //Load product data, if any
            if (Product != null)
            {
                _txtName.Text = Product.Name;
                _txtDescription.Text = Product.Description;
                _txtPrice.Text = Product.Price.ToString();
                _chkDiscontinued.Checked = Product.IsDiscontinued;
            };

            ValidateChildren();
        }

        #region Event Handlers

        private void OnCancel ( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OnSave ( object sender, EventArgs e )
        {

            //Validate and abort if necessary
            if (!ValidateChildren())
            {
                DialogResult = DialogResult.None;
                return;
            };

            //Populate from the UI
            var product = new Product()
            {
                Id = Product?.Id ?? 0,
                Name = _txtName.Text,
                Description = _txtDescription.Text,
                Price = GetPrice(_txtPrice),
                IsDiscontinued = _chkDiscontinued.Checked,
            };

            
            if (!ObjectValidator.TryValidate(product, out var results))
            {
                var error = results.First();
                MessageBox.Show(this, error.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.None;
                return;
            };
            Product = product;
            DialogResult = DialogResult.OK;
            Close();
        }
        
        private void OnValidatingName ( object sender, CancelEventArgs e )
        {
            var tb = sender as TextBox;
            if (String.IsNullOrEmpty(tb.Text))
                _errors.SetError(tb, "Name is required");
            else
                _errors.SetError(tb, "");
        }

        private void OnValidatingPrice ( object sender, CancelEventArgs e )
        {
            var tb = sender as TextBox;

            if (GetPrice(tb) < 0)
            {
                e.Cancel = true;
                _errors.SetError(_txtPrice, "Price must be greater than or equal to 0 && less than Decimal.MaxValue");

            } else
                _errors.SetError(_txtPrice, "");
        }
        #endregion

        #region Private Members

        private decimal GetPrice ( TextBox control )
        {
            if (Decimal.TryParse(control.Text, out var price))
                return price;

            //Validate price            
            return -1;
        }                      
        #endregion
    }
}
