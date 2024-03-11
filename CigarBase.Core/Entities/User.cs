using CigarBase.Core.ValueObjects;
using CigarBase.Core.ValueObjects.User;

namespace CigarBase.Core.Entities;

public sealed class User
{
    public UserId Id { get; private set; }
    public Email Email { get; private set; }
    public UserName UserName { get; private set; }
    public Password Type { get; private set; }
    public Date CreatedAt { get; private set; }
}