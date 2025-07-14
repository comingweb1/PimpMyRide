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


public class DiscountDataModel
{
    public int Id { get; private set; }
    public decimal Percentage { get; private set; }
    public string Condition { get; private set; }
    public DateTime ValidFrom { get; private set; }
    public DateTime ValidTo { get; private set; }
    public int ClientId { get; private set; }

    public DiscountDataModel(int id, decimal percentage, string condition, DateTime validFrom, DateTime validTo, int clientId)
    {
        Id = id;
        Percentage = percentage;
        Condition = condition;
        ValidFrom = validFrom;
        ValidTo = validTo;
        ClientId = clientId;
    }

    public bool IsActive()
    {
        var now = DateTime.Now;
        return now >= ValidFrom && now <= ValidTo;
    }

    public void Validate()
    {
        if (Id <= 0)
            throw new ValidationException("Invalid discount ID");

        if (Percentage <= 0 || Percentage > 100)
            throw new ValidationException("Percentage must be between 0-100");

        if (string.IsNullOrWhiteSpace(Condition))
            throw new ValidationException("Condition is required");

        if (ValidFrom >= ValidTo)
            throw new ValidationException("ValidFrom must be before ValidTo");

        if (ClientId <= 0)
            throw new ValidationException("Invalid client ID");
    }
}