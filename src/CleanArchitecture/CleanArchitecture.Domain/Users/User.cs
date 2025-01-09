using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Users.Events;

namespace CleanArchitecture.Domain.Users;

public sealed class User : Entity
{
    private User() { }
    public User(Guid id,
    Nombre nombre,
    Apellidos apellidos,
    Email email
    ) : base(id)
    {
        Nombre = nombre;
        Apellidos = apellidos;
        Email = email;

    }
    public Nombre? Nombre { get; private set; }
    public Apellidos? Apellidos { get; private set; }
    public Email? Email { get; private set; }

    public static User Create(
        Nombre nombre,
        Apellidos apellidos,
        Email email
        )
    {
        var user = new User(Guid.NewGuid(), nombre, apellidos, email);
        user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));
        return user;
    }


}