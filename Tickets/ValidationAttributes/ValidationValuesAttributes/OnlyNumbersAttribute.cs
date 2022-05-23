using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Tickets.ValidationAttributes.ValidationValuesAttributes
{
    public class OnlyNumbersAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string s)
            {
                return s.All(char.IsNumber);
            }
            else
            {
                ErrorMessage = $"Non-numbers value passed to {nameof(OnlyNumbersAttribute)}";
                return false;
            }
        }
    }
}