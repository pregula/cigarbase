using CigarBase.Core.Entities;
using CigarBase.Core.Exceptions.Factory;
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

    [Fact]
    public void given_creating_factory_with_empy_name_should_fail()
    {
        var factoryId = FactoryId.Create();
        
        var exception = Record.Exception(() => Factory.Create(factoryId, new FactoryName(string.Empty)));

        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<InvalidFactoryNameException>();
    }
    
    #region Arrange

    public FactoryTests()
    {
    }

    #endregion
}