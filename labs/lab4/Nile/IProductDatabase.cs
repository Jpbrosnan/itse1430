/*
 * ITSE 1430
 * Product Database Project
 * Name: Jonathan Brosnan
 * Lab 4 Final
 * Last Updated: 12/06/23
 */
namespace Nile
{
    /// <summary>Provides a database of <see cref="Product"/> items.</summary>
    public interface IProductDatabase
    {
        /// <summary>Adds a product.</summary>
        /// <param name="product">The product to add.</param>
        /// <returns>The added product.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="product"/> is null.</exception>
        /// <exception cref="ValidationException"><paramref name="product"/> is invalid.</exception>
        /// <exception cref="InvalidOperationException">Product name is not unique.</exception>    
        Product Add ( Product product );

        /// <summary>Get a specific product.</summary>
        /// <param name="id">ID of the product.</param>
        /// <returns>The product, if it exists.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="id"/> is less than or equal to zero.</exception>
        Product Get ( int id );

        /// <summary>Gets all products.</summary>
        /// <returns>The products.</returns>
        IEnumerable<Product> GetAll ();

        /// <summary>Removes the product.</summary>
        /// <param name="id">The product to remove.</param>
        /// /// <exception cref="ArgumentOutOfRangeException"><paramref name="id"/> is less than or equal to zero.</exception>
        void Remove ( int id );

        /// <summary>Updates a product.</summary>
        /// <param name="product">The product to update.</param>
        /// <returns>The updated product.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="product"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="id"/> is less than or equal to zero.</exception>
        /// <exception cref="ArgumentException">Product does not exist.</exception>
        /// <exception cref="ValidationException"><paramref name="product"/> is invalid.</exception>
        /// <exception cref="InvalidOperationException">Product name is not unique.</exception>
        Product Update ( Product product );
    }
}