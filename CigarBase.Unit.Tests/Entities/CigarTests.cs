using CigarBase.Core.Entities;
using CigarBase.Core.ValueObjects;
using CigarBase.Core.ValueObjects.Rating;
using CigarBase.Core.ValueObjects.User;
using Shouldly;

namespace CigarBase.Unit.Tests.Entities;

public class CigarTests
{
    [Fact]
    public void given_rating_for_cigar_an_unrated_cigar_should_success()
    {
        var rating = new Rating(Guid.NewGuid(), "Rating description", 91, _userId, _cigar.Id, Date.Now());
        _cigar.AddRating(rating);
        _cigar.Ratings.ShouldHaveSingleItem();
    }
    
    #region Arrenge

    private Cigar _cigar;
    private UserId _userId;
    public CigarTests()
    {
        _cigar = Cigar.Create(Guid.NewGuid(), "Cigar name", "Cigar description", Date.Now());
        _userId = new(Guid.Parse("00000000-0000-0000-0000-000000000001"));
    }
    #endregion
}