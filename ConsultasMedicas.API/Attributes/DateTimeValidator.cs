using System.ComponentModel.DataAnnotations;

namespace ConsultasMedicas.API.Attributes
{
    public class DateTimeValidator : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is DateTime date)
            {
                date = Convert.ToDateTime(value);
                return date >= DateTime.Now;
            }
            return false;
        }
    }
}
