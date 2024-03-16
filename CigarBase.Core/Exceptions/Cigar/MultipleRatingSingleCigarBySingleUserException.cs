using CigarBase.Core.ValueObjects.Cigar;
using CigarBase.Core.ValueObjects.User;

namespace CigarBase.Core.Exceptions.Cigar;

public sealed class MultipleRatingSingleCigarBySingleUserException : CustomException
{
    public CigarId CigarId { get; }
    public UserId UserId { get; }
    public MultipleRatingSingleCigarBySingleUserException(CigarId cigarId, UserId userId) 
        : base($"Cigar with ID: {cigarId} already has a rating of the user with ID: {userId}")
    {
        CigarId = cigarId;
        UserId = userId;
    }
}