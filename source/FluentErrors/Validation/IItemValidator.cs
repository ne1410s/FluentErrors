using FluentErrors.Errors;

namespace FluentErrors.Validation
{
    /// <summary>
    /// Validates an item.
    /// </summary>
    /// <typeparam name="TItem">The item type.</typeparam>
    public interface IItemValidator<TItem>
    {
        /// <summary>
        /// Validates an item.
        /// </summary>
        /// <param name="item">The item to validate.</param>
        /// <exception cref="ValidationError"/>
        public void AssertValid(TItem item);
    }
}