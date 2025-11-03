using System.Text.RegularExpressions;
using WebApplication4dg.sqrs.Registration;
using WebApplication4dg.Validators.Behavior;

namespace WebApplication4dg.Validators
{
    public class RegisterValidators : IValidator<Register>
    {
        private readonly static string emailPattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
        private readonly static string phonePattern = @"^+\d{11}";
        public async Task<IEnumerable<string>> ValidateAsync(Register request, CancellationToken ct)
        {
            List<string> errors = [];
            if (string.IsNullOrEmpty(request.user.Password?.Trim()))
                errors.Add("Некорректный пароль");

            var now = DateTime.UtcNow;
            var date = request.user.DateOfBithDay;

            if (string.IsNullOrEmpty(request.user.Email?.Trim()) || !Regex.Match(request.user.Email ?? "", emailPattern, RegexOptions.IgnoreCase).Success)
                if (string.IsNullOrEmpty(request.user.Phone.Trim()) || !Regex.Match(request.user.Phone, phonePattern, RegexOptions.IgnoreCase).Success)
                    errors.Add("Телефон неправильно указан");
            if (string.IsNullOrEmpty(request.user.FirstName.Trim()) || string.IsNullOrEmpty(request.user.LastName.Trim()))
                errors.Add("Неправильно указано имя");
            if (string.IsNullOrEmpty(request.user.Info?.Trim()))
                errors.Add("Не указана информация о себе");

            return errors;
        }
    }
}
