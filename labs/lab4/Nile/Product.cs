/*
 * ITSE 1430
 * Product Database Project
 * Name: Jonathan Brosnan
 * Lab 4 Final
 * Last Updated: 12/06/23
 */
using System.ComponentModel.DataAnnotations;

namespace Nile
{
    /// <summary>Represents a product.</summary>
    public class Product : IValidatableObject
    {
        /// <summary>Gets or sets the unique identifier.</summary>
        public int Id { get; set; }

        /// <summary>Gets or sets the name.</summary>
        /// <value>Never returns null.</value>
        public string Name
        {
            get { return _name ?? ""; }
            set { _name = value?.Trim() ?? ""; }
        } 
        
        /// <summary>Gets or sets the description.</summary>
        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value?.Trim() ?? ""; }
        }

        /// <summary>Gets or sets the price.</summary>
        public decimal Price { get; set; } = 0;

        /// <summary>Determines if discontinued.</summary>
        public bool IsDiscontinued { get; set; } = false;

        /// <inheritdoc />
        public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        {
            
            if (Id < 0)
                yield return new ValidationResult("Id must be greater than or equal to 0");
            if (String.IsNullOrEmpty(_name))
                yield return new ValidationResult("Name is required");
            if (Price < 0)
                yield return new ValidationResult("Price must be greater than or equal to 0");
            if(Price >= Decimal.MaxValue)
                yield return new ValidationResult("Price value is too large");


        }

        #region Private Members

        private string _name;
        private string _description;
        #endregion
    }
}
