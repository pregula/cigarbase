using CigarBase.Core.Entities;
using CigarBase.Core.ValueObjects.Factory;
using Shouldly;

namespace CigarBase.Unit.Tests.Entities;

public class FactoryTests
{
    [Fact]
    public void given_creating_factory_should_success()
    {
        var factoryId = FactoryId.Create();
        var name = new FactoryName("E.P. Carrillo");

        var factory = Factory.Create(factoryId, name);

        factory.ShouldNotBeNull();
    }
    
    #region Arrange

    public FactoryTests()
    {
    }

    #endregion
}