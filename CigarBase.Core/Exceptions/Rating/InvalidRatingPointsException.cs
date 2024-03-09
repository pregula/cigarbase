namespace CigarBase.Core.Exceptions.Rating;

public sealed class InvalidRatingPointsException : CustomException
{
    public int RatingPoints { get; }
    public InvalidRatingPointsException(int ratingPoints) 
        : base($"Rating points {ratingPoints} are invalid.")
    {
        RatingPoints = ratingPoints;
    }
}