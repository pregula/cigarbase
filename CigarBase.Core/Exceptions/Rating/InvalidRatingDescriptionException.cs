namespace CigarBase.Core.Exceptions.Rating;

public sealed class InvalidRatingDescriptionException : CustomException
{
    public string RatingDescription { get; }
    public InvalidRatingDescriptionException(string ratingDescription)
        : base($"Cigar rating description '{ratingDescription}' is invalid.")
    {
        RatingDescription = ratingDescription;
    }
}