using WebApplication4dg.DB;

namespace WebApplication4dg.sqrs.Registration
{
    public class RegisterDTO
    {
        public int? Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Password { get; set; }

        public DateOnly? DateOfBithDay { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? Info { get; set; }


        public static explicit operator User(RegisterDTO user) =>
            new User
            {
                Info = user.Info,
                Phone = user.Phone,
                DateOfBithDay = user.DateOfBithDay,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = string.IsNullOrEmpty(user.Password) ? throw new Exception("Не задан пароль для пользователя") : user.Password
            };
        public static explicit operator RegisterDTO(User user) =>
            new RegisterDTO
            {
                Id = user.Id,
                Info = user.Info,
                Phone = user.Phone,
                DateOfBithDay = user.DateOfBithDay,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
    }
}
