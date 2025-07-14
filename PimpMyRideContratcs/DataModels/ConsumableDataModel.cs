using PimpMyRideContratcs.Exceptions;
using PimpMyRideContratcs.Extensions;
using PimpMyRideContratcs.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PimpMyRideContratcs.DataModels;

public class ConsumableDataModel
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Type { get; private set; }
    public string Unit { get; private set; }
    public decimal PricePerUnit { get; private set; }
    public int StockQuantity { get; private set; }

    public ConsumableDataModel(int id, string name, string type, string unit, decimal pricePerUnit)
    {
        Id = id;
        Name = name;
        Type = type;
        Unit = unit;
        PricePerUnit = pricePerUnit;
        StockQuantity = 0;
    }

    public void UpdateStock(int quantity)
    {
        StockQuantity = quantity;
    }

    public void Validate()
    {
        if (Id <= 0)
            throw new ValidationException("Invalid consumable ID");

        if (string.IsNullOrWhiteSpace(Name) || Name.Length > 50)
            throw new ValidationException("Name must be between 1-50 characters");

        if (string.IsNullOrWhiteSpace(Type) || Type.Length > 30)
            throw new ValidationException("Type must be between 1-30 characters");

        if (string.IsNullOrWhiteSpace(Unit) || Unit.Length > 10)
            throw new ValidationException("Unit must be between 1-10 characters");

        if (PricePerUnit < 0)
            throw new ValidationException("Price cannot be negative");

        if (StockQuantity < 0)
            throw new ValidationException("Stock quantity cannot be negative");
    }
}
