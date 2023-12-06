/*
 * ITSE 1430
 * Product Database Project
 * Name: Jonathan Brosnan
 * Lab 4 Final
 * Last Updated: 12/06/23
 */
namespace Nile.Stores
{
    /// <summary>Base class for product database.</summary>
    public abstract class ProductDatabase : IProductDatabase
    {

        #region IProductDatabase Members
        /// <inheritdoc />
        public Product Add ( Product product )
        {
            
            if (product.Id < 0)
                throw new ArgumentOutOfRangeException(nameof(product.Id), "ID must be greater than or equal to 0");
            
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            ObjectValidator.Validate(product);

            var exists = FindByName(product.Name);
            if (exists != null)
                throw new InvalidOperationException("Product name must be unique");

            try
            {
                return AddCore(product);
            } catch (Exception e)
            {
                throw new InvalidOperationException("Add failed", e);
            };
        }

        /// <inheritdoc />
        public Product Get ( int id )
        {

            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than or equal to 0");
          
            try
            {
                return GetCore(id);
            } catch (Exception e)
            {
                throw new InvalidOperationException("Get failed", e);
            };
        }

        /// <inheritdoc />
        public IEnumerable<Product> GetAll() => GetAllCore() ?? Enumerable.Empty<Product>();

        /// <inheritdoc />
        public void Remove ( int id )
        {

            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than or equal to 0");

            try
            {
                RemoveCore(id);
            } catch (Exception e)
            {
                throw new InvalidOperationException("Remove failed", e);
            };
        }

        /// <inheritdoc />
        public Product Update ( Product product )
        {
            
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            int id = product.Id;
            
            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater or equal than 0");

            ObjectValidator.Validate(product);

            //Name must be unique (and not self)
            var existing = FindByName(product.Name);
            if (existing != null && existing.Id != id)
                throw new InvalidOperationException("Product name must be unique");

            //Product must exist
            existing = FindProduct(id);
            if (existing == null)
                throw new ArgumentException("Product not found", nameof(id));

            try
            {
                return UpdateCore(existing, product);
            } catch (Exception e)
            {
                throw new InvalidOperationException("Update failed", e);
            };

            
        }

        #endregion

        #region Protected Members

        /// <summary>Gets a product.</summary>
        /// <param name="id">ID of the product.</param>
        /// <returns>The product, if found.</returns>
        protected abstract Product GetCore( int id );


        /// <summary>Gets the products in the database.</summary>
        /// <returns>The list of product.</returns>
        protected abstract IEnumerable<Product> GetAllCore();

        /// <summary>Removes a product.</summary>
        /// <param name="id">ID of the product.</param>
        protected abstract void RemoveCore( int id );

        /// <summary>Updates a product in the database.</summary>
        /// <param name="existing">The existing product</param>
        /// <param name="newItem">The product with the new information.</param>
        /// <returns> The product that has just been updated</returns>
        protected abstract Product UpdateCore ( Product existing, Product newItem );

        /// <summary>Adds a product to the database.</summary>
        /// <param name="product">product to add.</param>
        /// <returns>Updated product.</returns>
        protected abstract Product AddCore( Product product );

        /// <summary>Finds a product by its ID.</summary>
        /// <param name="id">ID of the product.</param>
        /// <returns>The product, if any.</returns>
        protected abstract Product FindProduct ( int id );

        /// <summary>Finds a product by its title.</summary>
        /// <param name="name">Title of the product.</param>
        /// <returns>The product, if any.</returns>
        protected abstract Product FindByName ( string name );
        #endregion
    }
}
