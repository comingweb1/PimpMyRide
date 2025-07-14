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

public class OrderDataModel
{
    public int Id { get; private set; }
    public DateTime ServiceDate { get; private set; }
    public string Status { get; private set; }
    public decimal TotalCost { get; private set; }
    public decimal AppliedDiscount { get; private set; }
    public int ClientId { get; private set; }
    public int ServiceId { get; private set; }

    public OrderDataModel(int id, DateTime serviceDate, string status, int clientId, int serviceId)
    {
        Id = id;
        ServiceDate = serviceDate;
        Status = status;
        ClientId = clientId;
        ServiceId = serviceId;
        TotalCost = 0;
        AppliedDiscount = 0;
    }

    public void Validate()
    {
        if (Id <= 0)
            throw new ValidationException("Invalid order ID");

        if (ServiceDate == default)
            throw new ValidationException("Service date is required");

        if (!new[] { "выполнено", "в процессе", "отменено" }.Contains(Status))
            throw new ValidationException("Invalid status value");

        if (ClientId <= 0)
            throw new ValidationException("Invalid client ID");

        if (ServiceId <= 0)
            throw new ValidationException("Invalid service ID");

        if (TotalCost < 0)
            throw new ValidationException("Total cost cannot be negative");

        if (AppliedDiscount < 0 || AppliedDiscount > 1)
            throw new ValidationException("Discount must be between 0-1");
    }
}
