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

public class ServiceDataModel
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal BasePrice { get; private set; }
    public string Category { get; private set; }

    public ServiceDataModel(int id, string name, decimal basePrice, string category)
    {
        Id = id;
        Name = name;
        BasePrice = basePrice;
        Category = category;
        Description = string.Empty;
    }

    public void UpdateInfo(string name, string description, decimal basePrice, string category)
    {
        Name = name;
        Description = description;
        BasePrice = basePrice;
        Category = category;
    }

    public void Validate()
    {
        if (Id <= 0)
            throw new ValidationException("Invalid service ID");

        if (string.IsNullOrWhiteSpace(Name) || Name.Length > 50)
            throw new ValidationException("Service name must be between 1-50 characters");

        if (BasePrice < 0)
            throw new ValidationException("Base price cannot be negative");

        if (string.IsNullOrWhiteSpace(Category) || Category.Length > 30)
            throw new ValidationException("Category must be between 1-30 characters");
    }
}
