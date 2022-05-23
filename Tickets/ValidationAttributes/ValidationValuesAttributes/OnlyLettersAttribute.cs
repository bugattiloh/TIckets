using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Tickets.ValidationAttributes.ValidationValuesAttributes
{
    public class OnlyLettersAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string s)
            {
                return s.All(char.IsLetter);
            }
            else
            {
                ErrorMessage = $"Non-string value passed to {nameof(OnlyLettersAttribute)}";
                return false;
            }
        }
    }
}