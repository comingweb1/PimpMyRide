using NUnit.Framework;
using PimpMyRideContratcs.DataModels;
using PimpMyRideContratcs.Exceptions;
using System;

namespace PimpMyRideTests.DataModelsTests;

[TestFixture]
public class ClientModelTests
{
    [Test]
    public void Client_ValidData_ShouldCreateSuccessfully()
    {
        // Arrange & Act
        var client = new ClientDataModel(
            id: Guid.NewGuid().ToString(),
            fullName: "Иванов Иван Иванович",
            phone: "+79123456789");

        // Assert
        Assert.DoesNotThrow(() => client.Validate());
    }


[TestFixture]
public class ServiceModelTests
{
    [Test]
    public void Service_ValidData_ShouldCreateSuccessfully()
    {
        // Arrange & Act
        var service = new ServiceDataModel(
            id: 1,
            name: "Замена масла",
            basePrice: 1500,
            category: "Техобслуживание");

        // Assert
        Assert.DoesNotThrow(() => service.Validate());
    }

[TestFixture]
public class ConsumableModelTests
{
    [Test]
    public void Consumable_ValidData_ShouldCreateSuccessfully()
    {
        // Arrange & Act
        var consumable = new ConsumableDataModel(
            id: 1,
            name: "Моторное масло",
            type: "Жидкости",
            unit: "л",
            pricePerUnit: 500);

        // Assert
        Assert.DoesNotThrow(() => consumable.Validate());
    }
    }
    }
}