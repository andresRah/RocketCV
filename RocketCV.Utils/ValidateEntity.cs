namespace RocketCV.Utils
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Validate Entity
    /// </summary>
    public static class ValidateEntity
    {
        /// <summary>
        /// Validates the specified entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public static IList<string> Validate<T>(this T entity) where T : class, new()
        {
            var contextValidator = new ValidationContext(entity);
            var errors = new List<ValidationResult>();
            var response = new List<string>();
            Validator.TryValidateObject(entity, contextValidator, errors, true);
            errors.ForEach(e => response.Add(e.ErrorMessage));
            return response;
        }
    }
}
