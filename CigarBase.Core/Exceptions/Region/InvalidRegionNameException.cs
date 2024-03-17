namespace CigarBase.Core.Exceptions.Region;

public sealed class InvalidRegionNameException: CustomException
{
    public InvalidRegionNameException() : base("Region name is invalid.")
    {
    }
}