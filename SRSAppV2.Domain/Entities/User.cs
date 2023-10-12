using prmToolkit.NotificationPattern;
using SRSAppV2.Domain.Extensions;

namespace SRSAppV2.Domain.Entities;

public class User: Notifiable
{
    public User(Guid id, string firstName, string lastName, string email, string password)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;

        new AddNotifications<User>(this)
            .IfNullOrInvalidLength(x => x.FirstName, 3, 50)
            .IfNullOrInvalidLength(x => x.LastName, 3, 150)
            .IfNotEmail(x => x.Email)
            .IfNullOrInvalidLength(x => x.Password, 6, 32);

        this.Password = password.ConvertToMD5();
        this.CreatedAt = DateTime.Now;
        this.Activated = false;
    }

    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public bool Activated { get; private set; }
}
