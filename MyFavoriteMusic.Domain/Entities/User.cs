
using MyFavoriteMusic.Domain.Enums;

namespace MyFavoriteMusic.Domain.Entities
{
    public class User
    {
        public User(string userName, string passwordHash, string email, DateTime registrationDate, UserRole role)
        {
            UserName = userName;
            PasswordHash = passwordHash;
            Email = email;
            RegistrationDate = registrationDate;
            Role = role;
        }

        public Guid Id { get; private set; }
        public string UserName { get; private set; }
        public string PasswordHash { get; private set; }
        public string Email { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public UserRole Role { get; private set; }


        public void ChangeUserName(string userName) 
        {
            if (UserName == null || UserName == "") throw new ArgumentNullException(nameof(UserName));

            UserName = userName ?? string.Empty;
        }

        public void ChangePassword(string passwordHash)
        {
            PasswordHash = passwordHash ?? string.Empty;
        }

        public void ChangeRole(UserRole role)
        {
            Role = role;
        }

    }

}
