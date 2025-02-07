using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Roles;
using CleanArchitecture.Domain.Users.Events;
namespace CleanArchitecture.Domain.Users;


public sealed class User : Entity<UserId>
{
    private User() { }
    private User(
        UserId id,
        Nombre nombre,
        Apellidos apellidos,
        Email email,
        PasswordHash passwordHash
    ) : base(id)
    {
        Nombre = nombre;
        Apellidos = apellidos;
        Email = email;
        PasswordHash = passwordHash;

    }
    public Nombre? Nombre { get; private set; }
    public Apellidos? Apellidos { get; private set; }
    public Email? Email { get; private set; }
    public PasswordHash? PasswordHash { get; private set; }

    public static User Create(
        Nombre nombre,
        Apellidos apellidos,
        Email email,
        PasswordHash passwordHash
        )
    {
        var user = new User(UserId.New(), nombre, apellidos, email, passwordHash);
        user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id!.Value));
        return user;
    }

    public ICollection<Role>? Roles { get; set; }


}