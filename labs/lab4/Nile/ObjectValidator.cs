/*
 * ITSE 1430
 * Product Database Project
 * Name: Jonathan Brosnan
 * Lab 4 Final
 * Last Updated: 12/06/23
 */

using System.ComponentModel.DataAnnotations;

namespace Nile;

/// <summary>Provides support for validating objects.</summary>
public static class ObjectValidator
{
    /// <summary>Tries to validate an object.</summary>
    /// <param name="value">Value to validate.</param>
    /// <param name="results">Validation results.</param>
    /// <returns>true if valid or false otherwise.</returns>
    public static bool TryValidate ( IValidatableObject value, out IEnumerable<ValidationResult> results )
    {
        var context = new ValidationContext(value);

        var items = new System.Collections.ObjectModel.Collection<ValidationResult>();

        if (Validator.TryValidateObject(value, context, items, true))
        {
            results = new ValidationResult[0];
            return true;
        };

        results = items;
        return false;
    }

    /// <summary>Validates an object.</summary>
    /// <param name="value">Value to validate.</param>
    /// <exception cref="ValidationException"><paramref name="value"/> is invalid.</exception>
    public static void Validate ( IValidatableObject value )
    {
        var context = new ValidationContext(value);

        Validator.ValidateObject(value, context, true);
    }
}
