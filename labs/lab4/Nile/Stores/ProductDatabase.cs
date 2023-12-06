/*
 * ITSE 1430
 */
using MovieLibrary;

namespace Nile.Stores
{
    /// <summary>Base class for product database.</summary>
    public abstract class ProductDatabase : IProductDatabase
    {        
        /// <inheritdoc />
        public Product Add ( Product product )
        {
            //TODO: Check arguments

            //TODO: Validate product
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
            //TODO: Check arguments

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
        /*
        public IEnumerable<Product> GetAll ()
        {
            return GetAllCore();
        }
        */
        public IEnumerable<Product> GetAll() => GetAllCore() ?? Enumerable.Empty<Product>();
        /// <inheritdoc />
        public void Remove ( int id )
        {
            //TODO: Check arguments

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
            //TODO: Check arguments

            if (product == null)
                throw new ArgumentNullException(nameof(product));

            int id = product.Id;
            //TODO: Validate product
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

            //TODO: Could still fails
            try
            {
                return UpdateCore(existing, product);
            } catch (Exception e)
            {
                throw new InvalidOperationException("Update failed", e);
            };

            //Get existing product
            /*
            var existing = GetCore(product.Id);

            return UpdateCore(existing, product);
            */
        }

        #region Protected Members

        protected abstract Product GetCore( int id );

        protected abstract IEnumerable<Product> GetAllCore();

        protected abstract void RemoveCore( int id );

        protected abstract Product UpdateCore ( Product existing, Product newItem );
        protected abstract Product AddCore( Product product );

        protected abstract Product FindProduct ( int id );

        protected abstract Product FindByName ( string name );
        #endregion
    }
}
