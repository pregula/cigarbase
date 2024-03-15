namespace CigarBase.Core.Exceptions.Tobacco;

public sealed class InvalidTobaccoNameException : CustomException
{
    public string TobaccoName { get; }
    public InvalidTobaccoNameException(string tobaccoName) : base($"Tobacco name {tobaccoName} is invalid.")
    {
        TobaccoName = tobaccoName;
    }
}